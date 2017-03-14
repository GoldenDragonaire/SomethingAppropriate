using UnityEngine;
using System.Collections;

public class ifHit : MonoBehaviour {
	public int health;
	public int deathFrameLength;
	private int framesUntilDeath;
	Animator animator;
	public Animation anim;
	public int i;
	// Use this for initialization
	void Awake () {
		animator = this.GetComponent<Animator>();
		framesUntilDeath = deathFrameLength;
		anim = GetComponent<Animation>();
		i = 500;
	}
	
	// Update is called once per frame
	void Update () {
		if (health == 0) {
			animator.SetInteger ("state", 1); //start death animation
				i--;
		//	StartCoroutine(finishAnimation());
		}
		if (i == 0)
			Destroy (gameObject);


		
		/*if (animator.GetInteger ("state") == 1) {
			framesUntilDeath--;
			if (framesUntilDeath == 0)
				
		}*/

	}
	public void hit(){
		Debug.Log ("hit");
		health--;
		//Destroy (gameObject); 
	}
	//public IEnumerator finishAnimation{
	//	yield return new WaitForSeconds(1);
	//}

}
