using UnityEngine;
using System.Collections;

public class DestroyByCameraDistance : MonoBehaviour {

    private GameObject cam;
    private float distance = 25f;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
	
	void Update () {
        //if the distance between the camera and the object is too far, self destruct
        if ((cam.transform.position.y * -1) + transform.position.y > distance){
            Destroy(gameObject);
        }
	}
}
