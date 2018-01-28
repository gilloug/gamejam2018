using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamepadInput;

public class Selection : MonoBehaviour {

	public Sprite[] splashart;
	public Text[] playerIndication;
	public Image[] classSelected;
	public int[] IndexPersonnages;
	public Sprite[] EcussonsSprites;
	public Image[] EcussonsPosition;
	public Text[] NomsDesRois;

	//all prefabs
	public GameObject[] prefabClasses;

	public float[] reset;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < GlobalGameManager._instance.nbplayer; i++) {
			IndexPersonnages [i] = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < GlobalGameManager._instance.nbplayer; i++) {
			reset[i] -= Time.deltaTime;
			NomsDesRois [i].text = GlobalGameManager._instance.players [i].name;
			classSelected [i].sprite = splashart [IndexPersonnages [i]];
			EcussonsPosition [i].color = new Color (255, 255, 255, 1);
			EcussonsPosition [i].sprite = EcussonsSprites [IndexPersonnages [i]];
			if (playerIndication [i].text == "PRESS START") {
				playerIndication [i].text = "";
			}
			Vector2 axis = GamePad.GetAxis (GamePad.Axis.LeftStick, GlobalGameManager._instance.players [i].gpIndex);
			if (axis.y > 0 && reset[i] <= 0 && !GlobalGameManager._instance.players [i].isReady) {
				if (IndexPersonnages [i] + 1 >= 4) {
					IndexPersonnages [i] = 0;
				} else {
					IndexPersonnages [i] += 1;
				}
				reset[i] = 0.5f;
			}
			if (axis.y < 0 && reset[i] <= 0 && !GlobalGameManager._instance.players [i].isReady) {
				if (IndexPersonnages [i] - 1 < 0) {
					IndexPersonnages [i] = 3;
				} else {
					IndexPersonnages [i] -= 1;
				}
				reset[i] = 0.5f;
			}
			if (axis.x == 0 && axis.y == 0)
				reset[i] = 0;
			if (GamePad.GetButton(GamePad.Button.A,  GlobalGameManager._instance.players [i].gpIndex)) {
				GlobalGameManager._instance.players [i].prefab = prefabClasses[IndexPersonnages[i]];
				GlobalGameManager._instance.players [i].isReady = true;
				playerIndication [i].text = "PLAYER READY";
				GlobalGameManager._instance.players [i].ecusson = EcussonsSprites [IndexPersonnages[i]];
				playerIndication [i].color = new Color (0, 201, 0, playerIndication [i].color.a);
			}
		}
	}
}
