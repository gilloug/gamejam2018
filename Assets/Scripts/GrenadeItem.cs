using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeItem : MonoBehaviour, Item
{
    public float speed = 5f;
    public float bullet_speed = 5f;

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
        return (true);
    }

    // Add capacities to the player
    public void update_player(Player parent)
    {

    }

    public void use(GameObject parent, Vector2 direction)
    {
        GameObject grenade = GameObject.Instantiate(gameObject, (Vector2)(parent.transform.position) + direction, parent.transform.rotation);
        grenade.GetComponent<Grenade>().configure(parent);
        grenade.GetComponent<Rigidbody>().AddForce(direction * bullet_speed);
        Destroy(gameObject);
    }
}