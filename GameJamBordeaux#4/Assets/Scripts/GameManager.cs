using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	public string _nextLevel;
	public GameObject winPanel;

	int _item = 0;
	public int _itemToGet = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addItem()
	{
		++_item;
		if (_item == _itemToGet) {
			Time.timeScale = 0;
			winPanel.SetActive (true);
		}
	}

	public void loadNextLevel()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (_nextLevel);
	}

	public bool levelFinised()
	{
		return (_item == _itemToGet);
	}
}
