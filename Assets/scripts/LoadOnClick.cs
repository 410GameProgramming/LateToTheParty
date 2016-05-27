using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class LoadOnClick : MonoBehaviour {

	public GameObject loadingImage;
	public GameObject otherImage;
	public GameObject HTPImage;
	public bool GodMode;
	public bool HTP;

	public void LoadScene(int level) {
		loadingImage.SetActive (true);
		if (GodMode) {
			otherImage.SetActive (true);
		}
		SceneManager.LoadScene (level);

	} 

	public void LoadSceneGod() {
		otherImage.SetActive (true);
		/* GameObject player = GameObject.Find("Player");
		 * PlayerController playerController = player.GetComponent<PlayerController>;
		 * playerController.god_mode = true;
		 */
		//GameManager.instance.god_mode = true;
	}

	public void QuitGame() {
		Application.Quit ();
	}

	public void ActivateGodMode() {
		GodMode = !GodMode;
	}

	public void ShowHowToPlay() {
		HTP = !HTP;
		HTPImage.SetActive (HTP);
	}
}
//GameManager.instance.variable