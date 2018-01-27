using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWeapon : MonoBehaviour, Weapon {

	public GameObject bullet_prefab;
	public float cooldown = 0.2f;
	public float bullet_speed = 10f;

	// Use this for initialization
	void Start () {
		
	}

	public float get_cooldown() {
		return cooldown;
	}

	public void use(GameObject parent, Vector2 direction) {
		GameObject bullet = GameObject.Instantiate (bullet_prefab, (Vector2)(parent.transform.position) + direction, parent.transform.rotation);
		Destroy (bullet, 5);
		bullet.GetComponent<Bullet> ().set_owner (parent.GetComponent<BoxCollider2D>());
		bullet.GetComponent<Rigidbody2D>().velocity = direction * bullet_speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
