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
		if (GameManager.instance.currentLevel == 2) {
			SceneManager.LoadScene ("YouWin");
		} else {
			SceneManager.LoadScene ("level0");
		}
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("level0");
    }
}