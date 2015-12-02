using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Vector3 movementVector;
	private CharacterController characterController;
	private float movementSpeed = 8;
	private float jumpPower = 15;
	private float gravity = 40;


	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		movementVector.x = Input.GetAxis("LeftJoystickX") * movementSpeed;
		 
			 movementVector.z = Input.GetAxis("LeftJoystickY") * movementSpeed;
		  
		 movementVector.y -= gravity * Time.deltaTime;
		  
		 characterController.Move(movementVector * Time.deltaTime);
		}
	

}
