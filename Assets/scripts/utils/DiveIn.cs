using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DiveIn : MonoBehaviour {

    void Update() {
        if (transform.position.y < -12) {
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel() {
        yield return new WaitForSeconds(2);
        GameManager.instance.currentLevel++;
        SceneManager.LoadScene(GameManager.instance.currentLevel);
    }
}