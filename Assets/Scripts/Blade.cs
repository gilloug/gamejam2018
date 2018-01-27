using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

	public float damage = 20f;
	private BoxCollider2D owner = null;

	// Use this for initialization
	void Start () {
		
	}

	public void set_owner(BoxCollider2D coll) {
		owner = coll;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider == owner) {
			return;
		}
		GameObject obj = coll.gameObject;
		if (obj.layer == LayerMask.NameToLayer("Player")) {
			obj.GetComponent<Player> ().take_damage(damage);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
