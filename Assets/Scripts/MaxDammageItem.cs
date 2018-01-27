using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxDammageItem : MonoBehaviour, Item
{
	public float to_add = 2f;
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
        parent.damage_multiplicator.origin += to_add;
    }

    public void use(GameObject parent, Vector2 direction)
    {
    }
}