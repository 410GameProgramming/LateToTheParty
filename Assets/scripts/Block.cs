using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	// Use this for initialization
    public int blockHealth = 5;
    public ParticleSystem crumble;
    public ParticleSystem destroy;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (blockHealth <= 0)
        {
            Instantiate(destroy, transform.position, transform.rotation);
            Destroy(gameObject.transform.parent.gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Projectile"))
        {
            blockHealth--;
            crumble.Play();
        }



    }

    /*
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Projectile"))
        {
            blockHealth--;
            crumble.Play();
        }
    }

    void OnCollision2D(Collider2D other){
        if (other.tag.Equals("Projectile"))
        {
            blockHealth--;
            crumble.Play();
        }
    }*/

}
