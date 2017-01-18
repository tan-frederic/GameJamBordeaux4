using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenueManager : MonoBehaviour {

	public void StartGame()
	{
		SceneManager.LoadScene ("level1");
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void LoadLevel(string level)
	{
		SceneManager.LoadScene (level);
	}
}
