using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public string type;

    private PlayerController player;

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.tag == "Player")
        {
            GameManager.instance.player.GetComponent<PlayerController>();
            //player.pickup(type);
        }

    }
}
