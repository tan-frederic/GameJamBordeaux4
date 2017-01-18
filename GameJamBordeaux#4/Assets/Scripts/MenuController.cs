using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour {

	private bool _onPause = false;
	[SerializeField]
	private GameObject pauseMenu;
	[SerializeField]
	private GameManager gm;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Cancel") && !gm.levelFinised()) {
			_onPause = !_onPause;
			if (_onPause) {
				Time.timeScale = 0;
				pauseMenu.SetActive (true);
			} else {
				resumeGame ();
			}
		}
	}

	public void resumeGame()
	{
		Time.timeScale = 1;
		_onPause = false;
		pauseMenu.SetActive (false);
	}

	public void reloadLevel()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void exitGame()
	{
		Application.Quit ();
	}

	public void mainMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene ("MainMenu");
	}
}
