using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxCooldownItem : MonoBehaviour, Item
{
	public float to_mul = 0.9f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Return True if the item is an active item
    public bool is_active()
    {
        return (false);
    }

    // Add capacities to the player
    public void update_player(Player parent)
    {
		parent.weapon_cooldown.origin = parent.weapon_cooldown.origin * to_mul;
    }

    public void use(GameObject parent, Vector2 direction)
    {
    }
}