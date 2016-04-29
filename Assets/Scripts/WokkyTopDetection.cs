using UnityEngine;
using System.Collections;

public class WokkyTopDetection : MonoBehaviour {

    private Enemy enemy;

	// Use this for initialization
	void Start () {

        enemy = GetComponentInParent<Enemy>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Projectile")
        {
            //print("death by bullet");
            enemy.Hit();

        }
        else if (col.tag == "Player")
        {
            enemy.Hit();
            //print("Death by feet");
        }

    }


}
