using UnityEngine;
using System.Collections;

public class ScoreLoader : MonoBehaviour {

    public string place;
    private int score;

	// Use this for initialization
	void Start () {
        score = PlayerPrefs.GetInt(place);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            transform.parent.Find("scoreDisplay").gameObject.GetComponent<TextMesh>().text = score.ToString();
            
        }
        print("TEEST");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            transform.parent.Find("scoreDisplay").gameObject.GetComponent<TextMesh>().text = " ";
        }
    }
}
