using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Clock : MonoBehaviour {
    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        float hours = (8 + TimeManager.instance.t * 24) % 24;
        float mins = (hours - Mathf.Floor(hours)) * 60;
        text.text = string.Format("{0:00}:{1:00}", hours, mins);
	}
}
