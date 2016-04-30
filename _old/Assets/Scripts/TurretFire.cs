using UnityEngine;
using System.Collections;

public class TurretFire : MonoBehaviour {

    private Turret turret;
    public string location; 

	void Awake()
    {
        turret = gameObject.GetComponentInParent<Turret>();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            {

            turret.FireProjectile(location);

            }
    }
}
