using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YouWinScreen : MonoBehaviour {

	public Text score;
	public Text highscore;
	/*
	void Start() {
		score = gameObject.GetComponent<Text>();
		highscore = gameObject.GetComponent<Text> ();
		score.text = "Score:\n" + GameManager.instance.totalScore;
		highscore.text = "High Score:\n" + PlayerPrefs.GetInt ("firstScore");
	}
	*/
	public void ReturnToTitleScreen() {
		SceneManager.LoadScene("Title_Screen");
	}
}
