using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public Sprite healthSprite;
    public Sprite nukeSprite;
    public Sprite shieldSprite;

    private string type;
    private PlayerController player;
    private int price;

	// Use this for initialization
	void Start () {
      
        int rng = Random.Range(1, 4);
	    if(rng == 1)
        {
            type = "health";
            
            GetComponent<SpriteRenderer>().sprite = healthSprite;
        }else if(rng == 2)
        {
            type = "nuke";
            GetComponent<SpriteRenderer>().sprite = nukeSprite;
        }else if(rng == 3)
        {
            type = "shield";
            GetComponent<SpriteRenderer>().sprite = shieldSprite;
        }
        print(type);
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            player = GameManager.instance.player.GetComponent<PlayerController>();
            //player.pickup(type);
        }

    }
}
