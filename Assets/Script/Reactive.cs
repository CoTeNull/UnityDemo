using UnityEngine;
using System.Collections;

public class Reactive : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		PlayerCharacter player = other.GetComponent<PlayerCharacter> ();
		if (player != null) {
			player.Heal(1);
		}
		Destroy (this.gameObject);
	}
}
