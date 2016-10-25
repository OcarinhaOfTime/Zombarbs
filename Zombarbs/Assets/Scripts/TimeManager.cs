using UnityEngine;
using System.Collections;

public enum DayState {
    Day,
    Dusk,
    Night,
    Dawn
}

public class TimeManager : MonoBehaviour {
    public float dayLenght = 10;
    public float nightIntensity = 0f;
    public float dayIntensity = 1f;
    public DayState currentDayState = DayState.Day;

    float dayThreshold = 1f / 3f;
    float duskThreshold = 1f / 2f;
    float nightThreshold = 5f / 6f;

    Light sun;    

    float startDayOffset;

    void Start() {
        sun = GetComponent<Light>();
        switch(currentDayState) {
            case DayState.Day:
                startDayOffset = 0;
                break;
            case DayState.Dusk:
                startDayOffset = dayThreshold;
                break;
            case DayState.Night:
                startDayOffset = duskThreshold;
                break;
            case DayState.Dawn:
                startDayOffset = nightThreshold;
                break;
        }
    }

    public void Update() {
        var t = Mathf.Repeat(startDayOffset + Time.time / dayLenght, 1);

        if(t < dayThreshold) {
            currentDayState = DayState.Day;
            sun.intensity = dayIntensity;
        }
        else if(t < duskThreshold) {
            currentDayState = DayState.Dusk;
            float delta = (t - dayThreshold) / (duskThreshold - dayThreshold);
            sun.intensity = nightIntensity + dayIntensity - delta * (dayIntensity - nightIntensity);
        }
        else if(t < nightThreshold) {
            currentDayState = DayState.Night;
            sun.intensity = nightIntensity;
        } else {
            currentDayState = DayState.Dawn;
            float delta = (t - nightThreshold) / (1 - nightThreshold);
            sun.intensity = nightIntensity + delta * (dayIntensity - nightIntensity);
        }
    }
}
