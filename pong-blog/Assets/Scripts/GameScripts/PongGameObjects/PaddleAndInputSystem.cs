using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pong.Game.GameObjects.Commands;


namespace Pong.Game.Systems
{
    public class PaddleAndInputSystem : MonoBehaviour
    {
        [SerializeField]
        GameObject pongPaddleRight;
        PongPaddleCommandsInvoker pongPaddleRightCommandsInvoker;
        [SerializeField]
        GameObject pongPaddleLeft;
        PongPaddleCommandsInvoker pongPaddleLeftCommandsInvoker;

        [SerializeField]
        float paddleMoveSpeed = 1f;
        [SerializeField]
        float paddleBounds = 4f;
        private void Start()
        {
            pongPaddleRightCommandsInvoker = new(pongPaddleRight,paddleMoveSpeed, paddleBounds);
            pongPaddleLeftCommandsInvoker = new(pongPaddleLeft, paddleMoveSpeed, paddleBounds);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                pongPaddleRightCommandsInvoker.InvokePongPaddleMoveUp();
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                pongPaddleRightCommandsInvoker.InvokePongPaddleMoveDown();
            }

            if (Input.GetKey(KeyCode.W))
            {
                pongPaddleLeftCommandsInvoker.InvokePongPaddleMoveUp();
            }else if (Input.GetKey(KeyCode.S))
            {
                pongPaddleLeftCommandsInvoker.InvokePongPaddleMoveDown();
            }
        }
    }
}
