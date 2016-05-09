using UnityEngine;
using System.Collections;

public class WallScroller : MonoBehaviour {
    public GameObject player;
    public GameObject wall;
	public float tileSizeZ;
	private Vector3 startPosition;
    private Rigidbody2D rb2d;
    private PlayerController playerController;
    void Start()
    {
		startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        wall = GameObject.FindGameObjectWithTag("Wall");
        rb2d = player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!playerController.grounded && rb2d.velocity.y<-7)
        {
            float newPosition = (player.transform.position.y) + Mathf.Repeat(Time.deltaTime * rb2d.velocity.y, tileSizeZ);
            transform.position = startPosition + new Vector3(0, 1, 0) * newPosition;
        }

    }

}