using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Camera cam;
	public float camMin = 4f;

	public GameObject crown;
	public GameObject[] items;
	public Transform crownSpawner;
	public Transform playerSpawners;
	public Transform itemSpawners;
	public float itemSpawnRate = 10f;

	private float timer;
	public List<GamepadInput.GamePad.Index> gpIndexes = new List<GamepadInput.GamePad.Index>();
	public List<GameObject> players = new List<GameObject>();
	private List<GameObject> spawnedPlayers = new List<GameObject> ();
	private List<Transform> playerSpawnPoints = new List<Transform> ();
	private List<Transform> itemSpawnPoints = new List<Transform> ();

	// Use this for initialization
	void Start () {
		timer = itemSpawnRate;
		foreach (Transform transform in playerSpawners)
			playerSpawnPoints.Add (transform);
		foreach (Transform transform in itemSpawners)
			itemSpawnPoints.Add (transform);
		GameObject.Instantiate (crown, crownSpawner);
		for (int i = 0; i < players.Count; i++) {
			GameObject player = GameObject.Instantiate (players [i], playerSpawnPoints [i]);
			player.GetComponent<Player> ().gpIndex = gpIndexes [i];
			spawnedPlayers.Add (player);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v = new Vector3 ();
		foreach (GameObject player in spawnedPlayers) {
			v += player.transform.position;
		}
		v /= players.Count;
		v.z = cam.transform.position.z;
		cam.transform.position = v;
		float dist = 0;
		float new_dist = 0;
		foreach (GameObject player in spawnedPlayers) {
			new_dist = Mathf.Abs (player.transform.position.x - v.x);
			if (new_dist > dist)
				dist = new_dist;
			new_dist = Mathf.Abs (player.transform.position.y - v.y);
			if (new_dist > dist)
				dist = new_dist;
		}
		cam.orthographicSize = Mathf.Max(dist, camMin);
		if (timer > 0) {
			timer -= Time.deltaTime;
			return;
		}
		timer = itemSpawnRate;
		GameObject.Instantiate (items [Random.Range (0, items.Length)], itemSpawnPoints [Random.Range (0, itemSpawnPoints.Count)]);
	}
}
