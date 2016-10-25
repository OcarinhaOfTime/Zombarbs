using UnityEngine;
using System.Collections;

public class DayNightCycleController : MonoBehaviour {
    public float dayLenght = 10;
    public float nightIntensity = 0f;
    public float dayIntensity = 1f;
    Light sun;

    void Start() {
        sun = GetComponent<Light>();
    }

    public void Update() {
        var t = Mathf.Repeat(Time.time / dayLenght, 1);

        if(t < .25f) {
            sun.intensity = dayIntensity;
        }
        else if(t < .5f) {
            sun.intensity = nightIntensity + dayIntensity - ((t - .25f) / .25f) * (dayIntensity - nightIntensity);
        }
        else if(t < .75f) {
            sun.intensity = nightIntensity;
        } else {
            sun.intensity = nightIntensity + ((t - .75f) / .25f) * (dayIntensity - nightIntensity);
        }
    }
}
