using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour {

    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private Image Shield;

    public float maxValue { get; set; }
    public float Value {
        set {
            fillAmount = Map(value, 0, maxValue, 0, 1);
        }
    }

    void Start() {

    }

    void Update() {
        HandleBar();
    }

    private void HandleBar() {
        if (fillAmount != Shield.fillAmount) {
            Shield.fillAmount = fillAmount;
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax) {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}