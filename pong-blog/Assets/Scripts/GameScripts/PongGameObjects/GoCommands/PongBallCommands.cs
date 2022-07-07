using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//namespaces
using Pong.Game.Interfaces;
using Random = UnityEngine.Random;

namespace Pong.Game.GameObjects.Commands
{

    public class PongBallAccelerate: IPongCommand
    {
        readonly PongBallGO pongBall;
        public PongBallAccelerate(PongBallGO pongBall)
        {
            this.pongBall = pongBall;
        }
        ~PongBallAccelerate()
        {

        }

        public void Invoke()
        {
            pongBall.Accelerate();
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
            pongBall.StartMovement();
        }
    }
    public class PongBallSetStartDirectionCommand : IPongCommand<Vector2>
    {
        readonly PongBallGO pongBall;

        public PongBallSetStartDirectionCommand(PongBallGO pongBall)
        {
            this.pongBall = pongBall;
        }
        ~PongBallSetStartDirectionCommand()
        {

        }

        public void Invoke(Vector2 dir)
        {
            pongBall.StartDirection = dir;
        }
    }
    public class PongBallSetRandomStartDirectionCommand : IPongCommand
    {
        readonly PongBallGO pongBall;

        public PongBallSetRandomStartDirectionCommand(PongBallGO pongBall)
        {
            this.pongBall = pongBall;
        }
        ~PongBallSetRandomStartDirectionCommand()
        {

        }

        public void Invoke()
        {
            pongBall.StartDirection = UnityEngine.Random.insideUnitCircle.normalized;
        }
    }
    public class PongBallSetStartDirectionBasedOnGoalCommand : IPongCommand<Vector2,Vector2>
    {
        readonly PongBallGO pongBall;

        public PongBallSetStartDirectionBasedOnGoalCommand(PongBallGO pongBall)
        {
            this.pongBall = pongBall;
        }
        ~PongBallSetStartDirectionBasedOnGoalCommand()
        {

        }
        public void Invoke(Vector2 vectorOne, Vector2 vectorTwo)
        {
            pongBall.StartDirection = Random.value*vectorOne.normalized + Random.value * vectorTwo.normalized;
        }
    }
    public class PongBallRandomReflectionCommand : IPongCommand<Vector2>
    {
        readonly PongBallGO pongBall;

        public PongBallRandomReflectionCommand(PongBallGO pongBall)
        {
            this.pongBall = pongBall;
        }
        ~PongBallRandomReflectionCommand()
        {

        }
        public void Invoke(Vector2 normal)
        {
            pongBall.RandomReflection(normal);
        }
    }
    public class PongBallReflectionCommand : IPongCommand<Vector2>
    {
        readonly PongBallGO pongBall;

        public PongBallReflectionCommand(PongBallGO pongBall)
        {
            this.pongBall = pongBall;
        }
        ~PongBallReflectionCommand()
        {

        }
        public void Invoke(Vector2 normal)
        {
            pongBall.ReflectOnNormal(normal);
        }
    }
    public class PongBallReflectInDirectionCommand : IPongCommand<Vector2>
    {
        readonly PongBallGO pongBall;

        public PongBallReflectInDirectionCommand(PongBallGO pongBall)
        {
            this.pongBall = pongBall;
        }
        ~PongBallReflectInDirectionCommand()
        {

        }
        public void Invoke(Vector2 normal)
        {
            pongBall.ReflectInDirection(normal);
        }
    }
}


