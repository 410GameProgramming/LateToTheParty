using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

	public GameObject loadingImage;
	public GameObject otherImage;
	public GameObject HTPImage;
	public bool GodMode;
	public bool HTP;

	public void LoadScene(int level) {
		loadingImage.SetActive(true);
		if (GodMode) {
            GameManager.instance.godMode = true;
            otherImage.SetActive(true);
		}
		SceneManager.LoadScene(level);

	} 

	public void LoadSceneGod() {
		otherImage.SetActive (true);
	}

	public void QuitGame() {
		Application.Quit();
	}

	public void ActivateGodMode() {
		GodMode = !GodMode;
	}

	public void ShowHowToPlay() {
		HTP = !HTP;
		HTPImage.SetActive (HTP);
	}
}