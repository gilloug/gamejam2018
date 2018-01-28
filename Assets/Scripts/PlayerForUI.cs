using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerForUI : MonoBehaviour {

	public string name = "";
	public GamePad.Index gpIndex = GamePad.Index.Any;
	public bool isReady = false;
	public Sprite ecusson;
	public GameObject prefab;
}
