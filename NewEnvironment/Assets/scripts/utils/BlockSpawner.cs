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



    void Start () {
        timer = delayTimer;
        rb2d = GameManager.instance.player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0 && !GameManager.instance.isGrounded && rb2d.velocity.y<-7){
            //get a random pattern
            patternNumber = Random.Range(0, blocks.Length);
            //print(patternNumber + "-" + GameManager.instance.blockPositions.Length);
            float newX = Random.Range(GameManager.instance.blockPositions[patternNumber].x, 
                                      GameManager.instance.blockPositions[patternNumber].y);
            Vector3 blockPosition = new Vector3(newX, transform.position.y, transform.position.z);
            Instantiate(blocks[patternNumber], blockPosition, transform.rotation);
            timer = delayTimer;
        }
	}
}
