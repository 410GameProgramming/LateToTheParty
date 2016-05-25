using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;
    private GameObject player;
    private GameObject wall;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    public bool bounds;
    public bool freezeX;
    public bool keepPlayerAtTop = true;
	void Start () {
        wall = GameObject.FindGameObjectWithTag("Wall");
        player = GameManager.instance.player;
    }

    

    void FixedUpdate(){
        //gradually changes a vector towards a desired goal over time

        float diff = 0f;
        if (keepPlayerAtTop)
        {
            diff = 7f;
        }
        float posX = Mathf.SmoothDamp(transform.position.x, 
            GameManager.instance.player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y,
            GameManager.instance.player.transform.position.y-diff, ref velocity.y, smoothTimeY);
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
