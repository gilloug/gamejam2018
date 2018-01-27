

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject[] players;
	private Camera cam;

	void Start () {
		cam = GetComponent<Camera> ();
	}

	void Update () {
		Vector3 v = new Vector3 ();
		foreach (GameObject player in players) {
			v += player.transform.position;
		}
		v /= players.Length;
		cam.transform.LookAt (v);
		float dist = 0;
		float new_dist = 0;
		foreach (GameObject player in players) {
			new_dist = Mathf.Abs (player.transform.position.x - v.x);
			if (new_dist > dist)
				dist = new_dist;
			new_dist = Mathf.Abs (player.transform.position.y - v.y);
			if (new_dist > dist)
				dist = new_dist;
		}
		cam.orthographicSize = 1 + dist;
	}
}
