using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 50f;
    public float jumpPower = 200f;
    public bool grounded;
    public bool undamaged;
    public float maxSpeed = 3;
    public Gun.Weapon weapon;
    public Rigidbody2D rb2d;
    public Stat playerHealth;
    public Stat playerShield;
    public int nukeCount;
    public int weaponUnlock;
    public Transform groundCheck;
    public AudioClip hurtSound;
    public AudioClip jumpSound;
    public AudioClip landSound;
    public WeaponImage weaponImage;

    private GameObject[] blocks;
    private GameObject[] enemies;
    private GameObject shieldImage;
    private Nuke nuke;
    private SpriteRenderer sprite;
    private Animator anim;
    private bool damaged = false;
    private float maxVelocityY = 20.0f;
    private AudioSource source;

    private void Awake() {
        playerHealth.Initialize();
        playerShield.Initialize();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        nuke = GameObject.Find("Nuke").GetComponent<Nuke>();
        weaponUnlock = 0;
        undamaged = true;
    }

    void Start () {
        weapon = Gun.Weapon.Handgun;
        playerHealth.CurrentVal = GameManager.instance.currentHealth;
        playerShield.CurrentVal = GameManager.instance.shield;
        shieldImage = GameObject.Find("PlayerShield");
        nukeCount = GameManager.instance.nukeCount;
        if (nukeCount > 1) {
            nukeCount = 1;
        }
        weaponImage = GameObject.Find("Weapon").GetComponent<WeaponImage>();
    }
	
	void Update () {
        CheckIfGameOver();
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        if (GameManager.instance.currentLevel == 2) {
            weaponUnlock = 1;
        } else if (GameManager.instance.currentLevel == 3) {
            weaponUnlock = 2;
        } else if (GameManager.instance.currentLevel == 4) {
            weaponUnlock = 3;
        } else if (GameManager.instance.currentLevel == 5) {
            weaponUnlock = 4;
        }
        if (Input.GetButtonDown("Fire2")) {
            if ((int)weapon < weaponUnlock) {
                ++weapon;
                weaponImage.SetImage((int)weapon);
            } else {
                weapon = 0;
                weaponImage.SetImage((int)weapon);
            }
        }
        if (nukeCount > 0) {
            nuke.ShowNuke();
        } else {
            nuke.HideNuke();
        }
        if (Input.GetKeyDown(KeyCode.N) && nukeCount > 0 && SceneManager.GetActiveScene().name != "level0") {
            LaunchNuke();
        }
        if (Input.GetAxis("Horizontal") < -0.1f){
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") > 0.1f){
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetButtonDown("Jump") && grounded){
            source.PlayOneShot(jumpSound);
            rb2d.AddForce(Vector2.up * jumpPower);
        }
        if (Input.GetKeyDown(KeyCode.Q) && GameManager.instance.godMode) {
            playerHealth.CurrentVal -= 10;
            GameManager.instance.currentHealth = playerHealth.CurrentVal;
        }
        if (Input.GetKeyDown(KeyCode.W) && GameManager.instance.godMode) {
            playerHealth.CurrentVal += 10;
            GameManager.instance.currentHealth = playerHealth.CurrentVal;
        }
        if (playerShield.CurrentVal > 0) {
            shieldImage.SetActive(true);
        } else {
            shieldImage.SetActive(false);
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
        if (!damaged && !GameManager.instance.godMode) {
            if (col.tag == "Attack") {
                source.PlayOneShot(hurtSound);
                if (System.Math.Abs(rb2d.velocity.y) > 0.0f) {
                    Vector3 newVelocity = rb2d.velocity.normalized;
                    newVelocity *= 0.0f;
                    rb2d.velocity = newVelocity;
                }
                rb2d.AddForce((Vector2.up * 350));
                if (playerShield.CurrentVal > 0) {
                    playerShield.CurrentVal -= 1;
                }
                else {
                    playerHealth.CurrentVal -= 10;
                    undamaged = false;
                }
                sprite.color = Color.red;
            } else if (col.tag == "EnemyProjectile") {
                source.PlayOneShot(hurtSound);
                if (playerShield.CurrentVal > 0) {
                    playerShield.CurrentVal -= 1;
                } else {
                    playerHealth.CurrentVal -= 5;
                    undamaged = false;
                }
                sprite.color = Color.red;
            }
            damaged = true;
            source.PlayOneShot(landSound);
            StartCoroutine(Invulnerability());
        }
    }

    private void LaunchNuke() {
        GameManager.instance.nukeEffect.SetActive(true);
        Color nukeColor = GameManager.instance.nukeEffect.GetComponent<Image>().color;
        StartCoroutine(FadeIn(nukeColor));
        blocks = GameObject.FindGameObjectsWithTag("Ground");
        enemies = GameObject.FindGameObjectsWithTag("Attack");
        foreach (GameObject block in blocks) {
            Destroy(block);
        }
        foreach (GameObject enemy in enemies) {
            Destroy(enemy);
        }
        --nukeCount;
    }

    public IEnumerator FadeIn(Color nukeColor) {
        float elapsedTime = 0.0f;
        float totalTime = 1.0f;
        while (elapsedTime < totalTime) {
            elapsedTime += Time.deltaTime;
            GameManager.instance.nukeEffect.GetComponent<Image>().color = Color.Lerp(nukeColor, new Color(1, 1, 1, 0.8f), elapsedTime);
            yield return null;
        }
        nukeColor = GameManager.instance.nukeEffect.GetComponent<Image>().color;
        StartCoroutine(FadeOut(nukeColor));
    }

    public IEnumerator FadeOut(Color nukeColor) {
        float elapsedTime = 0.0f;
        float totalTime = 1.0f;
        while (elapsedTime < totalTime) {
            elapsedTime += Time.deltaTime;
            GameManager.instance.nukeEffect.GetComponent<Image>().color = Color.Lerp(nukeColor, new Color(1, 1, 1, 0), elapsedTime);
            yield return null;
        }
        GameManager.instance.nukeEffect.SetActive(false);
    }

    public void DoPickup(string type) {
        if (type.Equals("health")) {
            playerHealth.CurrentVal = playerHealth.MaxVal;
            GameManager.instance.currentHealth = playerHealth.MaxVal;
        }
        else if (type.Equals("nuke")) {
            ++nukeCount;
        }
        else if (type.Equals("shield")) {
            playerShield.CurrentVal = playerShield.MaxVal;
            GameManager.instance.shield = playerShield.CurrentVal;
        }
    }

    IEnumerator Invulnerability() {
        yield return new WaitForSeconds(1.3f);
        sprite.color = Color.white;
        damaged = false;
    }

    private void CheckIfGameOver() {
        if (playerHealth.CurrentVal <= 0) {
            GameManager.instance.GameOver();
        }
    }
}