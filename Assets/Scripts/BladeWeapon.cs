using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeWeapon : MonoBehaviour, Weapon {

	// Use this for initialization
	public GameObject blade_prefab;
	public float cooldown = 0.2f;
	public float blade_duration = 0.1f;

	// Use this for initialization
	void Start () {

	}

	public float get_cooldown() {
		return cooldown;
	}

	public void use(GameObject parent, Vector2 direction) {
		BoxCollider2D coll = parent.GetComponent<BoxCollider2D> ();
		GameObject blade = GameObject.Instantiate (
			blade_prefab,
			(Vector2)(parent.transform.position) + Vector2.ClampMagnitude(direction, coll.bounds.size.x / 2),
			Quaternion.AngleAxis(Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg, Vector3.forward)
		);
		blade.transform.parent = parent.transform;
		Destroy (blade, blade_duration);
		blade.GetComponent<InstanciableWeapon> ().configure (parent);
	}

	// Update is called once per frame
	void Update () {

	}
}
