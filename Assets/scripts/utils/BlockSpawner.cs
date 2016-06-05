/*
 * Pallab Mahmud
 * Date: 4/27/2016
 */
using UnityEngine;
using System.Collections;

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
    public GameObject levelEndPlatform;
    public static bool levelEnded;
    public int totalNumOfBlocks = 100;

    private HealthBar levelProgress;
    void Start () {
        timer = delayTimer;
        rb2d = GameManager.instance.player.GetComponent<Rigidbody2D>();
        blockPositions = GameManager.instance.getBlockPositions(level);
        blockCount = 0;
        BlockSpawner.levelEnded = false;
        levelProgress = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<HealthBar>();
        levelProgress.maxValue = totalNumOfBlocks;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0 && blockCount<=totalNumOfBlocks && !GameManager.instance.isGrounded && rb2d.velocity.y<-7){
            //get a random pattern
            patternNumber = Random.Range(0, blocks.Length);
            print(blocks.Length - 1 + ": we picked: " + patternNumber);

            //            print(blocks.Length + "----Pat:" + patternNumber);
            //print(blockPositions[patternNumber].x);
            //print(patternNumber + "-" + GameManager.instance.blockPositions.Length);
            float newX = Random.Range(blockPositions[patternNumber].x,
                                      blockPositions[patternNumber].y);
            Vector3 blockPosition = new Vector3(newX, transform.position.y, transform.position.z);
            Instantiate(blocks[patternNumber], blockPosition, transform.rotation);
            blockCount++;
            levelProgress.Value = totalNumOfBlocks - blockCount;
            timer = delayTimer;
        }
	}

    IEnumerator createPlatform() {
        yield return new WaitForSeconds(3);
        if (BlockSpawner.levelEnded == false) {
            Instantiate(levelEndPlatform, transform.position, transform.rotation);
        }
        BlockSpawner.levelEnded = true;
    }
     
    void LateUpdate() {
        if (!BlockSpawner.levelEnded && blockCount > totalNumOfBlocks) {
            StartCoroutine(createPlatform());
        }
    }
}