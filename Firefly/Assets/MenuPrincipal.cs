using UnityEngine;
using System.Collections;

public class MenuPrincipal : MonoBehaviour {

	public GameObject text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Q)||Input.GetButtonUp("A"))
		{
			StartCoroutine("changeLevel");
		}
	}

	IEnumerator changeLevel()
	{
		float fadeTime = this.GetComponent<Fading>().BeginFade(1);
		Debug.Log("entro");
		text.SetActive(false);
		yield return new WaitForSeconds(0.1f);
		text.SetActive(true);
		yield return new WaitForSeconds(0.1f);
		text.SetActive(false);
		yield return new WaitForSeconds(0.1f);
		text.SetActive(true);
		yield return new WaitForSeconds(0.1f);
		text.SetActive(false);
		yield return new WaitForSeconds(0.1f);
		text.SetActive(true);
		yield return new WaitForSeconds(0.1f);
		text.SetActive(false);
		yield return new WaitForSeconds(1.5f);
		Application.LoadLevel("DemoScene");
	}
}
