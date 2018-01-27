using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciableWeapon : MonoBehaviour {

	public float damage = 10f;
	public bool destroy_on_contact = false;
	private BoxCollider2D owner = null;

	// Use this for initialization
	void Start () {

	}

	public void configure(GameObject player) {
		owner = player.GetComponent<BoxCollider2D>();
		damage *= player.GetComponent<Player>().damage_multiplicator.current;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider == owner) {
			return;
		}
		GameObject obj = coll.gameObject;
		if (obj.layer == LayerMask.NameToLayer("Player")) {
			obj.GetComponent<Player> ().take_damage(damage);
		}
		if (destroy_on_contact) {
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
