using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelText : MonoBehaviour {

	// Use this for initialization
    //Text levelText;
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "level " + GameManager.instance.currentLevel;
	}
}
