using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    // Spawn items on player position with random direction
    public static void Spawn(GameObject[] items, Transform transform, float speed = 200f)
    {
        foreach (GameObject item in items)
        {
			item.SetActive (true);
			Vector2 direction = (new Vector2(Random.Range(-100, 100), Random.Range(-100, 100))).normalized;
			item.transform.position = transform.position;
			item.GetComponent<Rigidbody2D>().AddForce(direction * Random.Range(speed / 2, speed));
        }
    }
}
