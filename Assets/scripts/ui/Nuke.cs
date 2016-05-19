using UnityEngine;

public class Nuke : MonoBehaviour {
    public void ShowNuke() {
        gameObject.SetActive(true);
    }

    public void HideNuke() {
        gameObject.SetActive(false);
    }
}