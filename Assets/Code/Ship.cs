using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
	public float HP;
	public WeaponComponent[] weapons;
	public GameObject explosionFX;
	public float rotationSpeed;
	public float thrust;

	void Update()
	{
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(Vector3.up, -rotationSpeed*Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(Vector3.up, rotationSpeed*Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			rigidbody.velocity += transform.forward * thrust*Time.deltaTime / rigidbody.velocity.magnitude;
		}
		
		if(Input.GetKey(KeyCode.Space))
		{
            foreach(var weapon in weapons)
			{
				weapon.Fire();
			}
		}
	}
}

