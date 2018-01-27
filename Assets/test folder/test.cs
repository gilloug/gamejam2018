using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    public GameObject[] toto;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
        if(toto[0])
            ItemsManager.Spawn(toto, toto[0].transform);
    }
}
