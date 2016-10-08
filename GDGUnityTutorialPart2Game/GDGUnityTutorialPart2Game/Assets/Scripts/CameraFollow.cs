using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public GameObject targetObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (targetObj != null) {
			Vector3 targetObjPos = targetObj.transform.position;
			transform.position = new Vector3 (targetObjPos.x, targetObjPos.y, -10);
		}
	}
}
