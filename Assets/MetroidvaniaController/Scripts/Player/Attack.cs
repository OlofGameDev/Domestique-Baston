using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Update is called once per frame
    void Update()
    {
		if(canAttack && isMine)
        {
			// Attack 1 (Basic Attack)
			if (Input.GetKeyDown(KeyCode.X))
			{
				GroundedAttack(0, dmgValue1);
			}
			// Attack 2 (Kick)
			if (Input.GetKeyDown(KeyCode.C))
			{
				GroundedAttack(1, dmgValue2);
			}
			// Attack 3 (Power Attack)
			if(Input.GetKeyDown(KeyCode.V))
            {
				GroundedAttack(2, dmgValue3);
            }
		}

		/*if (Input.GetKeyDown(KeyCode.V))
		{
			GameObject throwableWeapon = Instantiate(throwableObject, transform.position + new Vector3(transform.localScale.x * 0.5f,-0.2f), Quaternion.identity) as GameObject; 
			Vector2 direction = new Vector2(transform.localScale.x, 0);
			throwableWeapon.GetComponent<ThrowableWeapon>().direction = direction; 
			throwableWeapon.name = "ThrowableWeapon";
		}*/
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
