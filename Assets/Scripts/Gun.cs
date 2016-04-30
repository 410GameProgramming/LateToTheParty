using UnityEngine;

public class Gun : MonoBehaviour {
    public enum Weapon {
        Handgun,
        Shotgun,
        Laser,
        Rocket
    };
    public int weapon = (int)Weapon.Handgun;
    public Rigidbody2D bullet;
    public float speed = 200f;				// Base projectile speed.
    public float fireRate;
    public AudioClip hitSound;

    private PlayerControl playerCtrl;		// Reference to the PlayerControl script.
	private Animator anim;					// Reference to the Animator component.
    private float nextFire;
    private AudioSource source;

    void Awake() {
        source = gameObject.GetComponent<AudioSource>();
        anim = transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<PlayerControl>();
	}

	void Update () {
        Rigidbody2D bulletInstance;
        if (Input.GetButton("Fire1") && playerCtrl.ammo != 0 && Time.time > nextFire && (playerCtrl.falling == true || playerCtrl.jump == true)) {
            nextFire = Time.time + fireRate;
            source.PlayOneShot(hitSound);
            switch (weapon) {
                case 0:
                    bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                    bulletInstance.velocity = new Vector2(0, -speed);
                    --playerCtrl.ammo;
                    break;
                case 1:
                    bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                    bulletInstance.velocity = new Vector2(0, speed);
                    --playerCtrl.ammo;
                    break;
                case 2:
                    bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                    bulletInstance.velocity = new Vector2(0, speed);
                    --playerCtrl.ammo;
                    break;
                case 3:
                    bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                    bulletInstance.velocity = new Vector2(0, speed);
                    --playerCtrl.ammo;
                    break;
            }
        }
	}
}