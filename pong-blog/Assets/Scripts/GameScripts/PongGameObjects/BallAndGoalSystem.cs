using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//namespaces
using Pong.Game.GameObjects;
using Pong.Game.GameObjects.Commands;

namespace Pong.Game.Systems
{
    public class BallAndGoalSystem : MonoBehaviour
    {
        [SerializeField]
        private GameObject pongBall;
        private PongBallCommandsInvoker pongBallCommandInvoker;
        [Space]
        [SerializeField]
        private PongGoalGO LeftGoalWall;
        [SerializeField]
        private PongGoalGO RightGoalWall;

        public Action OnLeftSideGoal;
        public Action OnRightSideGoal;


        void Start()
        {
            pongBallCommandInvoker = new(pongBall);
            LeftGoalWall.OnPongBallCollision += OnLeftWallBallColision;
            RightGoalWall.OnPongBallCollision += OnRigtWallBallColision;
        }
        private void OnDisable()
        {
            LeftGoalWall.OnPongBallCollision -= OnLeftWallBallColision;
            RightGoalWall.OnPongBallCollision -= OnRigtWallBallColision;
        }


        private void OnLeftWallBallColision()
        {
            pongBallCommandInvoker.InvokePongBallLeftStartDirection();

            OnLeftSideGoal?.Invoke();
        }
        private void OnRigtWallBallColision()
        {
            pongBallCommandInvoker.InvokePongBallRightStartDirection();

            OnRightSideGoal?.Invoke();
        }
    }

}
