using UnityEngine;

public class Bullet : MonoBehaviour {
	void Start () {
		// Destroy the rocket after 2 seconds if it doesn't get destroyed before then.
		Destroy(gameObject, 2);
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if(col.tag == "Enemy") {
			Destroy (gameObject);
		}
		if(col.tag == "solid block") {
			Destroy (gameObject);
		} else if(col.gameObject.tag != "Player") {
			Destroy (gameObject);
		}
	}
}
