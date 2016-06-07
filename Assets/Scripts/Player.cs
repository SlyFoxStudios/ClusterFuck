using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public float speed = 10f;

	//public var bullet : GameObject;
	public GameObject bullet;

	public float shootSpeed = 0.55f;

	bool canShoot = true;

	public AudioClip[] shootSounds;

	System.Random random = new System.Random ();

	AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
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
		
		//Arrow keys.
		if (Input.GetKey ("up")) {
			transform.position += new Vector3 (0, moveSpeed);
		}
		else
		if (Input.GetKey ("left")) {
			transform.position += new Vector3 (-moveSpeed, 0);
		}
		else
		if (Input.GetKey ("down")) {
			transform.position += new Vector3 (0, -moveSpeed);
		}
		else
		if (Input.GetKey ("right")) {
			transform.position += new Vector3 (moveSpeed, 0);
		}

		//A test shooting... seen as it doesnt work... -_-
		if (Input.GetKeyDown("space")) {
			if (canShoot) {
				StartCoroutine(Shoot ());
				Instantiate(bullet, transform.position, Quaternion.identity);
			}
		}

		//Shooting
		//This clearly works... not.
		if (Input.GetMouseButton (0)) {
			if (canShoot) {
				StartCoroutine(Shoot ());
				/**
				*Well... uncomment the below code for some trippy shit.
				*/
				//Instantiate(bullet, transform.position, Quaternion.identity);
			}
		}

		//Look at mouse
		Vector3 mouse = Input.mousePosition;
		Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
		Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
		float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, angle);
	}

	IEnumerator Shoot()
	{
		audioSource.clip = GetShootSound ();
		audioSource.Play ();
		canShoot = false;
		yield return new WaitForSeconds (shootSpeed);
		canShoot = true;
	}

	/// <summary>
	/// Gets the shoot sound and makes sure it isn't same sound as before.
	/// </summary>
	/// <returns>A random shooting sound.</returns>
	AudioClip GetShootSound()
	{
		List<AudioClip> usable = new List<AudioClip> (shootSounds);
		usable.Remove (audioSource.clip);

		AudioClip newClip = usable [random.Next (usable.Count)];

		return newClip;
	}
	
	
	 // Function called when the enemy collides with another object

	
	/**
	*Lets end with something grim... the death script.
	*/
	
	void Die() {
		Destroy(gameObject);
	}
}
