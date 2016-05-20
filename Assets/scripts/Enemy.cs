using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float speed= 5f;
    public float maxSpeed = 3;
    public AudioClip hitSound;
    public ParticleSystem deathFX;

    public float fireFrequency;
    public float projectileSpeed;
    public float projectileTimer;
    public float rad;
    public float dist;
    public int burstSize;

    public GameObject projectile;
    private Transform target;
    public Transform projectileSpawn;

  
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
        //scoreText = GameObject.Find("scoreText").GetComponent<Text>();
        target = GameManager.instance.player.transform;

    }
	
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(speed));

        dist = Vector3.Distance(transform.position, target.transform.position);

        if (dist <= rad)
        {
            //print("about to fire");
            FireProjectile();
        }
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
        source.PlayOneShot(hitSound);
        Instantiate(deathFX, transform.position, transform.rotation);        
        Destroy(gameObject);
        GameManager.instance.totalScore += 10;
        //displayScore();
    }
    /*
    private void displayScore(){
        scoreText.text = "Score: " + GameManager.instance.totalScore;
    }*/
    public void Flip()
    {
        speed = -speed;
        //print("flip\n");
        //print(speed);
        if (speed < 1)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 0);
        }
        else
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 0);
        }
    }

    void FireProjectile()
    {
        //print("in the fire method");
        projectileTimer += Time.deltaTime;
        if (projectileTimer >= fireFrequency)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            /*if (location == "top")
            {
                GameObject projectileInstance;
                projectileInstance = Instantiate(projectile, projectileSpawnTop.transform.position, projectileSpawnTop.transform.rotation) as GameObject;
                projectileInstance.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
            */
            StartCoroutine(FireBurst(direction));
            projectileTimer = 0;
            
            

        }

    }

    IEnumerator FireBurst(Vector2 dir)
    {
        for(int i = 0; i < burstSize; i++)
        {
            GameObject projectileInstance;
            projectileInstance = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation) as GameObject;
            projectileInstance.GetComponent<Rigidbody2D>().velocity = dir * projectileSpeed;

            yield return new WaitForSeconds(.2f);
        }
    }
}
