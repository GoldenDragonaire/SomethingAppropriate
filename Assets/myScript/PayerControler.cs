using UnityEngine;
using System.Collections;

public class PayerControler : MonoBehaviour {

	public bool facingRight = true;	
	public bool jump = false;
	public bool pew = false;	

	Animator animator;

	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	const int STATE_IDLE = 0;
	const int STATE_WALK = 1;
	const int STATE_JUMP = 2;
	const int STATE_ATTACK = 3;
	int _currentAnimationState = STATE_IDLE;
	private Transform groundCheck;
	private bool grounded = false;
	int shotCount = 250;

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
		if(Input.GetButtonDown("Fire3") && grounded && Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) == 0 && shotCount == 0)
			pew = true;
	}

	void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal");

		if (h * GetComponent<Rigidbody2D> ().velocity.x < maxSpeed && animator.GetInteger("state") != 3) {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * h * moveForce);
		}

		if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > 0 && grounded && shotCount <= 200)
			changeState(STATE_WALK);

		if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) == 0 && grounded && shotCount <= 200)
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

		if (pew) {
			changeState (STATE_ATTACK);
			shotCount += 250;
			pew = false;
		} else if (shotCount > 0) {
			shotCount -= 1;
		}

	}

	void Flip ()
	{
		if (animator.GetInteger ("state") != 3) {
			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
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

		case STATE_ATTACK:
			animator.SetInteger ("state", STATE_ATTACK);
			break;
		}

		_currentAnimationState = state;
	}
}
