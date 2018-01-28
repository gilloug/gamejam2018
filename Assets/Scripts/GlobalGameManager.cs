using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamepadInput;
using UnityEngine.SceneManagement;

public class GlobalGameManager : MonoBehaviour {

	public static GlobalGameManager _instance = null;

	private string[] noms = { "Lancelot", "Arthur", "Grégoire",  "Alexandre", "Amanguin", "Bohort", "Yvain", "Cynon", "Dagonet", "Erec", "Fergus", "Gale", "Perceval", "Caradoc", "Hector", "Haymon", "Tristan", "Louis", "Léodagan", "Lionel"}; // to fill
	private string[] adj = {"l'idiot", "le courageux", "le clément", "l'indulgent", "le chauve", "le miséricordieux", "le bienveillant", "l'orgueilleux", "le mal fringué",  "le minuscule", "le sordide", "l'obscur", "le minable", "le borné", "le laid", "le magnifique", "le modeste", "l'humble", "le jeunot", "l'avare", "le noble", "le chevalier", "le fripon", "le pirate", "le carambouilleur", "la fripouille", "l'aigrefin", "le bandit", "le fraudeur", "le malfaiteur", "le tricheur", "le grandiose", "l'imposant", "l'éclatant", "le généreux", "le sublime", "le majestueux", "le grand", "le juste"}; // to fill
	public PlayerForUI[] players;
	public int nbplayer = 0;

	void Awake() {
		if (_instance == null)
			_instance = this;
		else if (_instance != this) {
			Destroy (this);
		}
		DontDestroyOnLoad (this);
	}

	void Start() {
	}

	// Update is called once per frame
	void Update () {
		if (GamePad.GetButtonDown (GamePad.Button.Start, GamePad.Index.One)) {
			for (int j = 0; j < players.Length; j++) {
				if (players [j].gpIndex == GamePad.Index.One)
					break;
				if (players [j].name == "") {
					players [j].name = noms[Random.Range(0, noms.Length)] + " " + adj[Random.Range(0, adj.Length)];
					players [j].gpIndex = GamePad.Index.One;
					nbplayer += 1;
					break;
				}
			}
		}

		if (GamePad.GetButtonDown (GamePad.Button.Start, GamePad.Index.Two)) {
			for (int j = 0; j < players.Length; j++) {
				if (players [j].gpIndex == GamePad.Index.Two)
					break;
				if (players [j].name == "") {
					players [j].name = noms[Random.Range(0, 2)] + " " + adj[Random.Range(0, 2)];
					players [j].gpIndex = GamePad.Index.Two;
					nbplayer += 1;
					break;
				}
			}
		}

		if (GamePad.GetButtonDown (GamePad.Button.Start, GamePad.Index.Three)) {
			for (int j = 0; j < players.Length; j++) {
				if (players [j].gpIndex == GamePad.Index.Three)
					break;
				if (players [j].name == "") {
					players [j].name = noms[Random.Range(0, 2)] + " " + adj[Random.Range(0, 2)];
					players [j].gpIndex = GamePad.Index.Three;
					nbplayer += 1;
					break;
				}
			}
		}

		if (GamePad.GetButtonDown (GamePad.Button.Start, GamePad.Index.Four)) {
			for (int j = 0; j < players.Length; j++) {
				if (players [j].gpIndex == GamePad.Index.Four)
					break;
				if (players [j].name == "") {
					players [j].name = noms [Random.Range (0, 2)] + " " + adj [Random.Range (0, 2)];
					players [j].gpIndex = GamePad.Index.Four;
					nbplayer += 1;
					break;
				}
			}
		}
//		if (nbplayer > 1 && AllPlayersAreReady ()) {
		if (nbplayer > 0 && AllPlayersAreReady ()) {
			if (GamePad.GetButton (GamePad.Button.Start, GamePad.Index.Any)) {
				SceneManager.LoadScene ("Map 1");
			}
		}
	}

	private bool AllPlayersAreReady() {
		for (int i = 0; i < nbplayer; i++) {
			if (!players [i].isReady)
				return false;
		}
		return true;
	}
}

