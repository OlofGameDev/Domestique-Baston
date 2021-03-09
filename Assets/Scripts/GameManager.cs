using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager master;
    public List<Transform> players = new List<Transform>();
    public Transform player1Spawn, player2Spawn;
    void Awake()
    {
        if (master != null) Destroy(this);
        else master = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            StartGame();
        }
        else if(Input.GetKeyDown(KeyCode.O))
        {
            ResetGame();
        }
    }
    public void SetPlayer(Transform playerTransform)
    {
        CharacterController2D controller = playerTransform.GetComponent<CharacterController2D>();
        // Set the player to the right spawnpoint
        if (controller.player == 1) playerTransform.position = player1Spawn.position;
        else if (controller.player == 2) playerTransform.position = player2Spawn.position;
        // Add the player to the list of players
        players.Add(playerTransform);

    }
    private void ResetPlayers()
    {
        foreach (Transform t in players)
        {
            CharacterController2D controller = t.GetComponent<CharacterController2D>();
            if (controller.player == 1) t.position = player1Spawn.position;
            else if (controller.player == 2) t.position = player2Spawn.position;

            controller.canMove = false;
            t.GetComponent<Attack>().canAttack = false;
            t.GetComponent<Health>().ResetHealth();
        }
    }
    public void ResetGame()
    {
        ResetPlayers();
    }
    private void StartGame()
    {
        foreach(Transform t in players)
        {
            CharacterController2D controller = t.GetComponent<CharacterController2D>();
            controller.canMove = true;
            t.GetComponent<Attack>().canAttack = true;

            // Set all animator bools to false to avoid character doing stuff like punching or jumping after spawn
            Animator animator = t.GetComponent<Animator>();
            string[] allBools = { "IsJumping", "IsAttacking", "IsDashing", "Hit", "IsWallSliding", "IsDead", "IsDucking", "IsBlocking" };
            foreach (string s in allBools)
            {
                animator.SetBool(s, false);
            }
        }
    }
}
