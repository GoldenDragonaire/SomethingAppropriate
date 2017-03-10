using UnityEngine;
using System.Collections;

public class ifHit : MonoBehaviour {
	Animator animator;
	// Use this for initialization
	void Awake () {
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void hit(){
		Debug.Log ("hit");
		animator.SetInteger ("state", 1);
		//Destroy (gameObject); 
	}
}
