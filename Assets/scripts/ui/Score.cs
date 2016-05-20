using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private Text score;

    void Start() {
        score = gameObject.GetComponent<Text>();
    }
    void Update() {
        score.text = GameManager.instance.totalScore.ToString();
    }
}