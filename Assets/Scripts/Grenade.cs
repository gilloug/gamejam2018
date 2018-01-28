using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private float countdown = 3f;
    public int shrapnels = 30;
    public GameObject bullet;
    private GameObject owner = null;
    public float speed = 35f;

    // Use this for initialization
    void Start()
    {
    }

    public void configure(GameObject player)
    {
        owner = player;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            for (int i = 0; i < shrapnels; i++)
            {
                Vector2 direction = (new Vector2(Random.Range(-100, 100), Random.Range(-100, 100))).normalized;
                GameObject shrapnel = GameObject.Instantiate(bullet, (Vector2)transform.position + direction, transform.rotation);
                shrapnel.GetComponent<InstanciableWeapon>().configure(owner);
                shrapnel.GetComponent<Rigidbody2D>().velocity = (direction * speed);
            }
            Destroy(gameObject);
        }
    }
}
