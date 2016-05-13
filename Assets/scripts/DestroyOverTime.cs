using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour {

    public float lifespan;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lifespan -= Time.deltaTime;

        if (lifespan < 0)
        {
            Destroy(gameObject);
        }
	}
}
