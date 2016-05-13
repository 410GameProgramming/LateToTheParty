using UnityEngine;
using System.Collections;

public class MoveBlock : MonoBehaviour {

    public int index;
    private Vector3 pos1;
    private Vector3 pos2;

	void Start () {
        //Vector2[] blockPositions = GameManager.instance.getBlockPositions();
        pos1 = new Vector3(-4f, transform.position.y, 0f);
        pos2 = new Vector3(4f, transform.position.y, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(GameManager.instance.blockSpeed * Time.time) + 1.0f) / 2.0f);
	}
}
