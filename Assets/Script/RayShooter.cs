using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class RayShooter : MonoBehaviour {
	private Camera _camera;
	public Texture2D texture;
	public bool hide = true;

	[SerializeField] private GameObject popup;
	// Use this for initialization
	void Start () {
		_camera = GetComponent<Camera> ();
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !EventSystem.current.IsPointerOverGameObject()) {
			Vector3 point=new Vector3(_camera.pixelWidth/2,_camera.pixelHeight/2,0);
			Ray ray=_camera.ScreenPointToRay(point);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit))
			{
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if(target!=null){

					target.ReactiveToHit();
					Messenger.Broadcast(GameEvent.ENEMY_HIT);
				}else{
					StartCoroutine(SphereIndicator(hit.point));
				}


			}
		}

		if (Input.GetMouseButtonDown (1)&& !popup.activeSelf) {
			OnGUI();
			hide=!hide;
		}
	}
	private IEnumerator SphereIndicator(Vector3 pos)
	{
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.position = pos;
		yield return new WaitForSeconds (1);
		Destroy (sphere);
	}

	void OnGUI()
	{

		int size = 500;
		float posX = _camera.pixelWidth / 2 - (size-5) /2;
		float posY = _camera.pixelHeight / 2 - size / 2;
		if (hide) {
			size = 0;
		} else {
			size = 500;
		}
		GUI.Label (new Rect (posX, posY, size, size), texture);

	}

}
