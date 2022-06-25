using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


using Pong.Services;
using Pong.Services.AudioServices;

namespace Pong.Game.GameObjects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PongBallGO : MonoBehaviour
    {
        [SerializeField]
        new Rigidbody2D rigidbody2D;
        [SerializeField]
        float startSpeed = 1f;
        [Range(0f, 0.5f)]
        [SerializeField]
        [Tooltip("this value adds up every pad collision")]
        float buildUpRate=1f;

        public Action<Collision2D> OnPongBallCollisionEnter2D;

        private bool  toLeft = false;
        private Vector2 currentMovementDir = Vector2.zero;
        private float currentSpeed;

        PongAudioPlayerService audioPlayer;

        private void Start()
        {
            audioPlayer = PongServiceLocator.AudioPlayerService;
        }



        public void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject collidingGO = collision.gameObject;
            if (collidingGO.CompareTag("PongPaddle"))
            {
                FlipMovementHorizontally();
            }
            else
            {
                FlipMovementBasedOnContactNormal(collision.contacts[0].normal);
            }



            if (collidingGO.CompareTag("PongPaddle"))
            {
                Accelerate();

                audioPlayer.PlaySFX(AudioClipSFX_key.SFX_01_BallHitPaddle);
            }
            else if (collidingGO.CompareTag("PongGoal"))
            {
                audioPlayer.PlaySFX(AudioClipSFX_key.SFX_03_BallHitGoal);
            }
            else
            {
                audioPlayer.PlaySFX(AudioClipSFX_key.SFX_02_BallHitWall);
            }
            UpdateVelocity();

            OnPongBallCollisionEnter2D?.Invoke(collision);
        }

        

        private void FlipMovementVertically()
        {
            currentMovementDir.y = -currentMovementDir.y;
        }
        private void FlipMovementHorizontally()
        {
            currentMovementDir.x = -currentMovementDir.x;
        }

        private void FlipMovementBasedOnContactNormal(Vector2 normal)
        {
           currentMovementDir =  Vector2.Reflect(currentMovementDir, normal);
        }

        private void UpdateVelocity()
        {
           rigidbody2D.velocity = currentMovementDir.normalized * currentSpeed;
        }
        /// <summary>
        /// to acceletate the speed of the pong ball
        /// </summary>
        private void Accelerate()
        {
            currentSpeed += buildUpRate;
        }

        /// <summary>
        /// To Reset Pong Position
        /// </summary>
        [ContextMenu("Reset Pong Ball")]
        public void ResetPosition()
        {
            rigidbody2D.velocity = Vector2.zero;
            transform.position = Vector3.zero;
            currentMovementDir = Vector2.zero;
        }

        /// <summary>
        /// To start a movement of ball
        /// </summary>
        /// <param name="toLeft">bool if to left or right</param>
        [ContextMenu("Start Random Movement")]
        public void StartRandomMovement()
        {
            ResetPosition();

            currentMovementDir = UnityEngine.Random.onUnitSphere.normalized;
            currentMovementDir.Normalize();

            currentSpeed = startSpeed;

            if(toLeft)
            currentMovementDir.x = 1;
            else
            currentMovementDir.x = -1;

            UpdateVelocity();
        }
        /// <summary>
        /// To switch left and right direction based on Bool
        /// </summary>
        public void TogglePongStartDirection(bool isToLeft)
        {
            toLeft = isToLeft;
        }

    }
}


