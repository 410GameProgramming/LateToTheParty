using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float speed= 5f;
    public float maxSpeed = 3;
    public AudioClip hitSound;
    public ParticleSystem deathFX;

    private Rigidbody2D rb2d;
    private Animator anim;
    //private Transform frontCheck;
    private AudioSource source;
    private Text scoreText;
    // Use this for initialization
    void Start () {
        source = gameObject.GetComponent<AudioSource>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();      
        scoreText = GameObject.Find("scoreText").GetComponent<Text>();
    }
	
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(speed));

    }
	// Update is called once per frame
	void FixedUpdate () {

        

        // Check each of the colliders.
       

        Vector2 movement = new Vector2(1, 0);
        rb2d.AddForce(movement * speed);

        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

    }

    public void Hit()
    {
        Instantiate(deathFX, transform.position, transform.rotation);        
        Destroy(gameObject);
        GameManager.instance.totalScore += 5;
        displayScore();
    }

    private void displayScore(){
        scoreText.text = "Score: " + GameManager.instance.totalScore;
    }
    public void Flip()
    {
        speed = -speed;
        //print("flip\n");
        //print(speed);
        if (speed < 1)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
    }
}
