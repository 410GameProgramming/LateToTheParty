using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public Canvas titleMenu;
    public Button startButton;

	void Start () {
        titleMenu = titleMenu.GetComponent<Canvas>();
        startButton = startButton.GetComponent<Button>();
	}
	
	public void LoadScene() {
        SceneManager.LoadScene(0);
    }

    public void ExitGame() {
        Application.Quit();
    }
}