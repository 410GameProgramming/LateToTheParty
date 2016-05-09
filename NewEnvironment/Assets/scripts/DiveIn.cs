using UnityEngine;
using System.Collections;

public class DiveIn : MonoBehaviour {	
	void Update () {
        if (transform.position.y < -12)
        {
            Application.LoadLevel(0);
        }
	}
}
