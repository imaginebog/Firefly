using UnityEngine;
using System.Collections;

public class DoorActivated : MonoBehaviour {
	
	private bool _isBeingLookedAt;
	private bool _isActivated;
	private bool canBeActivated;
	private ActivatableComponent _activatableComponent;
	private Renderer _rendererComponent;
	//private Vector3 rotation;
	
	public bool IsBeingLookingAt
	{
		get { return _isBeingLookedAt; }
	}
	
	public bool IsActivated
	{
		get { return _isActivated; }
	}
	
	
	// Use this for initialization
	void Start () {
		_activatableComponent = GetComponent<ActivatableComponent>();
		_rendererComponent = GetComponent<Renderer>();
		canBeActivated = false;
		//rotation = this.transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {	
		// Are we being looked at?
		_isBeingLookedAt = _activatableComponent.HasActivationFocus;
		
		// Have we been activated?
		_isActivated = _activatableComponent.IsActivated;
		
		
		
		if(_isActivated && canBeActivated){
			Debug.Log("It works");
			StartCoroutine(this.GetComponent<DoorOpening>().Open());
			//this.GetComponent<Animator>().Play("Default Take");
			//this.transform.ro
		}
		else
		{
			//Debug.Log("Who knows?");
		}
	}

	void OnTriggerEnter(Collider other) {
		canBeActivated = true;
	}
	
	void OnTriggerExit(Collider other) {
		canBeActivated = false;
	}

}