using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	//public float speed;
	//public GameObject bulletPrefab;
	//public GameObject muzzle;
	public int player;
	public float health;
	public float thrust = 5;
	//private float brake = 3;
	private float angularVelocity;
	//Vector2 lookDirection = Vector2.zero;
	Rigidbody2D rgbody;

	// Use this for initialization
	void Start () {
		rgbody = GetComponent<Rigidbody2D> ();
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (rgbody.velocity.magnitude);
		//Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//lookDirection = (mousePos - (Vector2)transform.position).normalized;
		//transform.right = lookDirection;
		if (health <= 0)
			Destroy (this.gameObject);
	}

	void FixedUpdate() {
		//Vector3 velocity = Vector3.zero;
		bool AorD = false;
		if ((player == 1 && Input.GetKey (KeyCode.W)) || (player == 2 && Input.GetKey(KeyCode.UpArrow))) {
			//velocity += Vector3.up * speed;
			rgbody.AddForce(transform.right * thrust);
		} if ((player == 1 && Input.GetKey (KeyCode.A)) || (player == 2 && Input.GetKey(KeyCode.LeftArrow))) {
			//velocity += Vector3.left * speed;
			/*AorD = true;
			angularVelocity = 140;
			rgbody.AddForce(transform.up * thrust/2);*/
			rgbody.AddTorque (10 * Time.fixedDeltaTime);
		} if ((player == 1 && Input.GetKey (KeyCode.S)) || (player == 2 && Input.GetKey(KeyCode.DownArrow))) {
			//velocity += Vector3.down * speed;
			rgbody.AddForce(-transform.right * (thrust));
		} if ((player == 1 && Input.GetKey (KeyCode.D)) || (player == 2 && Input.GetKey(KeyCode.RightArrow))) {
			//velocity += Vector3.right * speed;
			/*AorD = true;
			angularVelocity = -140;
			rgbody.AddForce(-transform.up * thrust/2);*/
			rgbody.AddTorque (-10 * Time.fixedDeltaTime);
		} //if(Input.GetKeyDown())
		/*if(!AorD) {
			angularVelocity = 0;
		}
		rgbody.angularVelocity = angularVelocity;*/
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

	public float getHealth() {
		return health;
	}

	public void setHealth(float health) {
		this.health = health;
	}

	void OnCollisionEnter2D(Collision2D other) {
		health -= 5;
		if (other.gameObject.tag == "Player") {
			RaycastHit2D hit = Physics2D.CircleCast (transform.position + transform.right, GetComponent<CircleCollider2D>().radius, transform.right);
			if (hit.collider.tag == "Player") {
				Controller player2 = hit.transform.GetComponent<Controller> ();
				player2.setHealth (player2.getHealth () - rgbody.velocity.magnitude*2);

			}
		}

//		Destroy (this.gameObject);
	}

	public void speedBoost (float increaseAmt, float duration) {
		StartCoroutine (speedBoostDuration (increaseAmt, duration));
	}

	IEnumerator speedBoostDuration(float increaseAmt, float duration) {
		rgbody.velocity *= increaseAmt;
		thrust *= increaseAmt;
		yield return new WaitForSeconds (duration);
		thrust /= increaseAmt;
		rgbody.velocity /= increaseAmt;
	}
}
