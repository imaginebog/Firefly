using UnityEngine;
using System.Collections;

public class InvisibleManager : MonoBehaviour {


	GazeAwareComponent gaze;
	SpriteRenderer rend;
	bool invis;

	// Use this for initialization
	void Start () {
		gaze = GetComponent<GazeAwareComponent>();
		rend = GetComponent<SpriteRenderer>();
		invis = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if(gaze.HasGaze)
		{
			rend.enabled = true;
			invis = true;
		}
		else if(invis)
		{
			rend.enabled = false;
		}
	}
}
