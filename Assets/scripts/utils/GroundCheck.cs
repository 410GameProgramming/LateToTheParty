using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {
    private PlayerController player;
    void Start(){
        player = gameObject.GetComponentInParent<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D col){
        player.grounded = true;
        GameManager.instance.isGrounded = true;
    }

    void OnTriggerStay2D(Collider2D col){
        player.grounded = true;
        GameManager.instance.isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D col){
        player.grounded = false;
        GameManager.instance.isGrounded = false;
    }

}
