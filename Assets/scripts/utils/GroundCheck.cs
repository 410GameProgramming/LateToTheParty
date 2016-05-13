using UnityEngine;

public class GroundCheck : MonoBehaviour {
    private PlayerController player;
    void Start(){
        player = gameObject.GetComponentInParent<PlayerController>();
    }

    void Update() {
        player.grounded = Physics2D.Linecast(player.transform.position, player.groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (player.grounded) {
            GameManager.instance.isGrounded = true;
        } else {
            GameManager.instance.isGrounded = false;
        }
    }
}