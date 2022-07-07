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
        private void OnPongHitPowerUp(PongBallGO pongBallGO, Collider2D collision)
        {
            PongPaddleGO lastHitPaddle = GetPongLastHitPaddle(pongBallGO);
            if (lastHitPaddle!=null && pongPaddle==lastHitPaddle)
            {
                if (collision.gameObject.CompareTag(collectableTag))
                {
                    IPongCollectable collectable = collision.gameObject.GetComponent<IPongCollectable>();

                    if (collectable!=null)
                    {
                        collectable.Collect(this);
                    }
                }
            }
        }
    }
}
