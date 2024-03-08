using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
	
	public Vector2 MovementInput { get; set; }
	
	
	public void OnMoveInput(InputAction.CallbackContext context)
	{
		MovementInput = context.ReadValue<Vector2>();
		Debug.Log(MovementInput);
	}
	
	public void OnJumpInput(InputAction.CallbackContext context)
	{
		if(context.started)
		{
			Debug.Log("Jumped");
		}
		if (context.performed)
		{
			Debug.Log("Jump is being held down");
		}
		if(context.canceled)
		{
			Debug.Log("Jump button has been released");
		}

		Debug.Log("Jump input");
	}
}
