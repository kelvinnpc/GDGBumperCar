using UnityEngine;
using System.Collections;

public class Controller2 : MonoBehaviour {
	//public float speed;
	//public GameObject bulletPrefab;
	//public GameObject muzzle;
	private float thrust = 5;
	//private float brake = 3;
	private float angularVelocity;
	//Vector2 lookDirection = Vector2.zero;
	Rigidbody2D rgbody;

	// Use this for initialization
	void Start () {
		rgbody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		//Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//lookDirection = (mousePos - (Vector2)transform.position).normalized;
		//transform.right = lookDirection;
	}

	void FixedUpdate() {
		//Vector3 velocity = Vector3.zero;
		bool LeftorRight = false;
		if (Input.GetKey (KeyCode.UpArrow)) {
			//velocity += Vector3.up * speed;
			rgbody.AddForce(transform.right * thrust);
		} if (Input.GetKey (KeyCode.LeftArrow)) {
			//velocity += Vector3.left * speed;
			LeftorRight = true;
			angularVelocity = 70;
		} if (Input.GetKey (KeyCode.DownArrow)) {
			//velocity += Vector3.down * speed;
			rgbody.AddForce(-transform.right * (thrust));
		} if (Input.GetKey (KeyCode.RightArrow)) {
			//velocity += Vector3.right * speed;
			LeftorRight = true;
			angularVelocity = -70;
		} 
		if(!LeftorRight) {
			angularVelocity = 0;
		}
		rgbody.angularVelocity = angularVelocity;
		/*
		if (Input.GetMouseButtonDown (0)) {
			//Instantiate bullet
			GameObject newBullet = Instantiate(bulletPrefab);
			newBullet.transform.position = muzzle.transform.position;
			newBullet.transform.rotation = this.transform.rotation;
			newBullet.GetComponent<Rigidbody2D> ().velocity = (bulletSpeed + speed) * lookDirection;
		}
		*/
	}
}
