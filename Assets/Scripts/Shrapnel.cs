using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrapnel : MonoBehaviour
{

    public float damage = 25f;

    // Use this for initialization
    void Start()
    {
    }

    public void configure(GameObject player)
    {
        damage *= player.GetComponent<Player>().damage_multiplicator.current;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject obj = coll.gameObject;
        if (obj.layer == LayerMask.NameToLayer("Player"))
        {
            obj.GetComponent<Player>().take_damage(damage);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
