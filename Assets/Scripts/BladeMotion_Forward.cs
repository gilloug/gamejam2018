using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeMotion_Forward : MonoBehaviour {

	Vector3 direction;
	// Use this for initialization
	void Start () {
		direction = (transform.position - transform.parent.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction * Time.deltaTime;
	}
}
