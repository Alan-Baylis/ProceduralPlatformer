﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Released under Creative Commons License by Alonzo Machiraju, 2017

public class GemBehavior : MonoBehaviour {

	public int value = 100;

	public ParticleSystem pickupEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player") // Only the player can pick something up and score!
		{	
			// Play effect on pickup
			if (pickupEffect) Instantiate<ParticleSystem>(pickupEffect, transform.position, transform.rotation * Quaternion.Euler(-90.0f, 0.0f, 0.0f));

			// Update player score here

			PlayerStatus playerStatus = other.GetComponent<PlayerStatus>();
			playerStatus.Score += value;

			// Remove so that we don't pick it up twice!
			Destroy(gameObject);
		}
	}
}
