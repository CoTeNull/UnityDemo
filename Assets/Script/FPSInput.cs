using UnityEngine;
using System.Collections;

public class FPSInput : MonoBehaviour {
	public  float speed=10.0f;
	public float jumpSpeed = 15.0f;
	public float gravity = -9.8f;
	public float terminalVelocity = -10.0f;
	public float minFall = -1.5f;
	private float _vertSpeed;

	public const float baseSpeed = 6.0f;

	private CharacterController _characterController;

	void Awake(){
		Messenger<float>.AddListener (GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}
	
	void OnDestroy(){
		Messenger<float>.RemoveListener (GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}
	
	private void OnSpeedChanged(float value){
		speed = baseSpeed * value;
	}

	void Start () {
		_characterController=GetComponent<CharacterController>();
		_vertSpeed = minFall;
	}

	void Update () {
		if (_characterController.isGrounded) {
			if (Input.GetButtonDown ("Jump")) {
				_vertSpeed = jumpSpeed;
			} else {
				_vertSpeed = minFall;
			}
		} else {
			_vertSpeed+=gravity *5*Time.deltaTime;
			if(_vertSpeed <terminalVelocity){
				_vertSpeed = terminalVelocity;
			}
		}

		float deltaX = speed * Input.GetAxis ("Horizontal");
		float deltaZ = speed * Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (deltaX,0,deltaZ);
		movement = Vector3.ClampMagnitude (movement,speed);
		movement.y = _vertSpeed;
		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);
		_characterController.Move (movement);
		
		
	}
}