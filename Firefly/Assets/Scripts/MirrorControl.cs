using UnityEngine;
using System.Collections;

public class MirrorControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void reflect(Vector3 angle)
    {
        Debug.DrawRay(transform.position, angle*10);
    }
}
