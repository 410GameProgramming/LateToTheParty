/*
 * Pallab Mahmud
 * Date: 4/27/2016
 */
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    [HideInInspector]
    public bool isGrounded;
    public int totalScore;
    public float blockSpeed;
    public GameObject player;
    public int currentLevel;
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
        new Vector2(-2.88f, 2.88f), //block with wokky
        new Vector2(-2.88f, 2.88f) //floaty
    };

    void Awake () {
        //Check if instance already exists
        if (instance == null){
            //if not, set instance to this
            instance = this;
            initGame();
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    public void initGame() {
        isGrounded = false;
        totalScore = 0;
        blockSpeed = 1.5f;
        currentLevel = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        //initialize all the variables here
    }

    public void GameOver() {
        SceneManager.LoadScene("game_over");
    }
}