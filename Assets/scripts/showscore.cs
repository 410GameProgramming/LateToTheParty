using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class showscore : MonoBehaviour {
    public PlayerController playerController;

    void Start() {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        GameManager.instance.currentHealth = playerController.playerHealth.CurrentVal;
        GameManager.instance.shield = playerController.playerShield.CurrentVal;
        GameManager.instance.nukeCount = playerController.nukeCount;
        if (col.tag == "Player") {
            StartCoroutine(LoadLevel());
        }
	}

    IEnumerator LoadLevel() {
        if (playerController.undamaged) {
            GameManager.instance.totalScore += 100;
        }
        yield return new WaitForSeconds(1.5f);
        if (GameManager.instance.currentLevel == 5) {
			GameManager.instance.totalScore *= 2;
			SceneManager.LoadScene ("YouWin");
		} else {
			SceneManager.LoadScene ("level0");
		}
    }
}