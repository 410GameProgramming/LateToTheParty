/*
 * Pallab Mahmud
 * Date: 4/27/2016
 */

using UnityEngine;

public class GameLoader : MonoBehaviour {
    public GameObject gameManager;
	void Awake () {
        if (GameManager.instance == null) {
            //Instantiate gameManager prefab
            Instantiate(gameManager);
        }
	}

    void OnLevelWasLoaded(int level) {
        GameManager.instance.initAgain();
        //print("Level: " + level);
    }
}