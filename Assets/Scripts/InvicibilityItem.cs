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

	public override void use(GameObject parent, Vector2 direction)
	{
		parent.GetComponent<Player>().disable();
		Destroy (gameObject);
	}
}