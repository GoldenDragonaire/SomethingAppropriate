using UnityEngine;
using System.Collections;

public class WinGame : MonoBehaviour {
	AudioSource audio;

	void Start() {
		audio = GetComponent<AudioSource>();
	}

	void OnCollisionEnter ()
	{
		Debug.Log ("win");
	}
}