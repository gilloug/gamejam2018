using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownItem : Item
{
	public float to_add = 1f;

	// Use this for initialization
	void Start()
	{
		this.active = false;
	}

	// Add capacities to the player
	public override void update_player(Player parent)
	{
		parent.crown_step.origin = to_add;
	}
}