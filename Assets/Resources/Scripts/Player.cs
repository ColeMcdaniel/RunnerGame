using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float maxSpeed = 500;
	public float speed = 1000f;
	public float jumpPower =35000f;

	public bool grounded;

	public int curHealth;
	public int maxHealth = 100;

	private Rigidbody2D rb2d;
	private Animator anim;
	private gameMaster gm;

	private AudioSource audioSource; 

	void Start () 
	{
		audioSource = GetComponent<AudioSource>();
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();

		curHealth = maxHealth;
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<gameMaster>();
	}

	void Update ()
	{

		anim.SetBool ("Grounded", grounded);
		anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));

		if (Input.GetAxis ("Horizontal") < -50f) {
			transform.localScale = new Vector3 (-390, 446, 300);
		}

		if (Input.GetAxis ("Horizontal") > 50f) {
			transform.localScale = new Vector3 (390, 446, 300);
		}

		if (Input.GetButtonDown ("Jump")) {
			rb2d.AddForce (Vector2.up * jumpPower);

			audioSource.Play();

		}

		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}
		if (curHealth <= 0) {
			Die ();
		}
	}

	void FixedUpdate()
	{

		float h = Input.GetAxis("Horizontal");

		rb2d.AddForce((Vector2.right * speed) * h);

		if (rb2d.velocity.x > maxSpeed) 
		{
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}

		if (rb2d.velocity.x < -maxSpeed) 
		{
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}
	}

	void Die()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void Damage(int dmg)
	{
		audioSource.Play();
		curHealth -= dmg;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Coin")) 
		{
			gm.points += 1;
		}
	}
}
