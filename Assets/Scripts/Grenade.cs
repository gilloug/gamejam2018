using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
    public float damage = 25f;
    public bool destroy_on_contact = true;
    private BoxCollider2D owner = null;
    public float countdown = 3f;
    GameObject parent = null;
    public float bullet_speed = 10f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            for (float x = -1; x < 1; x += 0.1f)
            {
                for (float y = -1; y < 1; y += 0.1f)
                {
                    var direction = new Vector2(x, y);
                    GameObject bullet = GameObject.Instantiate(gameObject, (Vector2)(transform.position) + direction, transform.rotation);
                    Destroy(bullet, 1);
                    bullet.GetComponent<InstanciableWeapon>().configure(parent);
                    bullet.GetComponent<Rigidbody2D>().velocity = direction * bullet_speed;
                }
            }
        }
        Destroy(gameObject);
    }

    public void configure(GameObject player)
    {
        parent = player;
        owner = player.GetComponent<BoxCollider2D>();
        damage *= player.GetComponent<Player>().damage_multiplicator.current;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject obj = coll.gameObject;
        if (obj.layer == LayerMask.NameToLayer("Player"))
        {
            obj.GetComponent<Player>().take_damage(damage);
        }
        if (destroy_on_contact)
        {
            Destroy(gameObject);
        }
    }
}
