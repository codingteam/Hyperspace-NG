using UnityEngine;
using System.Collections;

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
}

