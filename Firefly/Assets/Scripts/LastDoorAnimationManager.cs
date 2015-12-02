using UnityEngine;
using System.Collections;

public class LastDoorAnimationManager : MonoBehaviour {


    public FireflyAnimatorController fac;

    void OnCollisionEnter(Collision col)
    {   
		Debug.Log("Colision");
        fac.triggerLastRoom();

    }
}
