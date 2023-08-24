using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public float spawnDelay = 2.0f;
    public float ballSpeed = 5.0f;

    private void Start()
    {
        StartCoroutine(SpawnBall());
    }

    private IEnumerator SpawnBall()
    {
        yield return new WaitForSeconds(spawnDelay);

        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        Rigidbody ballRigidbody = ball.GetComponent();

        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        ballRigidbody.velocity = randomDirection * ballSpeed;
    }
}


