using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxJumpItem : MonoBehaviour, Item
{
	public int to_add = 1;

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
		parent.jump_count.origin += to_add;
    }

    public void use(GameObject parent, Vector2 direction)
    {
    }
}