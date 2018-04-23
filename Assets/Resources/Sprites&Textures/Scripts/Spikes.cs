﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	private AudioSource audioSource;
	private Player player;

	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			player.Damage (100);
		}

	}
}
