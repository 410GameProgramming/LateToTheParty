using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DiveIn : MonoBehaviour {

//    private ScreenFader screenFader;
    void Start()
    {
//        screenFader = GameObject.FindGameObjectWithTag("ScreenFader").GetComponent<ScreenFader>();
    }

    void Update() {
        if (transform.position.y < -9) {
  //          StartCoroutine(screenFader.FadeOut());
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel() {
        yield return new WaitForSeconds(1);
        GameManager.instance.currentLevel++;
        SceneManager.LoadScene(GameManager.instance.currentLevel);
    }
}