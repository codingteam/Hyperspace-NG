using UnityEngine;
using System.Collections;

public class WeaponComponent : MonoBehaviour
{
	public float fireInterval;
	public GameObject shot;
	public float shotSpeed;

	private float reloadTime;
	private bool canFire;

	void Start()
	{
		canFire = true;
	}

	void Update()
	{
		if (!canFire)
		{
            reloadTime -= Time.deltaTime;
			if (reloadTime <= 0) canFire = true;
		}
	}

	public void Fire()
	{
		if(canFire)
		{
			var newShot = (GameObject)Instantiate(shot, transform.position, shot.transform.rotation);
			newShot.rigidbody.velocity = transform.parent.gameObject.rigidbody.velocity + transform.forward * shotSpeed;
        	reloadTime = fireInterval;
			canFire = false;
			audio.Play();
		}
	}
}

