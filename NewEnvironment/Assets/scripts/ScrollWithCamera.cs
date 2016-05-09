using UnityEngine;
using System.Collections;

public class ScrollWithCamera : MonoBehaviour {

	// Use this for initialization
    private GameObject cam;
    public float gap;
	// Update is called once per frame
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
	void Update () {
        transform.position = new Vector3(
            cam.transform.position.x,
            cam.transform.position.y-gap,
            0f
            );
	}
}
