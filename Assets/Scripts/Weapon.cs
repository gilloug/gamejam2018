using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Weapon {
	float get_cooldown();
	void use (GameObject parent, Vector2 direction);
}
