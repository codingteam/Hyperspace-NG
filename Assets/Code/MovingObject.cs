﻿using UnityEngine;
using System.Collections.Generic;

public class MovingObject : MonoBehaviour {

	private List<GravitySource> gravitySources;
	public bool alignToMovement;

	void Start()
	{
		var gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		gravitySources = gameController.gravitySources;
		rigidbody.freezeRotation = true;
		Align ();
	}

	void FixedUpdate()
	{
		foreach (var gravitySource in gravitySources)
		{
			Vector3 heading = gravitySource.transform.position - transform.position;
			float distance = heading.magnitude;
			Vector3 gravityForce = heading.normalized * gravitySource.Mass / (distance * distance);
			rigidbody.velocity += gravityForce;
		}
		transform.position =
			new Vector3(transform.position.x,
			            0,
			            transform.position.z);
	}

	void Align()
	{
		if(alignToMovement)
		{
			Vector3 direction = new Vector3(rigidbody.velocity.x,
			                                0,
			                                rigidbody.velocity.z);
			Vector3 eulerAngles = Quaternion.LookRotation(direction).eulerAngles;
			eulerAngles.x = 90;
			eulerAngles.z = 0;
            transform.rotation = Quaternion.Euler(eulerAngles);
        }
	}

	void Update()
	{
		Align ();
	}

}
