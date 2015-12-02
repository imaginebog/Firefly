using UnityEngine;
using System.Collections;

public class CloseDoor : MonoBehaviour {

	public GameObject door;
	public FireflyAnimatorController fac;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		fac.triggerLastRoom();
		StartCoroutine(door.GetComponent<DoorOpening>().Open());
		this.GetComponent<BoxCollider>().enabled = false;
	}
}
