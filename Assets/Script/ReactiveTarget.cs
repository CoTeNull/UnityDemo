using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReactiveToHit(){
		WanderingAI behavior = GetComponent<WanderingAI> ();
		if (behavior != null) {
			behavior.SetAlive(false);
		}
		StartCoroutine (Die ());
	}

	private IEnumerator Die(){
		Vector3 rotation = new Vector3 (90, 0, 0);
		iTween.RotateTo (this.gameObject, rotation, 1.5f);

		yield return new WaitForSeconds(1.5f);
		Destroy(this.gameObject);
	}
}
