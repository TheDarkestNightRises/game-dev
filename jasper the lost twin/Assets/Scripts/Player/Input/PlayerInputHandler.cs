using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

	public Vector2 MovementInput {get; set;}
	public int InputX{get; set;}
	public int InputY{get; set;}
	[SerializeField]
	private float inputHoldTime = 0.2f;
	private float jumpInputStartTime;
	public bool JumpInput { get; set; }
	public bool JumpInputStop { get; set; }
	public bool PrimaryAttackInput { get; set; }
	public bool SecondaryAttackInput { get; set; }
	
	public void OnPrimaryAttackInput(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			PrimaryAttackInput = true;
		}
		
		if (context.canceled)
		{
			PrimaryAttackInput = false;
		}
	}
		
	public void OnSecondaryAttackInput(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			SecondaryAttackInput = true;
		}
		
		if (context.canceled)
		{
			SecondaryAttackInput = false;
		}
	}

	public void OnMoveInput(InputAction.CallbackContext context)
	{
		MovementInput = context.ReadValue<Vector2>();
		InputX = (int)MovementInput.x;
		InputY = (int)MovementInput.y;
	}
	
	protected void Update()
	{
		CheckJumpInputHoldTime();
	}
	
	public void OnJumpInput(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			JumpInput = true;
			JumpInputStop = false;
			jumpInputStartTime = Time.time;
		}

		if (context.canceled)
		{
			JumpInputStop = true;
		}
	}

	
	public void UseJumpInput() => JumpInput = false;
	
	private void CheckJumpInputHoldTime()
	{
		if (Time.time >= jumpInputStartTime + inputHoldTime)
		{
			JumpInput = false;
		}
	}
}

public enum CombatInputs
{
	primary,
	secondary
}
