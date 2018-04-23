using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{

	private AudioSource audioSource;

	public gameMaster gm;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log ("Coin touched!");
		audioSource.Play ();
		gm.points++;
		Destroy (gameObject, 0.5f);
	}
		
}
