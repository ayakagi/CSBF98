﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript1 : MonoBehaviour {

	static Rigidbody rb;
	public static Vector3 diceVelocity;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

    // Update is called once per frame
    void Update() {
        diceVelocity = rb.velocity;
    }

	public void Roll1() {
		DiceNumberTextScript.diceNumber1 = 0;
		float dirX = Random.Range (0, 500);
		float dirY = Random.Range (0, 500);
		float dirZ = Random.Range (0, 500);
		transform.position = new Vector3 (-21, 6, 19);
		transform.rotation = Quaternion.identity;
		rb.AddForce (transform.up * 500);
		rb.AddTorque (dirX, dirY, dirZ);
	}
}

