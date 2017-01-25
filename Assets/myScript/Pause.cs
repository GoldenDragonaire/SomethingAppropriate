using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	public bool paused = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Pause")) {
			Debug.Log ("pause");
			if (paused) //unpause the game
				Time.timeScale = 1.0f;
			else{
				Time.timeScale = 0.0f; //pause the game
			//private Vector3 prePauseTransform = transform.position;
			}
				paused = !paused; //toggle the pause 
	}
}
}