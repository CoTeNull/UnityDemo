using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerCharacter : MonoBehaviour {
	private int _health;
	[SerializeField] private Text hpLabel;
	// Use this for initialization
	void Start () {
		_health = 5;
		hpLabel.text = _health.ToString ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Hurt(int damage){
		_health -= damage;
		hpLabel.text = _health.ToString ();
	}
	public void Heal(int num){
		_health += num;
		hpLabel.text = _health.ToString ();
	}
}
