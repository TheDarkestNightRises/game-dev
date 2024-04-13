﻿using System.Collections;
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
	private float dashInputStartTime;
	public bool JumpInput { get; set; }
	public bool JumpInputStop { get; set; }
	public bool PrimaryAttackInput { get; set; }
	public bool SecondaryAttackInput { get; set; }
	public bool DashInput {get; set;}
	public bool DashInputStop {get; set;}
	
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

	public void OnDashInput(InputAction.CallbackContext context)
	{
		if(context.started)
		{
			DashInput = true;
			DashInputStop = false;
			dashInputStartTime = Time.time;
		}
		else if(context.canceled) 
		{
			DashInputStop = true;
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
		CheckDashInputHoldTime();
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
	
	public void UseDashInput() => DashInput = false;
	
	
	private void CheckJumpInputHoldTime()
	{
		if (Time.time >= jumpInputStartTime + inputHoldTime)
		{
			JumpInput = false;
		}
	}
	
	private void CheckDashInputHoldTime()
	{
		if (Time.time >= dashInputStartTime + inputHoldTime)
		{
			DashInput = false;
		}	
	}
}

public enum CombatInputs
{
	primary,
	secondary
}
