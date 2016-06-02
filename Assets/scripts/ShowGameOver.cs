using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowGameOver : MonoBehaviour {

	private Text gameovertext;

	void Start () {
		gameovertext = gameObject.GetComponent<Text> ();
		if (GameManager.instance.gameover) {
			gameovertext.text = "GAME OVER";
		}
	}
}
