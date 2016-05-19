using UnityEngine;
using System.Collections;

public class MoveVertical : MonoBehaviour {

    public int index;
    private Vector3 pos1;
    private Vector3 pos2;
    public float startY;
    public float minY;
    public float maxY;
    public float speed;


	void Start () {
        startY = transform.position.y; 
        //Vector2[] blockPositions = GameManager.instance.getBlockPositions();
        pos1 = new Vector3(transform.position.x, startY + minY, 0f);
        pos2 = new Vector3(transform.position.x, startY + maxY, 0f);
       

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
	}
}
