using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespaces
using Pong.Game.Interfaces;

namespace Pong.Game.GameObjects.Commands
{
    public class PongBallCommandsInvoker
    {

        private IPongCommand pongBallResetCommand;
        private IPongCommand pongBallStartMovementCommand;
        private IPongCommand pongBallLeftStartDirectionCommand;
        private IPongCommand pongBallRightStartDirectionCommand;


        public PongBallCommandsInvoker(GameObject pongBall)
        {
            PongBallGO pongBallGO;


            //Check For PongBallGoComponent 

            if (pongBall.GetComponent<PongBallGO>())
            {
                pongBallGO = pongBall.GetComponent<PongBallGO>();
            }
            else
            {
                throw new System.Exception("PongBallGO Component not found in Game Object");
            }

            pongBallResetCommand = new PongBallResetCommand(pongBallGO);
            pongBallStartMovementCommand = new PongBallStartMovementCommand(pongBallGO);
            pongBallLeftStartDirectionCommand = new PongBallLeftStartDirectionCommand(pongBallGO);
            pongBallRightStartDirectionCommand = new PongBallRightStartDirectionCommand(pongBallGO);
        }
        ~PongBallCommandsInvoker()
        {

        }

        public void InvokePongBallReset()
        {
            pongBallResetCommand.Invoke();
        }
        public void InvokePongStartMovement()
        {
            pongBallStartMovementCommand.Invoke();
        }
        public void InvokePongBallLeftStartDirection()
        {
            pongBallLeftStartDirectionCommand.Invoke();
        }
        public void InvokePongBallRightStartDirection()
        {
            pongBallRightStartDirectionCommand.Invoke();
        }

    }

    public class PongBallResetCommand : IPongCommand
    {
        readonly PongBallGO pongBall;

        public PongBallResetCommand(PongBallGO pongBall)
        {
            this.pongBall = pongBall;
        }
        ~PongBallResetCommand()
        {

        }

        public void Invoke()
        {
            pongBall.ResetPosition();
        }
    }

    public class PongBallStartMovementCommand : IPongCommand
    {
        readonly PongBallGO pongBall;

        public PongBallStartMovementCommand(PongBallGO pongBall)
        {
            this.pongBall = pongBall;
        }
        ~PongBallStartMovementCommand()
        {

        }

        public void Invoke()
        {
            pongBall.StartRandomMovement();
        }
    }

    public class PongBallLeftStartDirectionCommand : IPongCommand
    {
        readonly PongBallGO pongBall;

        public PongBallLeftStartDirectionCommand(PongBallGO pongBall)
        {
            this.pongBall = pongBall;
        }
        ~PongBallLeftStartDirectionCommand()
        {

        }

        public void Invoke()
        {
            pongBall.TogglePongStartDirection(true);
        }
    }
    public class PongBallRightStartDirectionCommand : IPongCommand
    {
        readonly PongBallGO pongBall;

        public PongBallRightStartDirectionCommand(PongBallGO pongBall)
        {
            this.pongBall = pongBall;
        }
        ~PongBallRightStartDirectionCommand()
        {

        }

        public void Invoke()
        {
            pongBall.TogglePongStartDirection(false);
        }
    }

}


