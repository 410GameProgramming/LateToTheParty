/*
 * Pallab Mahmud
 * Date: 4/27/2016
 */

using UnityEngine;
using System.Collections;

public class DestroyByHeight : MonoBehaviour {

    public float maxHeight;
	
	void Update () {
        if (transform.position.y > maxHeight)
        {
            Destroy(gameObject);
        }
	}
}
