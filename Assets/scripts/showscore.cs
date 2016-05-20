using UnityEngine;
using UnityEngine.SceneManagement;

public class showscore : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			//gameObject.transform.Find ("scoreDisplay").GetComponent<TextMesh> ().text = GameManager.instance.totalScore;
			transform.Find("scoreDisplay").gameObject.GetComponent<TextMesh> ().text = GameManager.instance.totalScore.ToString();
            SceneManager.LoadScene("level0");
		}
	}
}