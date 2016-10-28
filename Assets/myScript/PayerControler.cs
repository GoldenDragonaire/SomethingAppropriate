using UnityEngine;
using System.Collections;

public class PayerControler : MonoBehaviour {

	public bool facingRight = true;	
	public bool jump = false;	

	Animator animator;

	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	const int STATE_IDLE = 0;
	const int STATE_WALK = 1;
	const int STATE_JUMP = 2;
	int _currentAnimationState = STATE_IDLE;
	private Transform groundCheck;
	private bool grounded = false;

	void Awake()
	{
		groundCheck = transform.Find("groundCheck");
		animator = this.GetComponent<Animator>();
	}
	
	void Update()
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  

		if(Input.GetButtonDown("Jump") && grounded)
			jump = true;
	}

	void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal");

		if (h * GetComponent<Rigidbody2D> ().velocity.x < maxSpeed) {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * h * moveForce);
		}

		if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > 0 && grounded)
			changeState(STATE_WALK);

		if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) == 0 && grounded)
			changeState(STATE_IDLE);

		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if(h > 0 && !facingRight)
			Flip();
		else if(h < 0 && facingRight)
			Flip();

		if(jump)
		{
			changeState(STATE_JUMP);

			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));

			jump = false;
		}
	}

	void Flip ()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void changeState(int state){

		if (_currentAnimationState == state)
			return;

		switch (state) {

		case STATE_WALK:
			animator.SetInteger ("state", STATE_WALK);
			break;

		case STATE_JUMP:
			animator.SetInteger ("state", STATE_JUMP);
			break;

		case STATE_IDLE:
			animator.SetInteger ("state", STATE_IDLE);
			break;
		}

		_currentAnimationState = state;
	}
}
