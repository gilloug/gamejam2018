using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public void GoToSelectionMenu() {
		SceneManager.LoadScene ("Selection");
	}

	public void GoToMainMenu() {
		SceneManager.LoadScene ("Menu");
	}

	public void QuitGame() {
		Application.Quit ();
	}
}
