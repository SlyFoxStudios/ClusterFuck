using UnityEngine;
using System.Collections;

public class Lazer : MonoBehaviour {

	float moveSpeed = 13f;

	Rigidbody2D rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		transform.position += transform.right * Time.deltaTime * moveSpeed;
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
