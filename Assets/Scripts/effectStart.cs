using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class effectStart : MonoBehaviour {
	
	private bool _decre = true;

	// Update is called once per frame
	void Update () {
		Text text = gameObject.GetComponent<Text> ();
		if (_decre) {
			if (text.color.a <= 0)
				_decre = false;
			else
				text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - 0.02f);
		}
		if (!_decre) {
			if (text.color.a >= 1)
				_decre = true;
			else
				text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + 0.02f);
		}
	}
}
