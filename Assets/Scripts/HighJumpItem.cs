using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpItem : MonoBehaviour, Items
{
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
        parent.jump_velocity += 2;
    }

    // Erase capacities from the player
    public void on_drop(Player parent)
    {
        parent.jump_velocity -= 2;
    }

    public void use(GameObject parent, Vector2 direction)
    {
    }
}