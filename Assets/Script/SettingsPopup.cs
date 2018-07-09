using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame

	public void OnSubmitName(string name){
		Debug.Log (name);
	}

	public void OnSpeedValue(float speed){
		Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
	}

	public void Open(){
		gameObject.SetActive (true);
	}

	public void Close(){
		gameObject.SetActive (false);
	}
}
