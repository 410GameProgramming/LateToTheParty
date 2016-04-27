/*
 * Pallab Mahmud
 * Date: 4/27/2016
 */
using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject.tag);
        Destroy(other.gameObject);
    }
}
