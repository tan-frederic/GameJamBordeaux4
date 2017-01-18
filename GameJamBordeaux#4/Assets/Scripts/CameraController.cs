using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField]
	private GameObject _player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	** Check the camera to be always on the player
	*/
	void LateUpdate() {
		Vector3 position = new Vector3 (_player.transform.position.x, _player.transform.position.y, transform.position.z);
		transform.position = position;
	}
}
