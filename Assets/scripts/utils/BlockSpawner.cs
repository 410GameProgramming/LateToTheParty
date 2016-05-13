/*
 * Pallab Mahmud
 * Date: 4/27/2016
 */
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BlockSpawner : MonoBehaviour {

	// Use this for initialization
    public GameObject[] blocks;

    private int patternNumber;

    public float delayTimer = 1f;
    float timer;
    private Rigidbody2D rb2d;

    private Vector2[] blockPositions;
    private int blockCount;
    public int level;
    void Start () {
        timer = delayTimer;
        rb2d = GameManager.instance.player.GetComponent<Rigidbody2D>();
        blockPositions = GameManager.instance.getBlockPositions(level);
        blockCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0 && !GameManager.instance.isGrounded && rb2d.velocity.y<-7){
            //get a random pattern
            patternNumber = Random.Range(0, blocks.Length-1);
//            print(blocks.Length + "----Pat:" + patternNumber);
            //print(blockPositions[patternNumber].x);
            //print(patternNumber + "-" + GameManager.instance.blockPositions.Length);
            float newX = Random.Range(blockPositions[patternNumber].x,
                                      blockPositions[patternNumber].y);
            Vector3 blockPosition = new Vector3(newX, transform.position.y, transform.position.z);
            Instantiate(blocks[patternNumber], blockPosition, transform.rotation);
            blockCount++;
            timer = delayTimer;
        }
	}
    void LateUpdate(){
        if (blockCount > 100)
        {
            SceneManager.LoadScene(1);
        }
    }

}
