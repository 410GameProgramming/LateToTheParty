using UnityEngine;
using System.Collections;

public class FloatyTopDetection : MonoBehaviour {

    private Floaty floaty;

    // Use this for initialization
    void Start()
    {

        floaty = GetComponentInParent<Floaty>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Projectile")
        {
            //print("death by bullet");
            floaty.Hit(2);

        }
        else if (col.tag == "Player")
        {
            //floaty.Hit(2);
            //print("Death by feet");
        }

    }
}
