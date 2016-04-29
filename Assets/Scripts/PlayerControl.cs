using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, yMin, yMax;
}

public class PlayerControl : MonoBehaviour {
	[HideInInspector]
	public bool facingRight = true;         // For determining which way the player is currently facing.
    [HideInInspector]
    public bool jump;				// Condition for whether the player should jump.
    public bool falling;
    public Boundary boundary;

    public float speed;
	public float maxSpeed = 1.0f;				// The fastest the player can travel in the x axis.
	public float jumpForce = 50.0f;			// Amount of force added when the player jumps.
    public int ammo;
    public Transform groundCheck;           // A position marking where to check if the player is grounded.

    private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.
    private Gun.Weapon weapon;
    private int maxAmmo = 8;                // Starting max ammo;


    void Awake() {
        ammo = maxAmmo;
        weapon = Gun.Weapon.Handgun;
		groundCheck = transform.Find("groundCheck");
        //anim = GetComponent<Animator>();
    }

	void Update() {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (grounded) {
            GameManager.instance.isGrounded = true;
            ammo = maxAmmo;
            falling = false;
        }
        if (Input.GetButton("Fire1") && grounded) {
            jump = true;
            StartCoroutine(JumpTimer());
        }
        if(!grounded && !jump) {
            falling = true;
        }
        if (GameManager.instance.isGrounded) {
            StartCoroutine(ResumeScroll(jump, falling));
        }
    }

    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        GetComponent<Rigidbody2D>().velocity = movement * speed;

        GetComponent<Rigidbody2D>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax),
            0.0f
        );

        if (h > 0 && !facingRight) { // If the input is moving the player right and the player is facing left.
            Flip(); // flip the player.
        } else if (h < 0 && facingRight) { // Otherwise if the input is moving the player left and the player is facing right.
            Flip(); // flip the player.
        }
        if (jump) { // If the player should jump.
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            //jump = false; // Make sure the player can't jump again until the jump conditions from Update are satisfied.
        }
        if (falling) { // If the player is falling.
            //anim.SetTrigger("Falling"); // Set the Falling animator trigger parameter.
        }
	}
	
	void Flip () {
		facingRight = !facingRight; // Switch the way the player is labelled as facing.
        Vector3 theScale = transform.localScale; // Multiply the player's x local scale by -1.
        theScale.x *= -1;
		transform.localScale = theScale;
	}

    IEnumerator JumpTimer() {
        yield return new WaitForSeconds(0.7f);
        jump = false;
    }

    IEnumerator ResumeScroll(bool jump, bool falling) {
        if (jump) {
            yield return new WaitForSeconds(0.13f);
            GameManager.instance.isGrounded = false;
        }
        if (falling) {
            yield return new WaitForSeconds(0.1f);
            GameManager.instance.isGrounded = false;
        }
    }
}