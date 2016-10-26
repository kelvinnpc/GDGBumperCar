using UnityEngine;
using System.Collections;

public class healthboost : MonoBehaviour {
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	public GameObject[] toSpawn;
	private GameObject[] spawner;
	private int size;
	static float period = 3.0f;
	float time = period;

	public static healthboost instance;
	// Use this for initialization
	void Start () {
		instance = this;

		spawner = GameObject.FindGameObjectsWithTag("Respawn");
		size = spawner.Length;
		//Vector2 pos = new Vector2(Random.Range(0,10), Random.Range(0,10));
		//Quaternion quat = new Quaternion (Random.Range (0, 10), Random.Range (0, 10), Random.Range (0, 10), Random.Range (0, 10));
		//Instantiate (this, pos, quat);
	}
	
	// Update is called once per frame
	void Update () {
		time = time - Time.deltaTime;
		if (time <= 0) {
			if (size != 0) {
				
			

				int index = Random.Range (0, size); 
				Vector2 spawnPos = spawner [index].transform.position;
				//TODO replace stub
				int rnd = Random.Range(0, toSpawn.Length);
				GameObject boost = Instantiate (toSpawn[rnd], spawnPos, Quaternion.identity) as GameObject;
				boost.transform.parent = spawner [index].transform;
				time = period;
				spawner [index].tag = "Item";

				UpdateSpawners ();
			}
		}
	}

	void FixedUpdate() {
		
	}

	void retrieveItem(GameObject item) {
		
	}

	public void UpdateSpawners ()
	{
		spawner = GameObject.FindGameObjectsWithTag ("Respawn");
		size = spawner.Length;
	}
}
