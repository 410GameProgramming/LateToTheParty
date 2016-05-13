using UnityEngine;
using System.Collections;

public class RotateBlade : MonoBehaviour {

    public float speed;
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);
	}
}
