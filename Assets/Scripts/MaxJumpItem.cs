using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxJumpItem : Item
{
	public int to_add = 1;

    // Use this for initialization
    void Start()
    {
		this.active = false;
    }

    // Add capacities to the player
	public override void update_player(Player parent)
    {
		parent.jump_count.origin += to_add;
    }
}