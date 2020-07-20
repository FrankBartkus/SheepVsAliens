using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    private Waypoints Wpoints;
    private int waypointIndex = 0;
    private Vector3 startingPosition;
    private float goalDistance;
    private Vector3 goalDirection;

    void Start()
    {
        Wpoints = GameObject.FindObjectOfType<Waypoints>();
        transform.position = Wpoints.waypoints[waypointIndex].position;
        startingPosition = transform.position;
        ++waypointIndex;
        goalDistance = Vector2.Distance(startingPosition, Wpoints.waypoints[waypointIndex].position);
        goalDirection = (Wpoints.waypoints[waypointIndex].position - transform.position).normalized;
    }

    private void Update()
    {
        transform.position += goalDirection * speed * Time.deltaTime;
        while(Vector2.Distance(startingPosition, transform.position) >= goalDistance)
        {
            if (waypointIndex < Wpoints.waypoints.Length - 1)
            {
                transform.position = Wpoints.waypoints[waypointIndex].position + Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) * (Wpoints.waypoints[waypointIndex + 1].position - Wpoints.waypoints[waypointIndex].position).normalized;
                waypointIndex++;
                startingPosition = transform.position;
                goalDistance = Vector2.Distance(startingPosition, Wpoints.waypoints[waypointIndex].position);
                goalDirection = (Wpoints.waypoints[waypointIndex].position - startingPosition).normalized;
            } 
            else
            {
                Destroy(gameObject);
                break;
            }
        }
    }
}
