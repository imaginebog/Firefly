using UnityEngine;
using System.Collections;

public class ReflectionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray LandingRay = new Ray(transform.position, transform.forward);

        
        if (Physics.Raycast(LandingRay, out hit))
        {
            if (hit.collider.tag == "Mirror")
            {
                Debug.Log("Si esta haciendo colision");
                //hit.collider.GetComponent<LineRenderer>().enabled = true;
                Vector3 angle = Vector3.Reflect(transform.forward, hit.collider.transform.forward);
                hit.collider.GetComponent<MirrorControl>().reflect(angle);
            }
        }
        
        
        //Debug.DrawRay(transform.position, transform.forward * 20);
	}
}
