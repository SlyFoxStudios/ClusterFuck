using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 10f;

	void Start () {
	}
	
	void Update () {

		float moveSpeed = speed * Time.deltaTime;


		//WASD Keys
		if (Input.GetKey (KeyCode.W)) {
			transform.position += new Vector3 (0, moveSpeed);
		}
		else
		if (Input.GetKey (KeyCode.A)) {
			transform.position += new Vector3 (-moveSpeed, 0);
		}
		else
		if (Input.GetKey (KeyCode.S)) {
			transform.position += new Vector3 (0, -moveSpeed);
		}
		else
		if (Input.GetKey (KeyCode.D)) {
			transform.position += new Vector3 (moveSpeed, 0);
		}

		//Look at mouse
		Vector3 mouse = Input.mousePosition;
		Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
		Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
		float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, angle);
	}

	void Shoot()
	{
	}
}
