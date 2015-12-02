using UnityEngine;
using System.Collections;

public class LightAwareGaze : MonoBehaviour {

	public GameObject player;
	public HealthManager hm;

	// Use this for initialization
	void Start () {

		player = GameObject.Find ("Player");
		hm =  player.GetComponent<HealthManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
