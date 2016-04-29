/*
 * Pallab Mahmud
 * Date: 4/27/2016
 */
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    [HideInInspector]
    public bool isGrounded;
    public float scrollSpeed;
    public int totalScore;
	void Awake () {
        //Check if instance already exists
        if (instance == null){
            //if not, set instance to this
            instance = this;

        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        initGame();
	}

    void initGame() {
        isGrounded = false;
        scrollSpeed = 2.0f;
        totalScore = 0;
        //initialize all the variables here
    }
}