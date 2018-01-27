using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeItem : Item
{
    public float grenade_speed = 10f;
    public GameObject _grenade;

    // Use this for initialization
    void Start()
    {
        this.active = true;
    }

    // Use item
    override public void use(GameObject parent, Vector2 direction)
    {
        GameObject grenade = GameObject.Instantiate(_grenade, (Vector2)(parent.transform.position) + direction, parent.transform.rotation);
        grenade.GetComponent<Grenade>().configure(parent);
        grenade.GetComponent<Rigidbody2D>().velocity = (direction * grenade_speed);
        Destroy(gameObject);
    }
}