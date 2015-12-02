using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public static Inventory _instance;
	public int keys;
	public int locks;
	public GameObject door;
	// Use this for initialization
		void Awake () 
	{
		
		if(_instance != null && _instance != this)
		{
			// If that is the case, we destroy other instances
			Destroy(gameObject);
		}
		
		
		_instance = this;
		
		DontDestroyOnLoad(gameObject);
		keys = 0;
		locks = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(keys==1)
		{
			Debug.Log("Yay keys");
		}
		if(locks==2)
		{
			StartCoroutine(door.GetComponent<DoorOpening>().Open());
			locks--;
		}

	}
}
