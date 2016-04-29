using UnityEngine;
using System.Collections;

public class TurretProjectile : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        //print("Should be destroying");
        Destroy(gameObject);
    }
}
