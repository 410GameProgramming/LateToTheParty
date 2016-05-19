using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public string type;

    private PlayerController player;

    void OnTriggerStay2D(Collider2D col)
    {
        
        if(col.tag == "Player")
        {   
            //display price + "press q to purchase"

            GameManager.instance.player.GetComponent<PlayerController>();
            //player.pickup(type);
        }

    }
}
