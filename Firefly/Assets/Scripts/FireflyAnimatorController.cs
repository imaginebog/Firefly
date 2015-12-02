using UnityEngine;
using System.Collections;

public class FireflyAnimatorController : MonoBehaviour {

    public Animator anim;
    public HealthManager hm;

    int RunAwayHash = Animator.StringToHash("RunAway");
    int UltimateRoomHash = Animator.StringToHash("UltimateDoor");
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        checkState();
	}

    void checkState()
    {
       if(anim != null) { 
        if(hm.fullHealth && hm.damageTaken)
            {
                anim.SetTrigger(RunAwayHash);
            }
        }
    }

    public void triggerLastRoom()
    {
        if (anim != null)
        {
			Debug.Log("Summoned");
            anim.SetTrigger(UltimateRoomHash);
        }
    }
}
