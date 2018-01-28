using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleSpawner : MonoBehaviour
{
    private int         playerNb;
    public double       delay = 1.0;
    private double      time = 0.0;
    public GameObject[] items;
    public Vector3[]    playerSpawn;
    public Vector3[]    itemSpawn;

    void Start()
    {
        playerNb = 0;
    }

    void Update()
    {
        if (time + delay < Time.fixedTime)
        {
            Instantiate(items[Random.Range(0, 5)], itemSpawn[Random.Range(0, 11)], transform.rotation);
            time = Time.fixedTime;
        }
    }

    public void SpawnPlayer(GameObject player)
    {
        player.transform.Translate(playerSpawn[playerNb++]);
    }
}