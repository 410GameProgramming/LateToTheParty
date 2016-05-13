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
    public Vector2[][] blockPositions;
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


    public Vector2[] getBlockPositions()
    {
        if (currentLevel == 1)
        {
            return new Vector2[]{
                //pattern1 
                new Vector2(-5f, 5f), //p1
                new Vector2(-5f, 5f), //p1
                //pattern2
                new Vector2(-5.5f, 5.5f), //p2
                new Vector2(-5.5f, 5.5f), //p2
                //pattern3
                new Vector2(-4.5f, 4.5f), //p3
                new Vector2(-4.5f, 4.5f), //p3
                //pattern1 with spike
                new Vector2(-5f, 5f), //p1_spike
                //pattern2 with spike
                new Vector2(-4.5f, 4.5f), //p3_spike
                //pattern1 with wokky
                new Vector2(-5f, 5f), //p1_wokky
            };

        }
        return new Vector2[]{new Vector2(-2.88f, 2.88f)};
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