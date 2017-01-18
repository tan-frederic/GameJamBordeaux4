using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CommandScript : MonoBehaviour {

	[SerializeField]
	private InputField _commandField;
	[SerializeField]
	private GameObject _player;

	public bool pass_wall = true;
	public bool no_gravity = true;
	public bool reverse_gravity = true;

	private bool _isOpen = true;
	RectTransform _rt;

	Vector2 minPos;
	Vector2 maxPos;

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = _player.GetComponent<Rigidbody2D> ();
		_rt = GetComponent<RectTransform> ();
		minPos = _rt.localPosition;
		maxPos = _rt.localPosition;
		maxPos.x += _rt.sizeDelta.x;
		Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer("Character"), LayerMask.NameToLayer("Wall"), false);
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		rb.gravityScale *= Mathf.Abs(rb.gravityScale);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Command")) {
			_isOpen = !_isOpen;
		}
	}

	void FixedUpdate() {
		if (_isOpen) {
			_rt.localPosition = Vector3.Lerp (_rt.localPosition, minPos, Time.deltaTime * 10);
		} else {
			_rt.localPosition = Vector3.Lerp (_rt.localPosition, maxPos, Time.deltaTime * 10);
		}

	}

	/*
	** Check the command if it correspond with the possibility
	*/
	public void checkComand() {
		string command = _commandField.text;
		if (command.Contains("pass_wall") && pass_wall) { // check the pass wall command
			if (command.Contains("true")) {
				Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer("Character"), LayerMask.NameToLayer("Wall"), true);
			} else if (command.Contains("false")) {
				Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer("Character"), LayerMask.NameToLayer("Wall"), false);
			}
		} else if (command.Contains("no_gravity") && no_gravity) { //check the gravity command
			if (command.Contains("true")) {
				rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
			} else if (command.Contains("false")) {
				rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			}
		} else if (command == "reverse_gravity" && reverse_gravity) {
			rb.gravityScale *= -1;
		}
		_commandField.text = ""; //clear the command line after enter the command
	}
}
