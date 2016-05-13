using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //public variables
    public float speed = 50f;
    public float jumpPower = 150f;
    public bool grounded;
    public float maxSpeed = 3;
    public Gun.Weapon weapon;
    public Rigidbody2D rb2d;
    public Stat playerHealth;
    public Transform groundCheck;

    //private variables 
    private SpriteRenderer sprite;
    private Animator anim;
    private bool damaged = false;
    private float maxVelocityY = 20.0f;

    private void Awake() {
        playerHealth.Initialize();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Start () {
        playerHealth.MaxVal = 100;
        weapon = Gun.Weapon.Handgun;
	}
	
	void Update () {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        if (Input.GetButtonDown("Fire2")) {
            if ((int)weapon < 4) {
                ++weapon;
            } else {
                weapon = 0;
            }
        }

        if (Input.GetAxis("Horizontal") < -0.1f){
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") > 0.1f){
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetButtonDown("Jump") && grounded){
            rb2d.AddForce(Vector2.up * jumpPower);
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            playerHealth.CurrentVal -= 10;
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            playerHealth.CurrentVal += 10;
        }
    }

    void FixedUpdate(){
    	if (System.Math.Abs(rb2d.velocity.y) > maxVelocityY) {
            Vector3 newVelocity = rb2d.velocity.normalized;
            newVelocity *= maxVelocityY;
            rb2d.velocity = newVelocity;
        }
        Vector3 easeVelocity = rb2d.velocity;
        //easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        //moving the Player
        float moveX = Input.GetAxis("Horizontal");

        //fake frinction/ easing the x speed of our player
        if (grounded){
            rb2d.velocity = easeVelocity;
        }
        rb2d.AddForce((Vector2.right * speed) * moveX);

        //liimting the speed accross X axis
        
        if (rb2d.velocity.x > maxSpeed){
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed){
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (!damaged) {
            if (col.tag == "Attack") {
                if (System.Math.Abs(rb2d.velocity.y) > 0.0f) {
                    Vector3 newVelocity = rb2d.velocity.normalized;
                    newVelocity *= 0.0f;
                    rb2d.velocity = newVelocity;
                }
                rb2d.AddForce((Vector2.up * 350));
                playerHealth.CurrentVal -= 10;
                sprite.color = Color.red;
            }
            damaged = true;
            StartCoroutine(Invulnerability());
        }
    }

    /*void OnTriggerStay2D(Collider2D col) {
        if (!damaged) {
            if (col.tag == "Attack") {
                if (System.Math.Abs(rb2d.velocity.y) > 0.0f) {
                    Vector3 newVelocity = rb2d.velocity.normalized;
                    newVelocity *= 0.0f;
                    rb2d.velocity = newVelocity;
                }
                rb2d.AddForce((Vector2.up * 350));
                playerHealth.CurrentVal -= 10;
                sprite.color = Color.red;
            }
            damaged = true;
            StartCoroutine(Invulnerability());
        }
    }*/

    IEnumerator Invulnerability() {
        yield return new WaitForSeconds(1.3f);
        sprite.color = Color.white;
        damaged = false;
    }
}