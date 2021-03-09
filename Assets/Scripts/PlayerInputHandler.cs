using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private CharacterController2D controller;
	private Attack attackScript;
	private PlayerMovement movementScript;
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        var controllers = FindObjectsOfType<CharacterController2D>();
        var index = playerInput.playerIndex;
        // Player 1 has index 0. Player 2 has index 1.
        controller = controllers.FirstOrDefault(m => m.player == index - 1);
		attackScript = controller.GetComponent<Attack>();
		movementScript = controller.GetComponent<PlayerMovement>();
    }
	#region Attack inputs
	private void AllAttacks(InputAction.CallbackContext context, AttackType attackType)
	{
		switch (context.phase)
		{
			case InputActionPhase.Started:
				if (context.interaction is HoldInteraction)
				{
					// If the player holds we want to check for combos
					if (attackType == AttackType.PUNCH) attackScript.punchHeld = true;
					else if (attackType == AttackType.KICK) attackScript.kickHeld = true;
					else if (attackType == AttackType.RANGED) attackScript.rangedHeld = true;
					print($"{attackType.ToString().ToLowerInvariant()} started");
				}
				else if (context.interaction is PressInteraction)
				{
					if (attackScript.canAttack)
					{
						if (attackType == AttackType.PUNCH) attackScript.punch = true;
						else if (attackType == AttackType.KICK) attackScript.kick = true;
						else if (attackType == AttackType.RANGED) attackScript.ranged = true;
						print($"{attackType.ToString().ToLowerInvariant()} pressed and attacking!");
					}
					else print($"{attackType.ToString().ToLowerInvariant()} pressed but can't attack!");

				}
				break;
			case InputActionPhase.Performed:
				if (context.interaction is HoldInteraction)
				{
					//StartCoroutine(BurstFire((int)(context.duration * burstSpeed))); // Use this for inspiration
					if (attackType == AttackType.PUNCH) attackScript.punchHeld = false;
					else if (attackType == AttackType.KICK) attackScript.kickHeld = false;
					else if (attackType == AttackType.RANGED) attackScript.rangedHeld = false;
					print($"{attackType.ToString().ToLowerInvariant()} performed");
				}
				break;
			case InputActionPhase.Canceled:
				if (context.interaction is HoldInteraction)
				{
					if (attackType == AttackType.PUNCH) attackScript.punchHeld = false;
					else if (attackType == AttackType.KICK) attackScript.kickHeld = false;
					else if (attackType == AttackType.RANGED) attackScript.rangedHeld = false;
					print($"{attackType.ToString().ToLowerInvariant()} canceled");
				}
				break;
		}
	}
	public void OnPunch(InputAction.CallbackContext context)
	{
		AllAttacks(context, AttackType.PUNCH);
	}
	public void OnKick(InputAction.CallbackContext context)
	{
		AllAttacks(context, AttackType.KICK);
	}
	public void OnRanged(InputAction.CallbackContext context)
	{
		AllAttacks(context, AttackType.RANGED);
	}
	#endregion
	#region Move Inputs
	public void OnMove(InputAction.CallbackContext context)
	{
		movementScript.m_Move = context.ReadValue<Vector2>();
	}
	public void OnBlock(InputAction.CallbackContext context)
	{
		if (context.performed) movementScript.block = context.performed;
	}
	public void OnJump(InputAction.CallbackContext context)
	{
		if (context.performed) movementScript.jump = context.performed;
	}
	public void OnDuck(InputAction.CallbackContext context)
	{
		if (context.performed) movementScript.duck = context.performed;
	}
	public void OnTurnAway(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Started && movementScript.canFlip)
		{
			controller.isReverting = true;
			StartCoroutine(movementScript.ResetFlip());
		}
		else if (context.phase == InputActionPhase.Canceled)
		{
			controller.isReverting = false;
		}
	}
	#endregion

}