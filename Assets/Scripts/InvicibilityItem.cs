using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvicibilityItem : Item
{
	// Use this for initialization
	void Start()
	{
		this.active = true;
	}

	// Update is called once per frame
	void Update()
	{
	}

	public override void use(GameObject parent, Vector2 direction)
	{
		parent.GetComponent<Player>().disable();
		// maybe change it to "Destroy (gameObject, 5);" if a sprite is assiociated to the object
		Destroy (gameObject);
	}
}