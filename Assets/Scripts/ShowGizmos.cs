using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGizmos : MonoBehaviour {

	public Color color = Color.red;
	public float size = 0.2f;

	void OnDrawGizmos() {
		Gizmos.color = color;
		Gizmos.DrawSphere (transform.position, size);
	}
}
