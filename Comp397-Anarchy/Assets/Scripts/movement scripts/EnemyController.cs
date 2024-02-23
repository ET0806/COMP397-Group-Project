using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

 //This is an Enemy ai pathfinder too but it is a bit fast
public class EnemyController : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform

    private NavMeshAgent navMeshAgent;
    private bool isChasing = false;
    private float originalChaseSpeed;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            Debug.LogError("Player reference not set in the inspector!");
        }

        // Store the original chase speed for later use
        originalChaseSpeed = navMeshAgent.speed;
    }

    void Update()
    {
        if (player != null)
        {
            if (CanSeePlayer())
            {
                ChasePlayer();
            }
            else
            {
                StopChasing();
            }
        }
    }

    bool CanSeePlayer()
    {
        // Implement your own line of sight check here if needed
        // For example, use Raycast to check if there are obstacles between enemy and player
        return true;
    }

    void ChasePlayer()
    {
        isChasing = true;
        navMeshAgent.SetDestination(player.position);
    }

    void StopChasing()
    {
        isChasing = false;
        // Stop the enemy from moving
        navMeshAgent.ResetPath();
    }

    // Public method to set the chase speed dynamically
    public void SetChaseSpeed(float newChaseSpeed)
    {
        // Update the chase speed
        navMeshAgent.speed = newChaseSpeed;
    }

    // Public method to reset the chase speed to its original value
    public void ResetChaseSpeed()
    {
        // Reset to the original chase speed
        navMeshAgent.speed = originalChaseSpeed;
    }
}




