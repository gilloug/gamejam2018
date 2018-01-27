using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthItem : Item
{
	public float to_add = 3f;
    // Use this for initialization
    void Start()
    {
		this.active = false;
    }

    // Add capacities to the player
	public override void update_player(Player parent)
    {
		parent.health.origin += to_add;
    }

}