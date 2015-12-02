using UnityEngine;
using System.Collections;

public class FireflyMovement : MonoBehaviour {

    // Use this for initialization
    public float horizontalSpeed;
    public float verticalSpeed;
    public float amplitude;
    public float height;

    public Vector3 tempPosition;

	void Start () {
        tempPosition = transform.position;
        height = transform.position.y;
        InvokeRepeating("changeDirection", 5f, 5f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        tempPosition.x += horizontalSpeed;
        tempPosition.y = height + Mathf.Sin(Time.realtimeSinceStartup*verticalSpeed) * amplitude;
       
        transform.position = tempPosition;
	}

    void changeDirection()
    {
        horizontalSpeed = -horizontalSpeed;
    }
}
