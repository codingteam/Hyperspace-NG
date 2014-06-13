using UnityEngine;

public class Ship : MonoBehaviour
{
	public float HP;
	public WeaponComponent[] weapons;
	public GameObject explosionFX;
	public float rotationSpeed;
	public float thrust;

	public InputMapping input;

	private void RotateCCW()
	{
		transform.Rotate(Vector3.up, -rotationSpeed*Time.deltaTime);
	}

	private void RotateCW()
	{
		transform.Rotate(Vector3.up, rotationSpeed*Time.deltaTime);
    }

	private void Accelerate()
	{
		//NOTE The acceleration is divided by velocity to impose a soft limit on max speed.
		rigidbody.velocity += transform.forward * thrust*Time.deltaTime / rigidbody.velocity.magnitude;
	}

	private void Fire()
	{
		foreach(var weapon in weapons)
		{
			weapon.Fire();
        }
    }

	void OnEnable()
	{
		input.OnInputRotateCCW += RotateCCW;
		input.OnInputRotateCW += RotateCW;
		input.OnInputAccelerate += Accelerate;
		input.OnInputFire += Fire;
	}

	void OnDisable()
	{
		input.OnInputRotateCCW -= RotateCCW;
		input.OnInputRotateCW -= RotateCW;
		input.OnInputAccelerate -= Accelerate;
		input.OnInputFire -= Fire;
	}	
}

