using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    public bool goDestination = false;
    Vector3 offset;
    Waypoints Wpoints;
    int waypointIndex = 0;
    float goalDistance;
    Vector3 previousPosition;
    Vector3 goalDirection;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        // gets the offset of the gameObject and the part to go on the track
        offset = gameObject.transform.GetChild(0).position - transform.position;

        // Gets the array of positions for the map
        Wpoints = GameObject.FindObjectOfType<Waypoints>();

        // Sets the offset to the track
        transform.position = Wpoints.waypoints[waypointIndex].position - offset;

        // Moves to the next index
        if (goDestination)
            waypointIndex = Wpoints.waypoints.Length - 1;
        else
            ++waypointIndex;

        // gets the distance from the current position to the end position 
        goalDistance = Vector2.Distance(offset + transform.position, Wpoints.waypoints[waypointIndex].position);

        // gets the direction the current position to the end position 
        goalDirection = (Wpoints.waypoints[waypointIndex].position - offset - transform.position).normalized;

        animator.SetFloat("x", goalDirection.x);
        animator.SetFloat("y", goalDirection.y);

        // gets the position before it started to move
        previousPosition = transform.position + offset;
    }

    private void Update()
    {
        // moves the translation in a certain direction
        transform.Translate(goalDirection * speed * Time.deltaTime);

        // adjests the direction and distance for everytime it 
        while (Vector2.Distance(previousPosition, transform.position + offset) >= goalDistance)
        {
            // checks if the waypoint index is done
            if (waypointIndex < Wpoints.waypoints.Length - 1)
            {
                // sets the position to adjust for any offset the 
                transform.position = (Wpoints.waypoints[waypointIndex].position + Vector2.Distance(transform.position + offset, Wpoints.waypoints[waypointIndex].position) * (Wpoints.waypoints[waypointIndex + 1].position - Wpoints.waypoints[waypointIndex].position).normalized) - offset;

                // Moves to the next index
                ++waypointIndex;

                // gets the distance from the last position to the end position 
                goalDistance = Vector2.Distance(Wpoints.waypoints[waypointIndex - 1].position, Wpoints.waypoints[waypointIndex].position);
                // gets the direction the last position to the end position 
                goalDirection = (Wpoints.waypoints[waypointIndex].position - Wpoints.waypoints[waypointIndex - 1].position).normalized;

                animator.SetFloat("x", goalDirection.x);
                animator.SetFloat("y", goalDirection.y);

                // gets the position before it started to move
                previousPosition = transform.position + offset;
            }
            else
            {
                SoundManager.PlaySound(SoundManager.Sound.LifeLost);
                PlayerStats.reduceLives(1);
                --WaveSpawner.EnemiesAlive;
                Destroy(gameObject);
                break;
            }
        }
    }
    public float DistanceFromStart()
    {
        float distance = 0f;
        for(int i = 0; i < waypointIndex - 1; i++)
        {
            distance += Vector2.Distance(Wpoints.waypoints[i].position, Wpoints.waypoints[i + 1].position);
        }
        return distance + Vector2.Distance(Wpoints.waypoints[waypointIndex - 1].position, transform.position);
    }
}
