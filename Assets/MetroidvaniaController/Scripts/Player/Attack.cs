using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public enum AttackType
{
	KICK,
	PUNCH,
	RANGED
}
public class Attack : MonoBehaviour
{
	public float dmgValue1 = 4, dmgValue2 = 3, dmgValue3 = 7;
	private float currentDmgValue;
	public GameObject throwableObject;
	public Transform attackCheck;
	private Rigidbody2D m_Rigidbody2D;
	public Animator animator;
	public bool canAttack = true;
	public bool isTimeToCheck = false;
	public bool isMine = true;

	public GameObject cam;
	public CharacterController2D controller;

	public InputAction moveAction;

	private bool punch = false, kick = false, ranged = false;
	public bool punchHeld = false, kickHeld = false, rangedHeld = false;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }
	void GroundedAttack(float blendValue, float dmgValue)
    {
		currentDmgValue = dmgValue;
		canAttack = false;
		animator.SetBool("IsAttacking", true);
		animator.SetFloat("AttackBlend", blendValue);
		StartCoroutine(AttackCooldown());
	}
    #region Called by input system
	private void AllAttacks(InputAction.CallbackContext context, AttackType attackType)
    {
		switch (context.phase)
		{
			case InputActionPhase.Started:
				if (context.interaction is HoldInteraction)
				{
					// If the player holds we want to check for combos
					if (attackType == AttackType.PUNCH) punchHeld = true;
					else if (attackType == AttackType.KICK) kickHeld = true;
					else if (attackType == AttackType.RANGED) rangedHeld = true;
					print($"{attackType.ToString().ToLowerInvariant()} started");
				}
				else if (context.interaction is PressInteraction)
				{
					if(canAttack)
                    {
						if (attackType == AttackType.PUNCH) punch = true;
						else if (attackType == AttackType.KICK) kick = true;
						else if (attackType == AttackType.RANGED) ranged = true;
						print($"{attackType.ToString().ToLowerInvariant()} pressed and attacking!");
					}
					else print($"{attackType.ToString().ToLowerInvariant()} pressed but can't attack!");

				}
				break;
			case InputActionPhase.Performed:
				if (context.interaction is HoldInteraction)
				{
					//StartCoroutine(BurstFire((int)(context.duration * burstSpeed))); // Use this for inspiration
					if (attackType == AttackType.PUNCH) punchHeld = false;
					else if (attackType == AttackType.KICK) kickHeld = false;
					else if (attackType == AttackType.RANGED) rangedHeld = false;
					print($"{attackType.ToString().ToLowerInvariant()} performed");
				}
				break;
			case InputActionPhase.Canceled:
				if (context.interaction is HoldInteraction)
				{
					if (attackType == AttackType.PUNCH) punchHeld = false;
					else if (attackType == AttackType.KICK) kickHeld = false;
					else if (attackType == AttackType.RANGED) rangedHeld = false;
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

	private void FixedUpdate()
	{
		if(canAttack)
        {
			// Combos
			if (punchHeld || rangedHeld || kickHeld)
			{
				// Punch and scream
				if (punchHeld && rangedHeld && !kickHeld)
				{
					GroundedAttack(2, dmgValue3);
				}
				// Punch and kick
				else if (punchHeld && !rangedHeld && kickHeld)
				{
					// Not implemented
				}
			}

			// Singles
			if (punch)
			{
				GroundedAttack(0, dmgValue1);
			}
			else if (kick)
			{
				GroundedAttack(1, dmgValue2);
			}
			else if (ranged)
			{
				// Not implemented
			}
			// Reset the bools
			punch = kick = ranged = false;
		}
	}
   

	IEnumerator AttackCooldown()
	{
		//yield return new WaitForSeconds(0.25f);
		yield return new WaitUntil( () => !animator.GetBool("IsAttacking"));
		canAttack = true;
	}

	public void DoDashDamage()
	{
		currentDmgValue = Mathf.Abs(dmgValue1);
		Collider2D[] collidersEnemies = Physics2D.OverlapCircleAll(attackCheck.position, 0.9f);
		for (int i = 0; i < collidersEnemies.Length; i++)
		{
			if (collidersEnemies[i].gameObject.tag == "Player" && collidersEnemies[i].transform != transform)
			{
				if (collidersEnemies[i].transform.position.x - transform.position.x < 0)
				{
					currentDmgValue = -currentDmgValue;
				}
				collidersEnemies[i].gameObject.SendMessage("ApplyDamage", currentDmgValue);
				cam.GetComponent<CameraFollow>().ShakeCamera();
			}
		}
	}
}
