using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Pong.Game.GameObjects
{
    public class PongGoalGO : MonoBehaviour
    {

        public Action OnPongBallCollision;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("PongBall"))
            {
                OnPongBallCollision?.Invoke();
            }
        }
    }

}
