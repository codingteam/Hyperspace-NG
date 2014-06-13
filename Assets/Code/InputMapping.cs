using UnityEngine;

public class InputMapping : MonoBehaviour {
	public delegate void InputAction();
	
	public KeyCode rotateCCW;
	public KeyCode rotateCW;
	public KeyCode accelerate;
	public KeyCode fire;

	public event InputAction OnInputRotateCCW;
	public event InputAction OnInputRotateCW;
	public event InputAction OnInputAccelerate;
	public event InputAction OnInputFire;

	public void Update()
	{
		if(Input.GetKey(rotateCCW) && OnInputRotateCCW != null)
		{
			OnInputRotateCCW();
		}

		if(Input.GetKey(rotateCW) && OnInputRotateCW != null)
		{
			OnInputRotateCW();
        }

		if(Input.GetKey(accelerate) && OnInputAccelerate != null)
		{
			OnInputAccelerate();
        }

		if(Input.GetKey(fire) && OnInputFire != null)
		{
			OnInputFire();
        }
	}
}

