using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using System;

public class Gun : MonoBehaviour {
    public enum Weapon {
        Handgun,
        Spread,
        TripleShot,
        Shotgun,
        Rapid
    };
    public enum ShotInstance {
        firstShot,
        SecondShot,
        thirdShot
    };
    [HideInInspector]
    public int weapon;
    public Rigidbody2D bullet;
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float fireRate;
    public AudioClip shootSound;


    private PlayerController playerCtrl;       // Reference to the PlayerControl script.
    private float nextFire;
    private ShotInstance shotInstance;
    private AudioSource source;

    void Awake() {
        fireRate = 0.15f;
        playerCtrl = transform.root.GetComponent<PlayerController>();
        source = GetComponent<AudioSource>();
    }

    void Update() {
        speed = 15 + Math.Abs(2.0f * playerCtrl.rb2d.velocity.y);
    }

    void FixedUpdate() {
        weapon = (int)playerCtrl.weapon;
        Rigidbody2D bulletInstance;
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            source.PlayOneShot(shootSound);
            switch (weapon) {
                case 0:
                    fireRate = 0.2f;
                    nextFire = Time.time + fireRate;
                    bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                    bulletInstance.velocity = new Vector2(0, -speed);
                    break;
                case 1:
                    fireRate = 0.3f;
                    nextFire = Time.time + fireRate;
                    StartCoroutine(SpreadTimer());
                    break;
                case 2:
                    fireRate = 0.3f;
                    nextFire = Time.time + fireRate;
                    StartCoroutine(TriBulletTimer());
                    break;
                case 3:
                    fireRate = 0.25f;
                    nextFire = Time.time + fireRate;
                    StartCoroutine(ShotgunTimer());
                    break;
                case 4:
                    fireRate = 0.05f;
                    nextFire = Time.time + fireRate;
                    bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                    bulletInstance.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.0f, 1.0f, 0));
                    bulletInstance.velocity = new Vector2(0, -speed);
                    break;
            }
        }
    }

    IEnumerator SpreadTimer() {
        Rigidbody2D bulletInstance;
        for (shotInstance = 0; (int)shotInstance < 3; ++shotInstance) {
            switch (shotInstance) {
                case (ShotInstance.firstShot):
                    bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                    bulletInstance.velocity = new Vector2(0, -speed);
                    yield return new WaitForSeconds(0.01f);
                    break;
                case (ShotInstance.SecondShot):
                    bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                    bulletInstance.velocity = new Vector2(0.5f * speed, -speed);
                    yield return new WaitForSeconds(0.01f);
                    break;
                case (ShotInstance.thirdShot):
                    bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                    bulletInstance.velocity = new Vector2(0.5f * -speed, -speed);
                    yield return new WaitForSeconds(0.01f);
                    break;
            }
        }
    }

    IEnumerator TriBulletTimer() {
        Rigidbody2D bulletInstance;
        for (int i = 0; i < 3; ++i) {
            bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(0, -speed);
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator ShotgunTimer() {
        Rigidbody2D bulletInstance;
        for (int i = 0; i < 8; ++i) {
            bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(Random.Range(-speed, speed), -speed);
            yield return new WaitForSeconds(0.01f);
        }
    }
}