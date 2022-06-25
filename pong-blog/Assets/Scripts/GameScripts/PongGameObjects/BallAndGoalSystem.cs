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
        private PongBallGO pongBallGO;
        private PongBallCommandsInvoker pongBallCommandInvoker;
        [Space]
        [SerializeField]
        private PongGoalGO LeftGoalWall;
        [SerializeField]
        private PongGoalGO RightGoalWall;

        public Action OnLeftGoal;
        public Action OnRightGoal;

        private void Awake()
        {
            pongBallCommandInvoker = new(pongBallGO);
        }
        private void OnEnable()
        {
            pongBallGO.OnPongBallCollisionEnter2D += OnBallCollisionEnter2D;
        }
        private void OnDisable()
        {
            pongBallGO.OnPongBallCollisionEnter2D -= OnBallCollisionEnter2D;
        }

        private void OnBallCollisionEnter2D(Collision2D collision)
        {
            if (GameObject.ReferenceEquals(collision.gameObject, LeftGoalWall.gameObject))
            {
                pongBallCommandInvoker.InvokePongBallRightStartDirection();
                OnLeftGoal?.Invoke();
            }
            else if (GameObject.ReferenceEquals(collision.gameObject, RightGoalWall.gameObject))
            {
                pongBallCommandInvoker.InvokePongBallLeftStartDirection();
                OnRightGoal?.Invoke();
            }
        }

        public void ResetAndStart()
        {
            pongBallCommandInvoker.InvokePongStartMovement();
        }

        public void Reset()
        {
            pongBallCommandInvoker.InvokePongBallReset();
        }

    }

}
