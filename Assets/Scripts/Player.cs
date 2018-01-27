using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float jump_velocity = 20f;
	public float move_velocity = 20f;
	public float disable_time = 5f;
	public float health_max = 50f;
	public GameObject weapon;

	private Rigidbody2D body;
	private Collider2D coll;
	private int wall_layer;
	private Weapon weapon_script;
	private float weapon_cooldown;
	private int jump_max;
	private float health;

	private float disable_time_left = 0;
	private float weapon_cooldown_left = 0;
	private int jump_left = 0;
	private bool disabled = false;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		coll = GetComponent<Collider2D>();
		wall_layer = 1 << LayerMask.NameToLayer("Wall");
		weapon_script = weapon.GetComponent<Weapon> ();
		weapon_cooldown = weapon_script.get_cooldown();
		jump_max = 2;
		health = health_max;
	}

	void update_movement() {
		if (Physics2D.Raycast (new Vector2 (coll.bounds.center.x, coll.bounds.min.y), Vector2.down, 0.1f, wall_layer).collider) {
			jump_left = jump_max;
		}
		float x_speed = body.velocity.x + Input.GetAxis ("Horizontal") * move_velocity * Time.deltaTime;
		float y_speed = body.velocity.y;
		if (jump_left > 0 && Input.GetKeyDown("joystick button 5"))
		{
			jump_left--;
			y_speed = jump_velocity;
		}
		body.velocity = new Vector2 (x_speed, y_speed);
	}

	void update_fire() {
		if (disabled)
			return;
		Vector2 fire_direction = new Vector2 (Input.GetAxis ("R-Horizontal"), -Input.GetAxis ("R-Vertical"));
		if (weapon_cooldown_left > 0) {
			weapon_cooldown_left -= Time.deltaTime;
		} else if (fire_direction.magnitude > 0.01) {
			weapon_script.use (gameObject, fire_direction.normalized);
			weapon_cooldown_left = weapon_cooldown;
		}
	}

	public void take_damage(float damage) {
		if (disabled)
			return;
		health -= damage;
		if (health > 0) {
			return;
		}
		disable ();
	}

	void disable() {
		disabled = true;
		health = health_max;
		disable_time_left = disable_time;
	}

	void update_disable() {
		if (!disabled) {
			return;
		}
		if (disable_time_left > 0) {
			disable_time_left -= Time.deltaTime;
			return;
		}
		disabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		update_disable ();
		update_movement ();
		update_fire ();
	}
}
