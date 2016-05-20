using UnityEngine;
using UnityEngine.UI;

public class WeaponImage : MonoBehaviour {
    public Image[] weapons;
    public Image current;

    void Awake() {
        current = gameObject.GetComponent<Image>();
    }

    public void SetImage(int index) {
        current.sprite = weapons[index].sprite;
    }
}