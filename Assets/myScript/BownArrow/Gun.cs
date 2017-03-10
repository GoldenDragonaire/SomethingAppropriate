using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
	public Rigidbody2D rocket;				// Prefab of the rocket.
	public float speed = 20f;	// The speed the rocket will fire at.
	public int pewdelay = 0;
	//public bool fire = false; //if it is okay to fire
	private PayerControler playerCtrl;		// Reference to the PlayerControl script.

	void Awake()
	{
		// Setting up the references.
		playerCtrl = transform.root.GetComponent<PayerControler>();
	}


	void Update ()
	{
		// If the fire button is pressed...
		/*if (playerCtrl.pew)
		{
			
			pewdelay += 26;
		}
		if (pewdelay > 0) pewdelay--; */
		/*if (fire) {
			Debug.Log ("Starting to fire");
							Debug.Log ("fire");
			fire = false;
				// If the player is facing right...
				if (playerCtrl.facingRight) {
					//yield return new WaitForSeconds (1);
					// ... instantiate the rocket facing right and set it's velocity to the right. 
					Rigidbody2D bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2 (speed, 0);

				} else {
					//yield return new WaitForSeconds (1);
					// Otherwise instantiate the rocket facing left and set it's velocity to the left.
					Rigidbody2D bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 180f))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2 (-speed, 0);

			}
		}*/
	}
	public void fire () {

		// If the player is facing right...
		if (playerCtrl.facingRight) {
			// ... instantiate the rocket facing right and set it's velocity to the right. 
			Rigidbody2D bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2 (speed, 0);

		} else {
			// Otherwise instantiate the rocket facing left and set it's velocity to the left.
			Rigidbody2D bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 180f))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2 (-speed, 0);

		}
	}

}
