/*
 * Pallab Mahmud
 * Date: 4/27/2016
 */

using UnityEngine;
using System.Collections;

public class GameLoader : MonoBehaviour {
    public GameObject gameManager;
	void Awake () {
        if (GameManager.instance == null){
            //Instantiate gameManager prefab
            Instantiate(gameManager);
        }
	}
	
}