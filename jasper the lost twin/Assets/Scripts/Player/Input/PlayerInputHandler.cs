using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

	public Vector2 MovementInput {get; set;}
	public int InputX{get; set;}
	public int InputY{get; set;}
	
	public void OnMoveInput(InputAction.CallbackContext context)
	{
		Debug.Log(MovementInput);
		MovementInput = context.ReadValue<Vector2>();
		InputX = (int)MovementInput.x;
		InputY = (int)MovementInput.y;
	}
	
	public void OnJumpInput(InputAction.CallbackContext context)
	{
	
	}
}
