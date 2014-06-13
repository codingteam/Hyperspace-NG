using UnityEngine;
using System.Collections.Generic;

public class GravitySource : MonoBehaviour {

	public float Mass;

	void Start()
	{
		var gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		gameController.gravitySources.Add(this);
	}

}
