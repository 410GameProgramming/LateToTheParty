using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Showscore : MonoBehaviour {
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
        yield return new WaitForSeconds(2);
        transform.Find("scoreDisplay").gameObject.GetComponent<TextMesh>().text = GameManager.instance.totalScore.ToString();
        SceneManager.LoadScene("level0");
    }
}