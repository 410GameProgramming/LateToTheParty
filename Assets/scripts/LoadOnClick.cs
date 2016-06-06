using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

	public GameObject loadingImage;
	public GameObject otherImage;
	public GameObject HTPImage;
    public GameObject creditsImage;
	public bool GodMode;
	public bool HTP;
    public bool credits;

	public void LoadScene(int level) {
		loadingImage.SetActive(true);
		if (GodMode) {
            GameManager.instance.godMode = true;
            //otherImage.SetActive(true);
		}
		SceneManager.LoadScene(level);

	} 

	/*
	public void LoadSceneGod() {
		otherImage.SetActive (true);
	}
	*/

	public void QuitGame() {
		Application.Quit();
	}

	public void ActivateGodMode() {
		GodMode = !GodMode;
	}

    public void ShowCredits() {
        credits = !credits;
        creditsImage.SetActive(credits);
    }

	public void ShowHowToPlay() {
		HTP = !HTP;
		HTPImage.SetActive (HTP);
	}
}