using UnityEngine;
using System.Collections;

public class Floaty : MonoBehaviour {

    public float range;
    public float speed;
    public float dist;
    public int health;
    public int burstSize;
    public int type;

    public float fireFrequency;
    public float projectileSpeed;
    public float projectileTimer;

    public ParticleSystem deathFX;

    public GameObject projectile;
    private Transform target;
    public Transform projectileSpawn;

    private bool alternate = true;

    // Use this for initialization
    void Start () {
        target = GameManager.instance.player.transform;
	}
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < range)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (health <= 0)
        {
            GameManager.instance.totalScore += 20;
            Instantiate(deathFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (dist <= range)
        {
            //print("about to fire");
            FireProjectile();
        }
    }

    public void Hit(int dmg)
    {
        health -= dmg;
    }

    void FireProjectile()
    {
        //print("in the fire method");
        projectileTimer += Time.deltaTime;
        if (projectileTimer >= fireFrequency)
        {
            if (type == 1) {
                FireSingle();
            }
            else if(type == 2)
            {
                FireCardinals();
            }
            else if (type == 3)
            {
                if (alternate)
                {
                    FireCardinals();
                }else
                {
                    FireDiagonals();
                }
            }
            else if(type == 4)
            {
                FireBurst(target.transform.position - transform.position);
            }


        }

    }
    IEnumerator FireBurst(Vector2 dir)
    {
        for (int i = 0; i < burstSize; i++)
        {
            GameObject projectileInstance;
            projectileInstance = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation) as GameObject;
            projectileInstance.GetComponent<Rigidbody2D>().velocity = dir * projectileSpeed;

            yield return new WaitForSeconds(.2f);
        }
    }
    void FireSingle()
    {
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();

        GameObject projectileInstance;
        projectileInstance = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation) as GameObject;
        projectileInstance.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

        projectileTimer = 0;

        return;
    }
    void FireCardinals()
    {
        Vector3[] directions = new Vector3[4];
        directions[0] = Vector3.left;
        directions[1] = Vector3.up;
        directions[2] = Vector3.right;
        directions[3] = Vector3.down;

        for (int i = 0; i < 4; i++)
        {
            GameObject projectileInstance;
            projectileInstance = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation) as GameObject;
            projectileInstance.GetComponent<Rigidbody2D>().velocity = directions[i] * projectileSpeed;
        }
        alternate = !alternate;
        projectileTimer = 0;
        return;
    }
    void FireDiagonals()
    {
        Vector3[] directions = new Vector3[4];
        directions[0] = new Vector3(1, 1, 0).normalized;
        directions[1] = new Vector3(-1, 1, 0).normalized;
        directions[2] = new Vector3(-1, -1, 0).normalized;
        directions[3] = new Vector3(1, -1, 0).normalized;

        for (int i = 0; i < 4; i++)
        {
            GameObject projectileInstance;
            projectileInstance = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation) as GameObject;
            projectileInstance.GetComponent<Rigidbody2D>().velocity = directions[i] * projectileSpeed;
        }
        alternate = !alternate;
        projectileTimer = 0;
    }



}
