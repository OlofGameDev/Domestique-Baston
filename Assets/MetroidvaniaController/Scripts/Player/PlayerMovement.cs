using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	private bool canFlip = true;

	float horizontalMove = 0f;
	bool jump = false;
	bool duck = false;
	bool dash = false;
	bool block = false;

	//bool dashAxis = false;
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		// Set block and duck to false if the player moves
		if (horizontalMove != 0)
		{
			animator.SetBool("IsBlocking", false);
			animator.SetBool("IsDucking", false);
		}


		if (Input.GetKeyDown(KeyCode.Z))
		{
			jump = true;
		}
		if(Input.GetKeyDown(controller.duckKey))
        {
			duck = true;
        }
		if(Input.GetKeyDown(controller.blockKey))
        {
			block = true;
        }
		if(Input.GetKeyDown(KeyCode.E) && canFlip)
        {
			// Flip the character
			//controller.Flip();
			StartCoroutine(ResetFlip());
        }
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
	private IEnumerator ResetFlip()
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
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash, duck, block);
		jump = false;
		duck = false;
		dash = false;
		block = false;
	}
}
