using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

	private AudioSource audioSource;
	private PlayerMovement playerMovement;

	void Start () {

		playerMovement = GameObject.FindGameObjectWithTag ("PlayerMovement").GetComponent<PlayerMovement>();

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			playerMovement.Damage (100);
		}

	}
}
