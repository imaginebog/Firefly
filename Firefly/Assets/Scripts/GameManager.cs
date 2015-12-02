using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

   public GameObject firefly;
	public GameObject player;
	public MouseLook ml;

	private EyeXHost _eyexHost;
	// Use this for initialization
	void Awake () {
        Invoke("spawnFirefly", 10f);
		_eyexHost = EyeXHost.GetInstance();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Q)||Input.GetButtonUp("A"))
		{
			Debug.Log("Pressed");
			_eyexHost.TriggerActivation();
		}

	}

    void spawnFirefly()
    {
        firefly.SetActive(true);
		player.GetComponent<PlayerMovement> ().enabled = true;
		ml.enabled = true;
    }
}
