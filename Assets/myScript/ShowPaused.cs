using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowPaused : MonoBehaviour {
	CanvasGroup group;
	// Use this for initialization
	void Start () {
		//Color color = Material.color;
		group = GetComponent<CanvasGroup>();
		group.alpha = 0;
		group.blocksRaycasts = false;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetButtonDown ("Pause") )
		{
			//If space is pressed, and the button is currently interactable, make it so its not interactable
			if (GetComponent<Button> ().IsInteractable () == true) {
				GetComponent<Button> ().interactable = false; 
			}
			else //Else make it interactable
			{
				GetComponent<Button>().interactable = true;
	}

		}*/
		if (Input.GetButtonDown ("Pause") ){
			if (group.alpha == 1) {
				group.alpha = 0;
				group.blocksRaycasts = false;
			}
			else{
				group.alpha = 1;
				group.blocksRaycasts = true;
		}

}
}
}
