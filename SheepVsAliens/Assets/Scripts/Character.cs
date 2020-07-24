using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    Vector3 offset;
    Waypoints Wpoints;
    int waypointIndex = 0;
    float goalDistance;
    Vector3 previousPosition;
    Vector3 goalDirection;

    void Start()
    {
        offset = gameObject.transform.GetChild(0).position - transform.position;
        Wpoints = GameObject.FindObjectOfType<Waypoints>();
        transform.position = Wpoints.waypoints[waypointIndex].position - offset;
        ++waypointIndex;
        goalDistance = Vector2.Distance(offset + transform.position, Wpoints.waypoints[waypointIndex].position);
        goalDirection = (Wpoints.waypoints[waypointIndex].position - offset - transform.position).normalized;
        previousPosition = transform.position + offset;
    }

    private void Update()
    {
        transform.Translate(goalDirection* speed * Time.deltaTime);
        while (Vector2.Distance(previousPosition, transform.position + offset) >= goalDistance)
        {
            if (waypointIndex < Wpoints.waypoints.Length - 1)
            {
                transform.position = (Wpoints.waypoints[waypointIndex].position + Vector2.Distance(transform.position + offset, Wpoints.waypoints[waypointIndex].position) * (Wpoints.waypoints[waypointIndex + 1].position - Wpoints.waypoints[waypointIndex].position).normalized) - offset;
                ++waypointIndex;
                goalDistance = Vector2.Distance(offset + transform.position, Wpoints.waypoints[waypointIndex].position);
                goalDirection = (Wpoints.waypoints[waypointIndex].position - offset - transform.position).normalized;
                previousPosition = transform.position + offset;
            }
            else
            {
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
