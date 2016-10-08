using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject playerObj;
	public float activeRange;
	public float speed;
	Rigidbody2D rgbody;

	// Use this for initialization
	void Start () {
		rgbody = GetComponent<Rigidbody2D> ();
		playerObj = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		if (playerObj != null) {
			//Get distance to player
			Vector2 playerDirection = playerObj.transform.position - transform.position;
			Vector2 velocity = Vector2.zero;

			if (playerDirection.magnitude < activeRange) {
				velocity += playerDirection.normalized * speed;
				transform.right = playerDirection.normalized;
			}

			rgbody.velocity = velocity;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			Destroy (other.gameObject);
		}
	}
}
