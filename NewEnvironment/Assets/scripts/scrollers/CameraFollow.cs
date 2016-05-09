using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;
    public GameObject player;
    public GameObject wall;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    public bool bounds;
    public bool freezeX;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        wall = GameObject.FindGameObjectWithTag("Wall");
    }

    

    void FixedUpdate(){
        //gradually changes a vector towards a desired goal over time
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
        transform.position = new Vector3(posX, posY, transform.position.z);


        float clampedX = Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x);
        if (!freezeX) { 
            clampedX = transform.position.x;
        }

        if (bounds){
            transform.position = new Vector3(clampedX,
                                             Mathf.Clamp(transform.position.y, -Mathf.Infinity, maxCameraPos.y), 
                                             Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z)
                                             );
        }

    }

}
