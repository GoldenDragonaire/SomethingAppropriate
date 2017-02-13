using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
	public Rigidbody2D rocket;				// Prefab of the rocket.
	public float speed = 20f;	// The speed the rocket will fire at.
	public int pewdelay = 0;

	private PayerControler playerCtrl;		// Reference to the PlayerControl script.

	void Awake()
	{
		// Setting up the references.
		playerCtrl = transform.root.GetComponent<PayerControler>();
		Debug.Log ("bow awake");
	}


	void Update ()
	{
		// If the fire button is pressed...
		if (playerCtrl.pew)
		{
			Debug.Log ("read input to fire");
			playerCtrl.pew = false;
			pewdelay += 26;
		}
		if (pewdelay > 0) {
			Debug.Log ("Starting to fire");
			pewdelay--;
			if (pewdelay == 1) {
				Debug.Log ("fire");
				// If the player is facing right...
				if (playerCtrl.facingRight) {
					Debug.Log ("fire.right");
					//yield return new WaitForSeconds (1);
					// ... instantiate the rocket facing right and set it's velocity to the right. 
					Rigidbody2D bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2 (speed, 0);

				} else {
					Debug.Log ("Fire.left");
					//yield return new WaitForSeconds (1);
					// Otherwise instantiate the rocket facing left and set it's velocity to the left.
					Rigidbody2D bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 180f))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2 (-speed, 0);
				}
			}
		}
	}
}
