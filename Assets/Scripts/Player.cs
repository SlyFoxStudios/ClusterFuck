using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 10f;

	void Start () {
	}
	
	void Update () {

		float moveSpeed = speed * Time.deltaTime;

		if (Input.GetKey (KeyCode.W)) {
			transform.position += new Vector3 (0, moveSpeed);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position += new Vector3 (-moveSpeed, 0);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position += new Vector3 (0, -moveSpeed);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position += new Vector3 (moveSpeed, 0);
		}
	}

	void Shoot()
	{
	}
}
