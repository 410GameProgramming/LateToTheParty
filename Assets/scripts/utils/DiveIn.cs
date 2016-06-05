using UnityEngine;
using UnityEngine.SceneManagement;

public class DiveIn : MonoBehaviour {

    void Update() {
        if (transform.position.y < -9 && SceneManager.GetActiveScene().name == "level0") {
            LoadLevel();
        }
    }

    void LoadLevel() {
        GameManager.instance.currentLevel++;
        SceneManager.LoadScene(GameManager.instance.currentLevel);
    }
}