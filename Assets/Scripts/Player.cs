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

	BoxCollider2D collider;

	Rigidbody2D rigidBody;

	Object lazerPrefab;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
		collider = GetComponent<BoxCollider2D> ();
		rigidBody = GetComponent<Rigidbody2D> ();
		lazerPrefab = Resources.Load ("Lazer");
	}
	
	void Update () {

		float moveSpeed = speed * Time.deltaTime;


		//WASD Keys
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			transform.position += new Vector3 (0, moveSpeed);
		}
		else
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += new Vector3 (-moveSpeed, 0);
		}
		else
		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			transform.position += new Vector3 (0, -moveSpeed);
		}
		else
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			transform.position += new Vector3 (moveSpeed, 0);
		}

		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) {
			if (canShoot) {
				StartCoroutine(Shoot ());
				Instantiate(bullet, transform.position, Quaternion.identity);
			}
		}

		//Look at mouse
		Vector3 mouse = Input.mousePosition;
		Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
		Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
		float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, angle);
	}

	/// <summary>
	/// Shoots the lazer projectile with a cooldown
	/// </summary>
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

	/// <summary>
	/// Raises the trigger event.
	/// TODO: collision event for AI
	/// </summary>
	void OnTriggerEnter2D()
	{
	}

	/// <summary>
	/// Death event
	/// TODO: Cool shit
	/// </summary>
	void OnDeath() {
		Destroy(gameObject);
	}
}
