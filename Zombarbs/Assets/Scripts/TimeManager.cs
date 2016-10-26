using UnityEngine;
using UnityEngine.Events;

public enum DayState {
    Day,
    Dusk,
    Night,
    Dawn
}
[System.Serializable]
public class TimeEvent : UnityEvent<DayState, float> { }

public class TimeManager : MonoBehaviour {
    public static TimeManager instance;
    public float dayLenght = 10;
    public float nightIntensity = 0f;
    public float dayIntensity = 1f;
    public DayState currentDayState = DayState.Day;
    public TimeEvent onDayChangeEnter = new TimeEvent();
    public TimeEvent onDayChangeExit = new TimeEvent();

    [HideInInspector]
    public float t;

    float dayThreshold = 1f / 3f;
    float duskThreshold = 1f / 2f;
    float nightThreshold = 5f / 6f;

    Light sun;
    float startDayOffset;

    void Awake() {
        instance = this;
    }

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
        t = Mathf.Repeat(startDayOffset + Time.time / dayLenght, 1);

        if(t < dayThreshold) {
            OnDayChange(DayState.Day, t);
            sun.intensity = dayIntensity;
        }
        else if(t < duskThreshold) {
            OnDayChange(DayState.Dusk, t);
            float delta = (t - dayThreshold) / (duskThreshold - dayThreshold);
            sun.intensity = nightIntensity + dayIntensity - delta * (dayIntensity - nightIntensity);
        }
        else if(t < nightThreshold) {
            OnDayChange(DayState.Night, t);
            sun.intensity = nightIntensity;
        } else {
            OnDayChange(DayState.Dawn, t);
            float delta = (t - nightThreshold) / (1 - nightThreshold);
            sun.intensity = nightIntensity + delta * (dayIntensity - nightIntensity);
        }
    }

    void OnDayChange(DayState state, float t) {
        if(state != currentDayState) {
            onDayChangeEnter.Invoke(state, t);
            onDayChangeExit.Invoke(currentDayState, t);
            currentDayState = state;
        }
    }
}