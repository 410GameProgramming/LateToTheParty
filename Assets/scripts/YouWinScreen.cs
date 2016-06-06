using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YouWinScreen : MonoBehaviour {
	
	//public Text score;
	//public Text highscore;

	void Awake() {
		//score = gameObject.GetComponent<Text>();
		//highscore = gameObject.GetComponent<Text> ();
//		print (GameManager.instance.totalScore);
		//score.text = GameManager.instance.totalScore.ToString();
		if (!GameManager.instance.godMode) {
			GameManager.instance.UpdateHighScore ();
		}
		//highscore.text = PlayerPrefs.GetInt ("firstScore").ToString();
		//GameManager.instance.ResetScore ();
	}

	void Start() {
		GameManager.instance.ResetScore ();
		GameManager.instance.currentLevel = 0;
		GameManager.instance.currentHealth = 100.0f;
	}

	public void ReturnToTitleScreen() {
		SceneManager.LoadScene("Title_Screen");
	}
}


//transform.Find("scoreDisplay").gameObject.GetComponent<TextMesh>().text = GameManager.instance.totalScore.ToString();