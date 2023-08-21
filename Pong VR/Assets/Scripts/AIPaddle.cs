using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public Rigidbody ball;
    public float speed = 5f;
    public float maxY = 4f;

    private void Update()
    {
        if (ball.velocity.x > 0)
        {
            float futureY = PredictBallYPosition();
            float newY = Mathf.Lerp(transform.position.y, futureY, speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(newY, -maxY, maxY), 0);
        }
    }

    private float PredictBallYPosition()
    {
        float distanceToPaddle = Mathf.Abs(transform.position.x - ball.position.x);
        float timeToReachPaddle = distanceToPaddle / Mathf.Abs(ball.velocity.x);
        float futureY = ball.position.y + (ball.velocity.y * timeToReachPaddle);
        return futureY;
    }
}

