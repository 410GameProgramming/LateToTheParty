using UnityEngine;
using System.Collections;

public class MoveHorizontal : MonoBehaviour {

    public int index;
    private Vector3 pos1;
    private Vector3 pos2;
    public float minX;
    public float maxX;
    public float speed;

	void Start () {
        //Vector2[] blockPositions = GameManager.instance.getBlockPositions();
        pos1 = new Vector3(minX, transform.position.y, 0f);
        pos2 = new Vector3(maxX, transform.position.y, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
	}
}
