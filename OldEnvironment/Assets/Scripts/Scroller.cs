/*
 * Pallab Mahmud
 * Date: 4/27/2016
 */
using UnityEngine;
using System.Collections;

public class Scroller : MonoBehaviour
{
    public float tileSizeZ;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (!GameManager.instance.isGrounded) // if the player is not grounded only then scroll
        {
            float newPosition = Mathf.Repeat(Time.time * GameManager.instance.scrollSpeed, tileSizeZ);
            transform.position = startPosition + new Vector3(0, 1, 0) * newPosition;
        }
    }
}