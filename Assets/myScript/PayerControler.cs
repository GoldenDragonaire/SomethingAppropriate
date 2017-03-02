using UnityEngine;
using System.Collections;

public class PayerControler : MonoBehaviour {

	public bool facingRight = true;	
	public bool pew = false;	//can fire?
	public int facing = 1; //right
	public bool jump = false;	//can jump?
	private float h = 0;

	Animator animator;

	public float moveForce = 365f;
	public float maxSpeed = 5f;			//movement dynamics
	public float jumpForce = 1000f;
	public float wallForce = 500f;
	const int STATE_IDLE = 0;
	const int STATE_WALK = 1;	//references for animations
	const int STATE_JUMP = 2;
	const int STATE_ATTACK = 3;
	int _currentAnimationState = STATE_IDLE;
	private Transform groundCheck; //ability to jump?
	private Transform wallCheck;
	private bool grounded = false;

	private bool wallTrump = false;
	//bow = GameObject.Find("bow");
	public Gun gun;
	int shotCount = 0; //used to make a delay between shots
	int maxShotDelay = 100; //used to determine the allowed time shot

	void Awake()
	{
		groundCheck = transform.Find("groundCheck");
		animator = this.GetComponent<Animator>();
		wallCheck = transform.Find("wallCheck");
		gun = gameObject.GetComponentInChildren<Gun>();

		//DontDestroyOnLoad(transform.gameObject);

	}

	void Update()
	{
		
	
		//grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  
		if (this.collider != null) {
			grounded = true;
		}
		wallTrump = Physics2D.Linecast(transform.position, wallCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetButtonDown ("Fire3") && grounded && Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x) == 0 && shotCount == 0) {
			pew = true;
			Debug.Log ("pewtrue");
		}

		if (grounded || wallTrump)
			this.GetComponent<Rigidbody2D>().drag = 5;
		else this.GetComponent<Rigidbody2D>().drag = 0;

			
		if (Input.GetButtonDown ("Jump") && (wallTrump || grounded)) 
				jump = true; 
	}

	void FixedUpdate ()
	{
		if (_currentAnimationState != 3) {
			h = Input.GetAxis ("Horizontal");
		}


		if (h * GetComponent<Rigidbody2D> ().velocity.x < maxSpeed) {
			if (grounded) GetComponent<Rigidbody2D> ().AddForce (Vector2.right * h * moveForce);
			else GetComponent<Rigidbody2D> ().AddForce (Vector2.right * h * moveForce/30);

		}

		if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > 0 && grounded && shotCount <= maxShotDelay - 47)
			changeState(STATE_WALK);

		if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) == 0 && grounded && shotCount <= maxShotDelay - 47)
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

			if (wallTrump) //if you're next to a wall 
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 ((wallForce * facing * -1), 0f));

		
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));

			jump = false;
		}


		if (pew && shotCount == 0) {
			Debug.Log ("pew");
			changeState (STATE_ATTACK);
			shotCount += 100;
		}
		else if (pew && shotCount == maxShotDelay - 20){
			gun.fire();
			pew = false;
		} else if (shotCount > 0) {
			shotCount -= 1;
		}


		if (GetComponent<Rigidbody2D>().position.y < -10) {
			transform.position = new Vector3 (0, 1, 0);
		}

	}

	void Flip ()
	{

		if (animator.GetInteger ("state") != 3) 
			facingRight = !facingRight;


		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		facing *= -1;

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
			Debug.Log ("attackanimation");
			animator.SetInteger ("state", STATE_ATTACK);
			break;
		}

		_currentAnimationState = state;
	}
}
