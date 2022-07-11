using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Pong.Game.GameObjects;
using Pong.Game.GameObjects.Commands;
using Pong.Game.Interfaces;
using Pong.Utilities;


namespace Pong.Game.Systems
{
    public partial class PongPlayerSystem
    {
        private void OnPongHitPaddle(PongPaddleGO pongPaddleGO, Collision2D collision)
        {
            if (pongPaddleGO == pongPaddle)
            {
                GameObject colliderGameObj = collision.gameObject;
                if (colliderGameObj.CompareTag(PongTagUtility.PongBall))
                {
                    PongBallGO pongBall = GetPongBallGO(colliderGameObj);

                    SetPongLastHitPaddle(pongBall, pongPaddle);

                    pongCommandVec2 = new PongBallRandomReflectionCommand(pongBall);
                    pongCommandVec2.Invoke(-collision.contacts[0].normal);

                    pongCommand = new PongBallAccelerate(pongBall);
                    pongCommand.Invoke();
                }
            }
        }
    }
}
