using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreAtMenu : MonoBehaviour {

	private Text score;

	void Start () {
		score = gameObject.GetComponent<Text> ();
		score.text = "Score:\n" + GameManager.instance.totalScore.ToString ();
	}
}
