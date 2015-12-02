using UnityEngine;
using System.Collections;

public class PickUpItem : MonoBehaviour {

	// Use this for initialization
	private bool _isBeingLookedAt;
	private bool _isActivated;
	public int id;
	private ActivatableComponent _activatableComponent;
	private Renderer _rendererComponent;
	public GameObject light1;
	public GameObject light2;
	public GameObject light3;
	public GameObject light4;
	public GameObject group;
	public GameObject door;
	public AudioSource music;
	private bool canBeActivated;
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
			//StartCoroutine(this.GetComponent<DoorOpening>().Open());
			Inventory._instance.keys++;
			if(id == 1)
			{
			light1.GetComponent<Light>().enabled = false;
			light2.GetComponent<Light>().enabled = false;
			light3.GetComponent<Light>().enabled = false;
			light4.GetComponent<Light>().enabled = false;
			music.Play();
			group.SetActive(true);
			}
			_rendererComponent.enabled = false;
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
