using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
	
	
	public enum RotateAxes{
		MouseXandY=0,
		MouseX=1,
		MouseY=2
	}
	public  RotateAxes axes=RotateAxes.MouseX;
	public float sensitivityHor=10.0f;
	public float sensitivityVer=10.0f;
	public float rotate_X=0;
	public float rotate_Y=0;
	public float minVer=-90.0f;
	public float maxVer=90.0f;
	// Use this for initialization
	void Start () {
		Rigidbody body =GetComponent<Rigidbody>();
		if (body != null) {
			body.freezeRotation=true;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (axes == RotateAxes.MouseX) {
			transform.Rotate(0,sensitivityHor * Input.GetAxis("Mouse X"),0);
			
		} else if (axes == RotateAxes.MouseY) {
			rotate_X-=Input.GetAxis("Mouse Y") * sensitivityVer;
			rotate_X=Mathf.Clamp(rotate_X,minVer,maxVer);
			rotate_Y=transform.localEulerAngles.y;
			transform.localEulerAngles=new Vector3(rotate_X,rotate_Y,0);
			
			
		}
		else if(axes == RotateAxes.MouseXandY){
			
			rotate_X-=Input.GetAxis("Mouse Y") * sensitivityVer;
			rotate_X=Mathf.Clamp(rotate_X,minVer,maxVer);
			float delta =Input.GetAxis("Mouse X") * sensitivityHor;
			rotate_Y=transform.localEulerAngles.y+delta;
			transform.localEulerAngles=new Vector3(rotate_X,rotate_Y,0);
			
			
		}
		
	}
}