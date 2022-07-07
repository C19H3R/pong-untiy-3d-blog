using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Pong.Game.GameObjects;
using Pong.Game.GameObjects.Commands;
using Pong.Game.Interfaces;



namespace Pong.Game.Systems
{
    public partial class PongPlayerSystem
    {
        private static PongBallGO GetPongBallGO(GameObject gameObject)
        {
            int instancID = gameObject.GetInstanceID();
            if (cachedPongBallDictionary.ContainsKey(instancID))
            {
                return cachedPongBallDictionary[instancID];
            }
            else
            {
                PongBallGO pongBall = gameObject.GetComponent<PongBallGO>();
                if (pongBall)
                {
                    cachedPongBallDictionary[instancID] = pongBall;
                    return pongBall;
                }
                else
                {
                    throw new System.Exception("tag and component mismatch : PongBallGO");
                }
            }
        }

        private static PongPaddleGO GetPongLastHitPaddle(PongBallGO ball)
        {
            int instanceID = ball.GetInstanceID();
            if (cachedPongBallLastHitPaddle.ContainsKey(instanceID))
            {
                return cachedPongBallLastHitPaddle[instanceID];
            }
            else
            {
                return null;
            }
        }

        private static void SetPongLastHitPaddle(PongBallGO ball,PongPaddleGO paddle)
        {
            int instanceID = ball.GetInstanceID();
            cachedPongBallLastHitPaddle[instanceID] = paddle;
        }
    }

}
