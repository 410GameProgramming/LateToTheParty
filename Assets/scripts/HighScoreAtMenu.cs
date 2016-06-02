using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreAtMenu : MonoBehaviour {

	private Text highscore;

	void Start () {
		highscore = gameObject.GetComponent<Text> ();
		highscore.text = "High Score:\n" + PlayerPrefs.GetInt ("firstScore").ToString ();
	}
}
