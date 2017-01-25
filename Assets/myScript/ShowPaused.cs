using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowPaused : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Button>().interactable = false; 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Pause") )
		{
			//If space is pressed, and the button is currently interactable, make it so its not interactable
			if (GetComponent<Button> ().IsInteractable () == true) {
				GetComponent<Button> ().interactable = false; 
			}
			else //Else make it interactable
			{
				GetComponent<Button>().interactable = true;
	}
		}
		if(Input.GetButtonDown ("Pause") ){
			if (Camera.main.GetComponent<Pause>().paused)
				this.renderer.material.color.a = 0;
			else
				this.renderer.material.color.a = 1;
		}
}
}
