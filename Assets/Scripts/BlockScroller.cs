/*
 * Pallab Mahmud
 * Date: 4/27/2016
 */
using UnityEngine;
using System.Collections;

public class BlockScroller : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            GameManager.instance.isGrounded = true;
        }

    }
	// Update is called once per frame
	void Update () {
        if (!GameManager.instance.isGrounded) {
            transform.transform.Translate(new Vector3(0, 1, 0) * GameManager.instance.scrollSpeed * Time.deltaTime);
        }
	}
}