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
        private void ReduceLife(PongGoalGO pongGoalGO)
        {
            currLives--;

            if (currLives > 0)
            {
                OnGoal?.Invoke(this);
            }
            else
            {
                currLives = 0;
                if (!pongGoalGO.IsGoalDisabled)
                {
                    pongGoalGO.IsGoalDisabled = true;
                    OnLifeEnd?.Invoke(this);
                }
            }
        }

        private void OnPongHitGoal(PongGoalGO pongGoalGo, Collision2D collision)
        {
            if (pongGoalGo == pongGoal)
            {
                GameObject colliderGameObj = collision.gameObject;
                if (colliderGameObj.CompareTag(PongTagUtility.PongBall))
                {
                    if (!pongGoal.IsGoalDisabled)
                    {
                        PongBallGO pongBall = GetPongBallGO(colliderGameObj);

                        pongCommand = new PongBallResetCommand(pongBall);
                        pongCommandVec2Vec2 = new PongBallSetStartDirectionBasedOnGoalCommand(pongBall);

                        pongCommand.Invoke();
                        pongCommandVec2Vec2.Invoke(pongGoal.UpperBound, pongGoal.LowerBBound);
                    }

                    ReduceLife(pongGoal);
                }
            }
        }
    }

}
