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

                Accelerate();

                audioPlayer.PlaySFX(AudioClipSFX_key.SFX_01_BallHitPaddle);
            }
            else 
            {
                FlipMovementBasedOnContactNormal(collision.contacts[0].normal);

                if (collidingGO.CompareTag("PongGoal"))
                {
                    audioPlayer.PlaySFX(AudioClipSFX_key.SFX_03_BallHitGoal);
                }
                else
                {
                    audioPlayer.PlaySFX(AudioClipSFX_key.SFX_02_BallHitWall);
                }
            } 

            UpdateVelocity();

            OnPongBallCollisionEnter2D?.Invoke(collision);
        }

        

        private void FlipMovementVertically()
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -rigidbody2D.velocity.y);
        }
        private void FlipMovementHorizontally()
        {
            rigidbody2D.velocity = new Vector2(-rigidbody2D.velocity.x, rigidbody2D.velocity.y);
        }

        private void FlipMovementBasedOnContactNormal(Vector2 normal)
        {
            rigidbody2D.velocity = Vector2.Reflect(rigidbody2D.velocity, normal);
        }

        private void UpdateVelocity()
        {
           rigidbody2D.velocity = rigidbody2D.velocity.normalized * currentSpeed;
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
        }

        /// <summary>
        /// To start a movement of ball
        /// </summary>
        /// <param name="toLeft">bool if to left or right</param>
        [ContextMenu("Start Random Movement")]
        public void StartRandomMovement()
        {
            ResetPosition();

            currentSpeed = startSpeed;

            rigidbody2D.velocity = UnityEngine.Random.onUnitSphere.normalized;
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * currentSpeed;


            if (toLeft)
            {
                rigidbody2D.velocity = rigidbody2D.velocity.x < 0 ? rigidbody2D.velocity:Vector2.Reflect(rigidbody2D.velocity,Vector2.up);
            }
            else
            {
                rigidbody2D.velocity = rigidbody2D.velocity.x > 0 ? rigidbody2D.velocity : Vector2.Reflect(rigidbody2D.velocity, Vector2.up);
            }

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


