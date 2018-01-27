using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxDammageItem : Item
{
	public float to_add = 2f;
    // Use this for initialization
    void Start()
    {
		this.active = false;
    }

    // Add capacities to the player
	public override void update_player(Player parent)
    {
        parent.damage_multiplicator.origin += to_add;
    }

}