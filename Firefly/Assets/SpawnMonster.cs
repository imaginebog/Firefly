using UnityEngine;
using System.Collections;

public class SpawnMonster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		this.GetComponent<MeshRenderer>().enabled = true;
		this.GetComponent<AudioSource>().Play();
		StartCoroutine("changeLevel");
	}

	IEnumerator changeLevel()
	{
		yield return new WaitForSeconds(0.5f);
		Application.LoadLevel("Menu");
	}

}
