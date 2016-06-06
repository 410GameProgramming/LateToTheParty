using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public Sprite healthSprite;
    public Sprite nukeSprite;
    public Sprite shieldSprite;
    public float rad;
   
    private string type;
    private PlayerController player;
    private int price;
    public float dist;
    private Transform target;

    private bool display;


    // Use this for initialization
    void Start () {
        transform.Find("price").gameObject.GetComponent<MeshRenderer>().enabled = !transform.Find("price").gameObject.GetComponent<MeshRenderer>().enabled;
        target = GameManager.instance.player.transform;
        player = GameManager.instance.player.GetComponent<PlayerController>();
        int rng = Random.Range(1, 4);
	    if(rng == 1)
        {
            type = "health";
            
            GetComponent<SpriteRenderer>().sprite = healthSprite;
            transform.Find("price").gameObject.GetComponent<TextMesh>().text = "75";
            price = 75;

        }
        else if(rng == 2)
        {
            type = "nuke";
            GetComponent<SpriteRenderer>().sprite = nukeSprite;
            transform.Find("price").gameObject.GetComponent<TextMesh>().text = "100";
            price = 100;
        }
        else if(rng == 3)
        {
            type = "shield";
            GetComponent<SpriteRenderer>().sprite = shieldSprite;
            transform.Find("price").gameObject.GetComponent<TextMesh>().text = "50";
            price = 50;
        }
        
    }

    void Update()
    {
        
        dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < rad)
        {
            display = true;
        }else if (dist >= rad)
        {
            display = false;
        }
        transform.Find("price").gameObject.GetComponent<MeshRenderer>().enabled = display;

    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            if (price <= GameManager.instance.totalScore)
            {
                player.DoPickup(type);
                GameManager.instance.totalScore -= price;
                Destroy(gameObject);
            }
        }
        
    }
}