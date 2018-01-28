using UnityEngine;
using System.Collections;
 
public class DontGoThroughThings : MonoBehaviour
{
	private LayerMask layerMask;
	private Vector2 previousPosition; 
	private Rigidbody2D myRigidbody;
 
	//initialize values 
	void Start() {
		myRigidbody = GetComponent<Rigidbody2D>();
		previousPosition = (Vector2)myRigidbody.position; 
		layerMask = 1 << LayerMask.NameToLayer ("Wall");
	}
 
	void FixedUpdate() {
		Vector2 movementThisStep = (Vector2)myRigidbody.position - previousPosition;
		RaycastHit2D hitInfo = Physics2D.Raycast(previousPosition, movementThisStep, movementThisStep.magnitude, layerMask.value);
		if (hitInfo.collider) {
			myRigidbody.velocity = new Vector2 ();
			myRigidbody.position = previousPosition;
		} else {
			previousPosition = myRigidbody.position;
		}
	}
}