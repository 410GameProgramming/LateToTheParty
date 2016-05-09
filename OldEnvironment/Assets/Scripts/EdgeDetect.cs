using UnityEngine;
using System.Collections;

public class EdgeDetect : MonoBehaviour {

	private Enemy enemy;
    


    void Start ()
    {

        enemy = GetComponentInParent<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Obstacle") { 
            enemy.Flip();
            
        }
        else if(col.tag == "Player")
        {
            enemy.Hit();
            enemy.Flip();
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        
        //enemy.Flip();
    }


}
