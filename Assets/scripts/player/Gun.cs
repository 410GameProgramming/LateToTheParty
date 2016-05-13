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
    [HideInInspector]
    public int weapon;
    public Rigidbody2D bullet;
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float fireRate;

    private PlayerController playerCtrl;       // Reference to the PlayerControl script.
    private Animator anim;					// Reference to the Animator component.
    private float nextFire;

    void Awake() {
        fireRate = 0.15f;
        anim = transform.root.gameObject.GetComponent<Animator>();
        playerCtrl = transform.root.GetComponent<PlayerController>();
    }

    void Update() {
        speed = 15 + Math.Abs(2.0f * playerCtrl.rb2d.velocity.y);
    }

    void FixedUpdate() {
        weapon = (int)playerCtrl.weapon;
        Rigidbody2D bulletInstance;
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            switch (weapon) {
                case 0:
                    fireRate = 0.5f;
                    nextFire = Time.time + fireRate;
                    bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                    bulletInstance.velocity = new Vector2(0, -speed);
                    break;
                case 1:
                    fireRate = 0.15f;
                    nextFire = Time.time + fireRate;
                    bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                    bulletInstance.velocity = new Vector2(0, -speed);
                    bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                    bulletInstance.velocity = new Vector2(0.5f * speed, -speed);
                    bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                    bulletInstance.velocity = new Vector2(0.5f * -speed, -speed);
                    break;
                case 2:
                    fireRate = 1.0f;
                    nextFire = Time.time + fireRate;
                    StartCoroutine(TriBulletTimer());
                    break;
                case 3:
                    fireRate = 2.0f;
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

    IEnumerator TriBulletTimer() {
        Rigidbody2D bulletInstance;
        for (int i = 0; i < 3; ++i) {
            bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(0, -speed);
            yield return new WaitForSeconds(0.1f);
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