using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public float initialForce = 5f;
    public Vector2 spawnPosition;

    private void Start()
    {
        SpawnBall();
    }

    private void SpawnBall()
    {
        GameObject newBall = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D ballRigidbody = newBall.GetComponent<Rigidbody2D>(); //Had to add <Rigidbody2D>

        float angle = Random.Range(30, 150) * Mathf.Deg2Rad;
        Vector2 forceDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        ballRigidbody.AddForce(forceDirection * initialForce, ForceMode2D.Impulse);
    }
}

