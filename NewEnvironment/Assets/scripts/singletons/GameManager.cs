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
    public int totalScore;
    public float blockSpeed;
    public int playerHealth;
    public GameObject player;
    public Vector2[] blockPositions = {
        new Vector2(-2.88f, 2.88f), //p1
        new Vector2(-2.88f, 2.88f), //p1
        new Vector2(-2.88f, 2.88f), //p1
        new Vector2(-3.4f, 3.4f), //p2
        new Vector2(-3.4f, 3.4f), //p2
        new Vector2(-3.4f, 3.4f), //p2
        new Vector2(-2.3f, 2.3f), //p3
        new Vector2(-2.3f, 2.3f), //p3
        new Vector2(-2.3f, 2.3f), //p3
        new Vector2(-2.88f, 2.88f), //p1
        new Vector2(-2.88f, 2.88f), //p1
        new Vector2(-2.88f, 2.88f), //p1
        new Vector2(-2.3f, 2.3f), //p3
        new Vector2(-2.3f, 2.3f), //p3
        new Vector2(-2.3f, 2.3f), //p3
        new Vector2(-2.88f, 2.88f), //block with wokky
        new Vector2(-2.88f, 2.88f) //floaty
        };
    
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
        totalScore = 0;
        playerHealth = 100;
        blockSpeed = 1.5f;
        player = GameObject.FindGameObjectWithTag("Player");
        //initialize all the variables here
    }
}