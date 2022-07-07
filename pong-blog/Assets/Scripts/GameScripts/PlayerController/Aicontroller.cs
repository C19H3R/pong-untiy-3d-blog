using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Pong.Game.GameObjects;
using Pong.Game.GameObjects.Commands;
using Pong.Game.Interfaces;

public class Aicontroller : MonoBehaviour
{
    [SerializeField]
    PongBallGO ball;
    [SerializeField]
    PongPaddleGO paddle;

    IPongCommand up;
    IPongCommand down;

    // Start is called before the first frame update
    void Start()
    {
        up = new PaddleMoveUpCommand(paddle);
        down = new PaddleMoveDownCommand(paddle);

    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.y > paddle.transform.position.y)
        {
            up.Invoke();
        }
        else if (ball.transform.position.y < paddle.transform.position.y)
        {
            down.Invoke();
        }
        
    }
}
