using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour {
    public Text txtLevel;
	// Use this for initialization
    void Start () {
        StartCoroutine(loadLevel());
	}
	
	// Update is called once per frame
	IEnumerator loadLevel () {        
	    yield return new WaitForSeconds (1);
        GameManager.instance.currentLevel++;
        //print(GameManager.instance.currentLevel);
        SceneManager.LoadScene(GameManager.instance.currentLevel);
	}
    void Update()
    {
        txtLevel.text = "Level " + GameManager.instance.currentLevel;

    }
}
