using UnityEngine;
using System.Collections;

public class Lazer : MonoBehaviour {

	float moveSpeed = 20f;

	Rigidbody2D rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
