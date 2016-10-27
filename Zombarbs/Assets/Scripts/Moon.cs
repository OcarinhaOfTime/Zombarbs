using UnityEngine;
using System.Collections;

public class Moon : MonoBehaviour {
    Animator anim;
    Light l;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        TimeManager.instance.onDayChangeEnter.AddListener(DayChangeCallback);
        l = GetComponent<Light>();
        l.enabled = false;
    }

    void DayChangeCallback(DayState d, float t) {
        if(d == DayState.Dusk) {
            l.enabled = true;
            anim.SetTrigger("dusk");
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
