using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private GameObject hpboxPrefab;
	[SerializeField] private WanderingAI wanderingAI;
	private GameObject _enemy;
	private GameObject _hpbox;
	private GameObject floor;

	void Awake(){
		Messenger<float>.AddListener (GameEvent.SPEED_CHANGED, OnNewEnemy);
	}

	void OnDestroy(){
		Messenger<float>.RemoveListener (GameEvent.SPEED_CHANGED,OnNewEnemy);
	}

	private void OnNewEnemy(float value){
		wanderingAI.speed = 3.0f * value;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_enemy == null) {
			floor = GameObject.Find("Floor");
			float x = floor.GetComponent<MeshFilter>().mesh.bounds.size.x*floor.transform.localScale.x-5;
			float z = floor.GetComponent<MeshFilter>().mesh.bounds.size.z*floor.transform.localScale.z-5;
			_enemy = Instantiate(enemyPrefab) as GameObject;
			_enemy.transform.position = new Vector3(Random.Range(-x/2,x/2),1,Random.Range(-z/2,z/2));
			float angle = Random.Range(0,360);
			_enemy.transform.Rotate(0,angle,0);
		}
		if (_hpbox == null) {
			floor = GameObject.Find("Floor");
			float x = floor.GetComponent<MeshFilter>().mesh.bounds.size.x*floor.transform.localScale.x-5;
			float z = floor.GetComponent<MeshFilter>().mesh.bounds.size.z*floor.transform.localScale.z-5;
			_hpbox = Instantiate(hpboxPrefab) as GameObject;
			_hpbox.transform.position = new Vector3(Random.Range(-x/2,x/2),1,Random.Range(-z/2,z/2));
			float angle = Random.Range(0,360);
			_hpbox.transform.Rotate(0,angle,0);
		}
	}
}
