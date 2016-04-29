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

    public float maxPos;
    public float delayTimer = 1f;
    float timer;
	void Start () {
        timer = delayTimer;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0 && !GameManager.instance.isGrounded){
            Vector3 blockPosition = new Vector3(Random.Range(-maxPos, maxPos), transform.position.y, transform.position.z);
            patternNumber = Random.Range(0, 4);
            Instantiate(blocks[patternNumber], blockPosition, transform.rotation);
            timer = delayTimer;
        }
	}
}
