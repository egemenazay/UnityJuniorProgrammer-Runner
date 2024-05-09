using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float obstacleSpeed;
    void Update()
    {
        if (PlayerController.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * obstacleSpeed);
            if (transform.position.y < -5)
            {
                Destroy(gameObject);
            }
        }
    }
}
