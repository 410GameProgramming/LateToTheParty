using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DiveIn : MonoBehaviour {

    void Update() {
        if (transform.position.y < -9) {
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel() {
        yield return new WaitForSeconds(1);
        GameManager.instance.currentLevel++;
        SceneManager.LoadScene(GameManager.instance.currentLevel);
    }
}