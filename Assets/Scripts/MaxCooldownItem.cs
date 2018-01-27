using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxCooldownItem : Item
{
	public float to_mul = 0.9f;
    // Use this for initialization
    void Start()
    {
		this.active = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

	// Add capacities to the player
	public override void update_player(Player parent)
    {
		parent.weapon_cooldown.origin = parent.weapon_cooldown.origin * to_mul;
    }
}