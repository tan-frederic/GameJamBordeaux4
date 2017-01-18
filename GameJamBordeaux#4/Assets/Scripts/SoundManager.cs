using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	/*
	** Singleton who play the music during the game.
	*/

	public AudioSource musicSource;

	public static SoundManager _instance = null;

	// Use this for initialization
	void Start () {
		if (_instance == null)
			_instance = this;
		else if (_instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
