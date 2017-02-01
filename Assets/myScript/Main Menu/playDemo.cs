using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playDemo : MonoBehaviour {
	public Button yourButton;
	public string level = "level";

	void Start () {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Time.timeScale = 1.0f;
		Application.LoadLevel (level);
	}
}