using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BoolReplacement
{
    FALSE,
    TRUE
}
public class Health : MonoBehaviour
{
    public float currentHealth = 100;
    public float maxHealth = 100;
    public Image fillImage;
    private Animator animator;
    private CharacterController2D controller;
    /*[HideInInspector]*/ public bool blockActive, jumpActive, duckActive;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (controller.player == 1) fillImage = GameObject.Find("Fill P1").GetComponent<Image>();
        else if (controller.player == 2) fillImage = GameObject.Find("Fill P2").GetComponent<Image>();
        fillImage.fillAmount = currentHealth / maxHealth;
    }
    public void ApplyDamage(float value, AttackType attackType)
    {
        print("starting ApplyDamage method");
        // Add checks to see if the player is blocking the attacks
        // Not implemented
        bool isProtected = false;
        // If this is a kick or punch and the player is facing the attacker
        if((attackType == AttackType.KICK || attackType == AttackType.PUNCH))
        {
            if (controller != null && !controller.isReverting && blockActive) isProtected = true;
        }
        // If this is a ranged attack
        else if(attackType == AttackType.RANGED)
        {
            // If player is jumping or ducking
            if (jumpActive || duckActive) isProtected = true;
        }

        // Player is blocking the attack
        if(isProtected)
        {
            // Play blocking sound
            print("is protected from damage");        }
        // Player is not blocking the attack
        else
        {
            // Play hit sound
            print("is NOT protected from damage");
            // Check if this game object has a controller attached
            if (controller != null)
            {
                // If the player is facing the opponent
                if (!controller.isReverting)
                {
                    // If player is taking damage from punches or kicks, do regular damage
                    if (attackType != AttackType.RANGED) currentHealth -= value;
                    // Player is facing away from ranged (insults), do half the regular damage
                    else currentHealth -= value / 2;
                }
                // If the player is facing away from the opponent, apply doubble damage
                else
                {
                    // If player is taking damage from punches or kicks, do double damage
                    if (attackType != AttackType.RANGED) currentHealth -= value * 2;
                    // Player is facing opponent when taking ranged (insults), do regular damage
                    else currentHealth -= value;
                }
            }
            else currentHealth -= value;
            // Make sure health doesn't go below 0
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animator.SetBool("IsDead", true);
                controller.canMove = false;
                GetComponent<Attack>().canAttack = false;
                controller.m_Rigidbody2D.isKinematic = true;
                GetComponent<Collider2D>().enabled = false;
            }
            // Set the new fill amount
            fillImage.fillAmount = currentHealth / maxHealth;
            // If player is not already in the hit animation, play the hit animation
            if (!animator.GetBool("Hit")) animator.SetBool("Hit", true);
        }
    }
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        fillImage.fillAmount = currentHealth / maxHealth;
        controller.m_Rigidbody2D.isKinematic = false;
        GetComponent<Collider2D>().enabled = true;
        animator.SetBool("IsDead", false);
    }
    public void SetBlock(BoolReplacement value)
    {
        if (value == BoolReplacement.TRUE) blockActive = true;
        else blockActive = false;
    }
    public void SetJump(BoolReplacement value)
    {
        if (value == BoolReplacement.TRUE) jumpActive = true;
        else jumpActive = false;
    }
    public void SetDuck(BoolReplacement value)
    {
        if (value == BoolReplacement.TRUE) duckActive = true;
        else duckActive = false;
    }
}
