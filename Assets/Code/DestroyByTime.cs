using UnityEngine;

public class DestroyByTime : MonoBehaviour {

	public float timeToLive;

	void Start()
	{
		Destroy(this.gameObject,timeToLive);
	}
}
