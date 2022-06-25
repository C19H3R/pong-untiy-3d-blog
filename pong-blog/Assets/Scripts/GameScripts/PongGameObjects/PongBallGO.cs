using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pong.Services;
using Pong.Services.AudioServices;

namespace Pong.Game.GameObjects
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PongBallGO : MonoBehaviour
    {
        [SerializeField]
        Rigidbody2D rigidbody2D;
        [SerializeField]
        float startSpeed = 1f;
        [Range(0f, 0.5f)]
        [SerializeField]
        [Tooltip("this value adds up every pad collision")]
        float buildUpRate=1f;


        private bool  toLeft = false;
        private Vector2 currentMovementDir = Vector2.zero;
        private float horizontalSpeed;


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
                //flip horizontally on collision with a paddle
                FlipMovementHorizontally();
                //accelerate on collision with paddle
                Accelerate();
            }
            else
            {
                FlipMovementBasedOnContactNormal(collision.contacts[0].normal);
            }

            if (collidingGO.CompareTag("PongPaddle"))
            {
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
            rigidbody2D.velocity = currentMovementDir.normalized*startSpeed;
        }
        /// <summary>
        /// to acceletate the speed of the pong ball
        /// </summary>
        private void Accelerate()
        {
            rigidbody2D.velocity += rigidbody2D.velocity.normalized*buildUpRate;
        }

        /// <summary>
        /// To Reset Pong Position
        /// </summary>
        [ContextMenu("Reset Pong Ball")]
        public void ResetPosition()
        {
            horizontalSpeed = 0;
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

            currentMovementDir = Random.onUnitSphere.normalized;
            currentMovementDir.Normalize();

            horizontalSpeed = startSpeed;

            if(toLeft)
            currentMovementDir.x = 1;
            else
            {
                currentMovementDir.x = -1;
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


