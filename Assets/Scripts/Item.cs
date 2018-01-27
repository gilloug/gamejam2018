using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
	// Childs must initialize this boolean
	protected bool active;

	// returns whether the item is active or not
	public bool is_active(){
		return active;
	}

	public virtual void Update() {
	}

	// Add capacities to the player
	public virtual void update_player(Player parent){
	}

	// Use item
	public virtual void use(GameObject parent, Vector2 direction){
	}
}