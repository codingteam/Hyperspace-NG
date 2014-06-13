using UnityEngine;

public class ToroidalWrappingBoundary : MonoBehaviour {

	public float minX,maxX,minZ,maxZ;
	public bool autoAdjusting;

	void Start()
	{
		if(autoAdjusting)
		{
			var xSize = transform.lossyScale.x;
			var zSize = transform.lossyScale.z;

			minX = -xSize/2 + transform.position.x + 1;
			maxX = xSize/2 + transform.position.x - 1 ;

			minZ = -zSize/2 + transform.position.z + 1;
			maxZ = zSize/2 + transform.position.z - 1;
		}
	}

	void OnTriggerExit(Collider other)
	{
		var otherPosition = other.transform.position;

		if(otherPosition.x < minX) otherPosition.x = maxX;
		if(otherPosition.x > maxX) otherPosition.x = minX;

		if(otherPosition.z < minZ) otherPosition.z = maxZ;
		if(otherPosition.z > maxZ) otherPosition.z = minZ;

		other.transform.position = otherPosition;
	}

}
