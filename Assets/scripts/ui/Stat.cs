using UnityEngine;
using System;

[Serializable]
public class Stat {
    [SerializeField]
    private HealthBar health;
    [SerializeField]
    private float maxVal;
    [SerializeField]
    private float currentVal;

    public float CurrentVal {
        get {
            if (currentVal > maxVal) {
                currentVal = maxVal;
            }
            return currentVal;
        }

        set {
            currentVal = value;
            health.Value = currentVal;
        }
    }

    public float MaxVal {
        get {
            return maxVal;
        }

        set {
            maxVal = value;
            health.maxValue = maxVal;
        }
    }

    public void Initialize() {
        MaxVal = maxVal;
        CurrentVal = currentVal;
    }
}
