﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    [SerializeField] public List<Transform> waypoints = new List<Transform>();

    [SerializeField] WaveConfig waveConfig;

    // Saves the waypoint in which we want to go
    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.Find("wibble");
        if (go)
        {
            Debug.Log(go.name);
        }
        else
        {
            Debug.Log("No game object called wibble found!");
        }

        // Get the List waypoints from waveConfig
       waypoints = waveConfig.GetWaypoints();

        // Set the start position of Enemy to the 1st waypoint position
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        //   0, 1, 2      <=    2
        if (waypointIndex <= waypoints.Count - 1)
        {
            // Set the target position to the waypoint where we want to go
            var targetPosition = waypoints[waypointIndex].transform.position;

            // Make sure that z axis is 0
            targetPosition.z = 0f;

            var enemyMovement = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;

            // Move enemy from current position to target position at enemyMovement speed
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyMovement);

            // If the enemy reaches the target waypoint
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }

        // If enemy reaches last waypoint
        else
        {
            Destroy(gameObject);
        }
    }

    // Set a WaveConfig
    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet; 
    }
}