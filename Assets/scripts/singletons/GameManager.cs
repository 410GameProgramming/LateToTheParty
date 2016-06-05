/*
 * Pallab Mahmud
 * Date: 4/27/2016
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    [HideInInspector]
    public bool isGrounded;
    public int totalScore;
    public float blockSpeed;
    public PlayerController playerController;
    public GameObject player;
    public GameObject canvas;
    public int currentLevel;
    public Vector2[][] blockPositions;
    public float currentHealth;
    public float shield = 0.0f;
    public int nukeCount;
    public GameObject nukeEffect;
	public bool gameover;
    public bool godMode;

    void Awake () {
        if (instance == null){
            instance = this;
            initGame();
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        currentHealth = 100.0f;
        nukeCount = 1;
    }

    public Vector2[] getBlockPositions(int level)
    {
        if (level == 1)
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
                //left saw
                new Vector2(-6.5f,-6.5f), //left_saw
                //right saw
                new Vector2(6.3f, 6.3f), //right_saw
                new Vector2(-6.3f, -6.3f), //left hazzard still
                new Vector2(6.3f, 6.3f), //right hazzard still
                new Vector2(-6.3f, -6.3f), //left hazzard moving
                new Vector2(6.3f, 6.3f) //right hazzard moving
            };

        }
        else if (level == 2)
        {
            return new Vector2[]{
                //pattern1 
                new Vector2(-5f, 5f), //p1
                new Vector2(-5f, 5f), //p1
                new Vector2(-5f, 5f), //p1
                new Vector2(-5f, 5f), //p1
                //pattern3
                new Vector2(-4.5f, 4.5f), //p3
                //pattern2
                new Vector2(-5.5f, 5.5f), //p2
                //pattern3
                new Vector2(-4.5f, 4.5f), //p3
                //floaty
                new Vector2(-5.5f, 5.5f), //p2
                //pattern1 
                new Vector2(-5f, 5f), //p1
                new Vector2(-5f, 5f), //p1
                new Vector2(-5f, 5f), //p1
                //left saw
                new Vector2(-6.5f,-6.5f), //left_saw
                //right saw
                new Vector2(6.3f, 6.3f), //right_saw
                new Vector2(-6.3f, -6.3f), //left hazzard moving
                new Vector2(-6.3f, -6.3f), //left hazzard moving
                new Vector2(-6.3f, -6.3f), //left hazzard moving
                new Vector2(6.3f, 6.3f), //right hazzard still
                new Vector2(6.3f, 6.3f), //right hazzard still
                new Vector2(6.3f, 6.3f) //right hazzard still

            };
        }
        else if (level == 3)
        {
            return new Vector2[]{
                //pattern1 
                new Vector2(-5f, 5f), //p1
                //pattern3
                new Vector2(-4.5f, 4.5f), //p3
                //pattern2
                new Vector2(-5.5f, 5.5f), //p2
                //pattern1 
                new Vector2(-5f, 5f), //p1
                new Vector2(-5f, 5f), //p1
                new Vector2(-5f, 5f), //p1
                //pattern3
                new Vector2(-4.5f, 4.5f), //p3
                //pattern1 
                new Vector2(-5f, 5f), //p1
                new Vector2(-5f, 5f), //p1
                //left saw
                new Vector2(-6.5f,-6.5f), //left_saw
                //right saw
                new Vector2(6.3f, 6.3f), //right_saw

                new Vector2(-6.3f, -6.3f), //left hazzard moving
                new Vector2(-6.3f, -6.3f), //left hazzard moving
                new Vector2(6.3f, 6.3f), //right hazzard still
                new Vector2(6.3f, 6.3f) //right hazzard still
            };
        }
        else if (level == 4)
        {
            return new Vector2[]{

                //pattern2
                new Vector2(-5.5f, 5.5f), //p2
                //pattern1 
                new Vector2(-5f, 5f), //p1
                new Vector2(-5f, 5f), //p1
                new Vector2(-5f, 5f), //p1
                //pattern2
                new Vector2(-5.5f, 5.5f), //p2
                //pattern3
                new Vector2(-4.5f, 4.5f), //p3
                new Vector2(-4.5f, 4.5f), //p3
                new Vector2(-4.5f, 4.5f), //p3
                //pattern1 
                new Vector2(-5f, 5f), //p1

                //crusher
                new Vector2(0f,0f), //left_saw

                //left saw
                new Vector2(-6.5f,-6.5f), //left_saw
                //right saw
                new Vector2(6.3f, 6.3f), //right_saw

                new Vector2(-6.3f, -6.3f), //left hazzard moving
                new Vector2(-6.3f, -6.3f), //left hazzard moving
                new Vector2(6.3f, 6.3f), //right hazzard still
                new Vector2(6.3f, 6.3f) //right hazzard still

            };
        }
        else if (level == 5)
        {
            return new Vector2[]{
                //pattern2
                new Vector2(-5.5f, 5.5f), //p2
                //pattern1 
                new Vector2(-5f, 5f), //p1
                new Vector2(-5f, 5f), //p1
                new Vector2(-5f, 5f), //p1
                new Vector2(-5f, 5f), //p1
                new Vector2(-5f, 5f), //p1

                //pattern1 
                new Vector2(-5f, 5f), //p1
                //pattern3
                new Vector2(-4.5f, 4.5f), //p3
                new Vector2(-4.5f, 4.5f), //p3
                new Vector2(-4.5f, 4.5f), //p3
                new Vector2(-4.5f, 4.5f), //p3

                //crusher
                new Vector2(0f,0f), //left_saw

                //left saw
                new Vector2(-6.5f,-6.5f), //left_saw
                //right saw
                new Vector2(6.3f, 6.3f), //right_saw

                new Vector2(-6.3f, -6.3f), //left hazzard moving
                new Vector2(-6.3f, -6.3f), //left hazzard moving
                new Vector2(6.3f, 6.3f), //right hazzard still
                new Vector2(6.3f, 6.3f) //right hazzard still

            };
        }

        return new Vector2[]{new Vector2(-2.88f, 2.88f)};
    }
    public void initGame() {
        SceneManager.LoadScene("Title_Screen");
        nukeEffect = GameObject.Find("NukeEffect");
        nukeEffect.SetActive(false);
        isGrounded = false;
        totalScore = 0;
        blockSpeed = 1.5f;
        currentLevel = 0;
        player = GameObject.FindGameObjectWithTag("Player");
		gameover = false;
    }
    public void initAgain() {
        nukeEffect = GameObject.Find("NukeEffect");
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void GameOver() {
		gameover = true;
        SceneManager.LoadScene("YouWin");
		//UpdateHighScore ();
		/*
        if(totalScore > PlayerPrefs.GetInt("firstScore"))
        {
            PlayerPrefs.SetInt("thirdScore", PlayerPrefs.GetInt("secondScore"));
            PlayerPrefs.SetInt("secondScore", PlayerPrefs.GetInt("firstScore"));
            PlayerPrefs.SetInt("firstScore", totalScore);
        }else if(totalScore > PlayerPrefs.GetInt("secondScore")){
            PlayerPrefs.SetInt("thirdScore", PlayerPrefs.GetInt("secondScore"));
            PlayerPrefs.SetInt("secondScore", totalScore);
        }else if(totalScore > PlayerPrefs.GetInt("thirdScore"))
        {
            PlayerPrefs.SetInt("thirdScore", totalScore);
        }*/
    }

	public void UpdateHighScore() {
		if(totalScore > PlayerPrefs.GetInt("firstScore"))
		{
			PlayerPrefs.SetInt("thirdScore", PlayerPrefs.GetInt("secondScore"));
			PlayerPrefs.SetInt("secondScore", PlayerPrefs.GetInt("firstScore"));
			PlayerPrefs.SetInt("firstScore", totalScore);
		}else if(totalScore > PlayerPrefs.GetInt("secondScore")){
			PlayerPrefs.SetInt("thirdScore", PlayerPrefs.GetInt("secondScore"));
			PlayerPrefs.SetInt("secondScore", totalScore);
		}else if(totalScore > PlayerPrefs.GetInt("thirdScore"))
		{
			PlayerPrefs.SetInt("thirdScore", totalScore);
		}
	}

	public void ResetScore() {
		totalScore = 0;
	}
}