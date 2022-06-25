using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespaces
using Pong.Game.Interfaces;

namespace Pong.Game.GameObjects.Commands
{
    public class PongPaddleCommandsInvoker
    {

        private readonly IPongCommand pongPaddleMoveUpCommand;
        private readonly IPongCommand pongPaddleMoveDownCommand;


        public PongPaddleCommandsInvoker(GameObject pongPaddle)
        {
            PongPaddleGO pongPaddleGO;

            if (pongPaddle.GetComponent<PongPaddleGO>())
            {
                pongPaddleGO = pongPaddle.GetComponent<PongPaddleGO>();
            }
            else
            {
                throw new System.Exception("PongPaddleGO not found");
            }

            pongPaddleMoveUpCommand = new PongMoveUpCommand(pongPaddleGO);
            pongPaddleMoveDownCommand = new PongMoveDownCommand(pongPaddleGO);
        }

        public PongPaddleCommandsInvoker(GameObject pongPaddle,float paddleSpeed,float verticalBounds)
        {
            PongPaddleGO pongPaddleGO;

            if (pongPaddle.GetComponent<PongPaddleGO>())
            {
                pongPaddleGO = pongPaddle.GetComponent<PongPaddleGO>();
            }
            else
            {
                throw new System.Exception("PongPaddleGO not found");
            }

            pongPaddleMoveUpCommand = new PongMoveUpCommand(pongPaddleGO);
            pongPaddleMoveDownCommand = new PongMoveDownCommand(pongPaddleGO);

            pongPaddleGO.MoveSpeed = paddleSpeed;
            pongPaddleGO.VerticalBounds = verticalBounds;
        }

        ~PongPaddleCommandsInvoker()
        {

        }

        public void InvokePongPaddleMoveUp()
        {
            pongPaddleMoveUpCommand.Invoke();
        }
        public void InvokePongPaddleMoveDown()
        {
            pongPaddleMoveDownCommand.Invoke();
        }

    }

    public class PongMoveUpCommand : IPongCommand
    {
        readonly PongPaddleGO pongPaddle;

        public PongMoveUpCommand(PongPaddleGO pongPaddle)
        {
            this.pongPaddle = pongPaddle;
        }
        ~PongMoveUpCommand()
        {

        }

        public void Invoke()
        {
                pongPaddle.MovePaddle(Vector2.up);
        }
    }

    public class PongMoveDownCommand : IPongCommand
    {
        readonly PongPaddleGO pongPaddle;

        public PongMoveDownCommand(PongPaddleGO pongPaddle)
        {
            this.pongPaddle = pongPaddle;
        }

        ~PongMoveDownCommand()
        {

        }

        public void Invoke()
        {
            pongPaddle.MovePaddle(Vector2.down);
        }
    }

}


