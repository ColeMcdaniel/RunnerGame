using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed;
	public float moveSpeedStore;
	public float speedMultiplier;

	public float speedIncreaseMilestone;
	public float speedIncreaseMilestoneStore;

	private float speedMilestoneCount;
	private float speedMilestoneCountStore;

	public float jumpForce;

	public float jumpTime;
	private float jumpTimeCounter;

	public int curHealth;
	public int maxHealth = 100;


	private Rigidbody2D myRigidbody;

	public bool grounded;
	public LayerMask whatIsGround;

	private Collider2D myCollider;

	public GameManager theGameManager;

	// Use this for initialization
	void Start()
	{
		myRigidbody = GetComponent<Rigidbody2D>();

		myCollider = GetComponent<Collider2D>();

		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMilestone;

		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
	}

	// Update is called once per frame
	void Update() 
	{

		grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

		if (transform.position.x > speedMilestoneCount) 
		{
			speedMilestoneCount += speedIncreaseMilestone;

			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			moveSpeed = moveSpeed * speedMultiplier;
		}

		myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
			if (grounded)
			{
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
			}

			if (curHealth > maxHealth) {
				curHealth = maxHealth;
			}
			if (curHealth <= 0) {
				Die();
			}
		}

		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) 
		{
			if(jumpTimeCounter > 0)
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if(Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0))
		{
			jumpTimeCounter = 0;
		}

		if (grounded) 
		{
			jumpTimeCounter = jumpTime;
		}
	}

	//		void FixedUpdate()
	//		{
	//			float h = Input.GetAxis("Horizontal");
	//
	//			rb2d.AddForce((Vector2.right * speed) * h);
	//
	//			if (rb2d.velocity.x > maxSpeed) 
	//			{
	//				rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
	//			}
	//
	//			if (rb2d.velocity.x < -maxSpeed) 
	//			{
	//				rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
	//			}
	//		}
	//
	void Die()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void Damage(int dmg)
	{
		//audioSource.Play();
		curHealth -= dmg;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "killbox")
		{
			theGameManager.RestartGame();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
		}
	}

	//		void OnTriggerEnter2D(Collider2D col)
	//		{
	//			if (col.CompareTag ("Coin")) 
	//			{
	//				gm.points += 1;
	//			}
	//		}
}