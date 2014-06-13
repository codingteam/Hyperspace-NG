using UnityEngine;

public class DamageByCollision : MonoBehaviour {

	public float damage;
	public bool persistent;
	public GameObject blastFX;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Boundary") return;
		if(!persistent)
		{
			Destroy(gameObject);
			if(blastFX != null)
			{
				Instantiate(blastFX, transform.position, Quaternion.identity);
			}
		}
		Ship ship = other.GetComponent<Ship>();
		if (ship != null)
		{
			ship.HP -= damage;
			if(ship.HP <= 0)
			{
				Destroy(other.gameObject);
				Instantiate(ship.explosionFX, other.transform.position, Quaternion.identity);
			}
		}
	}
}
