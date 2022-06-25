using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//namespaces
using Pong.Game.Interfaces;

namespace Pong.Game.GameObjects.Commands
{
    public class PongBallCommandsInvoker
    {

        private readonly IPongCommand pongBallResetCommand;
        private readonly IPongCommand pongBallStartMovementCommand;
        private readonly IPongCommand pongBallLeftStartDirectionCommand;
        private readonly IPongCommand pongBallRightStartDirectionCommand;


        public PongBallCommandsInvoker(PongBallGO pongBallGO)
        {
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


