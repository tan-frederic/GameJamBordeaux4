using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	GameManager gm;
	public float maxSpeed = 10f;
	bool facingRight = true;
	Rigidbody2D	_rb;
	Animator anim;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer("Character"), LayerMask.NameToLayer("Wall"), false);
		_rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		_rb.gravityScale *= Mathf.Abs(_rb.gravityScale);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		float move = Input.GetAxis ("Horizontal");
		_rb.velocity = new Vector2 (move * maxSpeed, _rb.velocity.y);
		anim.SetFloat ("Speed", Mathf.Abs(move));
		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "DeathZone")
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		if (other.tag == "Item")
			gm.addItem ();
	}
}
