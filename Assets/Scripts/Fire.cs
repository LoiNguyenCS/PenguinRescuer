using System.Collections;
using UnityEngine;
using System;
using System.Timers;


public class Fire : MonoBehaviour
{
    public float triggerDistance = 2f;
    public float disappearDuration = 5f;
    private float timer = 0f;
    private Transform player;
    private float elapsedTime = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found. Make sure to tag your player object with 'Player'");
        }
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < triggerDistance)
        {
            DisableObstacles();
            Destroy(gameObject);
        }
    }

    void DisableObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        obstacles[0].SetActive(false);
    }
}
