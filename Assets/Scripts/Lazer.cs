using UnityEngine;
using System.Collections;

public class Lazer : MonoBehaviour {

	float moveSpeed = 5f;

	Rigidbody2D rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		rigidBody.velocity += new Vector2 (-moveSpeed, 0);
	}
	
	void Update () {
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
