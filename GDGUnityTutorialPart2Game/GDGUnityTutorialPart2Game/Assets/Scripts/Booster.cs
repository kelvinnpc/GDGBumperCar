using UnityEngine;
using System.Collections;

public class Booster : MonoBehaviour {

	public enum Type {HP, SPEED}
	public Type type;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		// Apply boost to other
		if(other.tag == "Player") {
			if (type == Type.HP) {
				other.GetComponent<Controller> ().setHealth (100);
			} else if (type == Type.SPEED) {
				other.GetComponent<Controller> ().speedBoost (2, 5);
			}
			// Set spawner to receive spawns again
			Transform parent = transform.parent;
			parent.tag = "Respawn";
			healthboost.instance.UpdateSpawners ();
			// Destroy self
			Destroy(gameObject);

		
		}

	}
}
