using UnityEngine;
using UnityEngine.SceneManagement;

public class DiveIn : MonoBehaviour {	
	void Update () {
        if (transform.position.y < -12)
        {
            SceneManager.LoadScene(1);
        }
	}
}
