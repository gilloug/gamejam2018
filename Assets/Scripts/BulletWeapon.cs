using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWeapon : MonoBehaviour, Weapon {

	public GameObject bullet_prefab;
	public GameObject weapon_prefab;
	public float cooldown = 0.2f;
	public float bullet_speed = 10f;
	public float weapon_duration = 0.1f;

	// Use this for initialization
	void Start () {
		
	}

	public float get_cooldown() {
		return cooldown;
	}

	public void use(GameObject parent, Vector2 direction) {
		BoxCollider2D coll = parent.GetComponent<BoxCollider2D> ();
		float angle = Mathf.Atan2 (direction.x, -direction.y) * Mathf.Rad2Deg;
		GameObject weapon = GameObject.Instantiate (
			weapon_prefab,
			(Vector2)(parent.transform.position) + Vector2.ClampMagnitude(direction, coll.bounds.size.x / 2),
			Quaternion.AngleAxis(angle - 90, Vector3.forward)
		);
		weapon.GetComponent<SpriteRenderer> ().flipY = angle < 0;
		weapon.transform.parent = parent.transform;
		Destroy (weapon, weapon_duration);
		GameObject bullet = GameObject.Instantiate (bullet_prefab, (Vector2)(parent.transform.position) + direction, parent.transform.rotation);
		Destroy (bullet, 5);
		bullet.GetComponent<InstanciableWeapon> ().configure (parent);
		bullet.GetComponent<Rigidbody2D>().velocity = direction * bullet_speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
