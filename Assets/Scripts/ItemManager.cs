using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update () {

    }

    // Spawn items on player position with random direction
    public static void Spawn(GameObject[] items, Transform pos, float speed = 200f, int lifetime = 15)
    {
        foreach (GameObject item in items)
        {
            Destroy(item.gameObject, lifetime);
            float my_speed = Random.Range(speed / 2, speed); // xAngle is between -1 and 1
            float xAngle = Random.Range(-100, 100); // xAngle is between -1 and 1
            float yAngle = Random.Range(-100, 100); // yAngle is between 0 and 100
            item.transform.Rotate(new Vector3(xAngle / 100, yAngle / 100, 0) * my_speed); // Set vector to our object
            item.GetComponent<Rigidbody>().AddForce(new Vector3(xAngle / 100, yAngle / 100, 0) * my_speed); // Add force to our object
        }
    }
}
