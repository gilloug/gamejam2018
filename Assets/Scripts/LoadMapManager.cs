using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMapManager : MonoBehaviour {

	public GameObject gameManagerMapPrefab;

	// Use this for initialization
	void Awake () {
		GameManager gameManager = Instantiate (gameManagerMapPrefab).GetComponent<GameManager>();
		gameManager.cam = GameObject.Find ("Main Camera").GetComponent<Camera>();
		for (int i = 0; i < GlobalGameManager._instance.nbplayer; i++) {
			gameManager.players.Add(GlobalGameManager._instance.players[i].prefab);
			gameManager.gpIndexes.Add(GlobalGameManager._instance.players[i].gpIndex);
		}
	}
}
