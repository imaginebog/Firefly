using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class HealthManager : MonoBehaviour {

	public float initialHealth = 100F;
	public float damage = 20F;
	public float healing= 10F;

    public bool damageTaken= false;
    public bool fullHealth = false;

	//Snapshots

	public AudioMixerSnapshot music;
	public AudioMixerSnapshot normal;
	public AudioMixerSnapshot increased;
	public AudioMixerSnapshot af;


	private  float playerHealth;

	// Use this for initialization
	void Start () {
		playerHealth = initialHealth;
		InvokeRepeating("checkLightGaze", 5, 1);
	}

	//public void gazeLight(){
	//	lookingAtLight = true;
		//Debug.Log ("Light looked" + playerHealth+lookingAtLight);
	//}

	//public IEnumerator stopGazeLight(){
	//	lookingAtLight = false;
		//Debug.Log ("Light not looked" + playerHealth+lookingAtLight);
	//	yield return new WaitForSeconds(1);
	//}

	void  takeDamage()
	{
		if (playerHealth > 0F) {
			playerHealth -= damage;
            damageTaken = true;
			//Debug.Log ("DamageTaken" + playerHealth);
		}
	}

	void regainHealth()
	{
		if (playerHealth < initialHealth) {
			playerHealth += healing;
            fullHealth = true;
            //Debug.Log ("DamageHealthed" + playerHealth);
        } 

		if (playerHealth > initialHealth) {
			playerHealth = initialHealth;            
		}
	}

	void checkLightGaze()
	{

		bool lookingAtLight = false; 
		var objects = GameObject.FindGameObjectsWithTag("LightSource");
		var objectCount = objects.Length;
		foreach (var obj in objects) {
			bool hasGaze = obj.GetComponent<GazeAwareComponent>().HasGaze;
			if(hasGaze){
				regainHealth();
				lookingAtLight= true;
				break;
			}
		}

		if (!lookingAtLight) {
			takeDamage();
		}

		changeSoundSnapshot ();
	}

	void changeSoundSnapshot(){

		if (playerHealth >= 70) {
			music.TransitionTo (0.1f);
			//Debug.Log ("music" + playerHealth);
		} else if (playerHealth < 70 && playerHealth >= 50) {
			normal.TransitionTo (0.1f);
			//Debug.Log ("normal" + playerHealth);
		} else if (playerHealth < 50 && playerHealth >= 20) {
			//Debug.Log ("increased" + playerHealth);
			increased.TransitionTo (0.1f);
		}
		else {
			//Debug.Log ("af" + playerHealth);
			af.TransitionTo(0.1f);
		}

	}
}
