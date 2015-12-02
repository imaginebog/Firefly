using UnityEngine;
using System.Collections;

public class CubeControl : MonoBehaviour {

	private bool _isBeingLookedAt;
	private bool _isActivated;
	private ActivatableComponent _activatableComponent;
	private Renderer _rendererComponent;

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
	}
	
	// Update is called once per frame
	void Update () {	
		// Are we being looked at?
		_isBeingLookedAt = _activatableComponent.HasActivationFocus;
		
		// Have we been activated?
		_isActivated = _activatableComponent.IsActivated;

		if(_isActivated){
			Debug.Log("It works");
			_rendererComponent.material.color = Color.red;
		}
		else
		{
			//Debug.Log("Who knows?");
		}
	}
}
