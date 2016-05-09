using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

    private int curHP;
    public int maxHP;


    public float fireFrequency;
    public float projectileSpeed;
    public float projectileTimer;
    public float wakeRad;
    public float dist;

    public bool awake = false;

    //private string location = "right";

    public GameObject projectile;
    public Transform target;
    private Animator anim;
    public Transform projectileSpawnLeft,
                     projectileSpawnRight,
                     projectileSpawnTop;


    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    void Start()
    {
        curHP = maxHP;
        //projectileSpawnLeft = transform.Find("leftSpawn").transform;
        //projectileSpawnRight = transform.Find("rightSpawn").transform;
        //projectileSpawnTop = transform.Find("topSpawn").transform;
    }

    void Update()
    {
        anim.SetBool("Awake", awake);
        WakeCheck();

    }

    void WakeCheck()
    {
        dist = Vector3.Distance(transform.position, target.transform.position);

        if (dist <= wakeRad)
        {
            awake = true;
        }
        if (dist > wakeRad)
        {
            awake = false;
        }

    }

    public void FireProjectile(string location)
    {
        projectileTimer += Time.deltaTime;
        if(projectileTimer >= fireFrequency)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            if(location == "top")
            {
                GameObject projectileInstance;
                projectileInstance = Instantiate(projectile, projectileSpawnTop.transform.position, projectileSpawnTop.transform.rotation) as GameObject;
                projectileInstance.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
                projectileTimer = 0;
            } else if(location == "right"){
                GameObject projectileInstance;
                projectileInstance = Instantiate(projectile, projectileSpawnRight.transform.position, projectileSpawnRight.transform.rotation) as GameObject;
                projectileInstance.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
                projectileTimer = 0;
            } else if(location == "left")
            {
                GameObject projectileInstance;
                projectileInstance = Instantiate(projectile, projectileSpawnLeft.transform.position, projectileSpawnLeft.transform.rotation) as GameObject;
                projectileInstance.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
                projectileTimer = 0;

            }


        }


    }
}
