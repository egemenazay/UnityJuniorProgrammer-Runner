using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private Vector3 _spawnPos;
    public float repeatWidth;
    void Start()
    {
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        _spawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.gameOver == false)
        {
            if (transform.position.x < _spawnPos.x - repeatWidth)
            {
                transform.position = _spawnPos;
            }
        }
    }
}
