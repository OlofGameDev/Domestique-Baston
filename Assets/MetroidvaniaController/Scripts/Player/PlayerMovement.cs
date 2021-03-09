using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	private Rigidbody2D RB;

	public float runSpeed = 40f;

	[HideInInspector] public bool canFlip = true;

	[HideInInspector] public float horizontalMove = 0f;
	[HideInInspector] public bool jump, duck, dash, block;


	[HideInInspector] public Vector2 m_Move = Vector2.zero;
    private void Awake()
    {
		RB = GetComponent<Rigidbody2D>();
    }
    //bool dashAxis = false;
    #region Called by input system
    public void OnMove(InputAction.CallbackContext context)
	{
		m_Move = context.ReadValue<Vector2>();
	}
	public void OnBlock(InputAction.CallbackContext context)
	{
		if(context.performed) block = context.performed;
	}
	public void OnJump(InputAction.CallbackContext context)
	{
		if (context.performed) jump = context.performed;
	}
	public void OnDuck(InputAction.CallbackContext context)
	{
		if (context.performed) duck = context.performed;
	}
	public void OnTurnAway(InputAction.CallbackContext context)
    {
		if(context.phase == InputActionPhase.Started && canFlip)
        {
			controller.isReverting = true;
			StartCoroutine(ResetFlip());
		}
		else if(context.phase == InputActionPhase.Canceled)
        {
			controller.isReverting = false;
		}
	}
    #endregion

    // Update is called once per frame
    void Update () {
		if (controller == null) return;
		if (!controller.canMove) return;
		horizontalMove = m_Move.x * runSpeed;

		/* Old duck and jump
		// If player is moving up, is grounded: jump is true
		jump = m_Move.y > 0 && controller.m_Grounded ? true : false;
		// If player is moving down, is grounded, jump is false: true 
		duck = m_Move.y < 0 && controller.m_Grounded && !jump ? true : false;
		*/

		float absValue = Mathf.Abs(horizontalMove);
		float animatorBlendValue;
		// Player is facing right
		if (controller.m_FacingRight)
		{
			// Player is walking forward direction
			if (horizontalMove >= 0) animatorBlendValue = absValue;
			// player is walking in the backing direction
			else
			{
				animatorBlendValue = -absValue * .7f;
				//Move slower when walking backwards
				horizontalMove *= .7f;
			}
		}
		// Player is facing left
		else
		{
			// Player is walking forward direction
			if (horizontalMove < 0) animatorBlendValue = absValue;
			// player is walking in the backing direction
			else
			{
				animatorBlendValue = -absValue * .7f;
				//Move slower when walking backwards
				horizontalMove *= .7f;
			}
		}
		float currentBlendValue = animator.GetFloat("Speed");
		// If player is changing direction, start blending from 0. Otherwise it will look wierd if player is walking forward and then switch to walking backwards (Forward animation would blend to idle and then to backwards)
		if (currentBlendValue > 0 && animatorBlendValue < 0 || currentBlendValue < 0 && animatorBlendValue > 0) currentBlendValue = 0;
		// Get a new blend value
		float newBlendValue = Mathf.MoveTowards(currentBlendValue, animatorBlendValue, 50 * Time.deltaTime);
		animator.SetFloat("Speed", newBlendValue);
		// Set block and duck to false if the player moves (break out of the duck/block)
		if (horizontalMove != 0)
		{
			animator.SetBool("IsBlocking", false);
			animator.SetBool("IsDucking", false);
			RigidBodySettings(true);
		}
		else RigidBodySettings(false);
		/*if (Input.GetKeyDown(KeyCode.C))
		{
			dash = true;
		}*/

		/*if (Input.GetAxisRaw("Dash") == 1 || Input.GetAxisRaw("Dash") == -1) //RT in Unity 2017 = -1, RT in Unity 2019 = 1
		{
			if (dashAxis == false)
			{
				dashAxis = true;
				dash = true;
			}
		}
		else
		{
			dashAxis = false;
		}
		*/
	}
	void RigidBodySettings(bool moving)
    {
		if(moving)
		{
			/*RB.constraints = RigidbodyConstraints2D.None;
			RB.constraints = RigidbodyConstraints2D.FreezeRotation;*/
			RB.mass = 1;
		}
		else
        {
			/*RB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;*/
			RB.mass = 10;
		}
    }
	public IEnumerator ResetFlip()
    {
		canFlip = false;
		yield return new WaitForSeconds(0.25f);
		canFlip = true;
    }

	public void OnFall()
	{
		animator.SetBool("IsJumping", true);
		controller.airborn = true;
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
		controller.airborn = false;
	}

	void FixedUpdate ()
	{
		if (controller == null) return;
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash, duck, block);
		jump = false;
		duck = false;
		dash = false;
		block = false;
	}
}
