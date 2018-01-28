using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeMotion_Swipe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.parent.position, Vector3.forward, -1000 * Time.deltaTime);
	}
}
