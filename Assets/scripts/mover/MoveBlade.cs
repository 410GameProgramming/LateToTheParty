using UnityEngine;
using System.Collections;

public class MoveBlade : MonoBehaviour {

    public float minVal;
    public float maxVal;
    private Vector3 pos1;
    private Vector3 pos2;
    public float speed;
    public bool alongX = true;
    public bool alongY = false;

	void Start () {
        if (alongX){
            pos1 = new Vector3(minVal, transform.localPosition.y, 0f);
            pos2 = new Vector3(maxVal, transform.localPosition.y, 0f);
        }
        else if (alongY){
            pos1 = new Vector3(transform.localPosition.x, minVal, 0f);
            pos2 = new Vector3(transform.localPosition.x, maxVal, 0f);
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
	}
}
