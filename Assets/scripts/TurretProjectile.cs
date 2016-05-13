using UnityEngine;
using System.Collections;

public class TurretProjectile : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        //print("Should be destroying");
        if(other.tag == "Ground" ||other.tag == "Player" ||other.tag == "Wall")
        {
            Destroy(gameObject);
        }
        
    }
}
