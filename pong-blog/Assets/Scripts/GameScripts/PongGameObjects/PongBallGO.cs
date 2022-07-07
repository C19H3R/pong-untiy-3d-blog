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
        
        [SerializeField]
        [TagSelector]
        string TagCommonGO;
        [SerializeField]
        [TagSelector]
        string TagGoalGO;
        [SerializeField]
        [TagSelector]
        string TagPaddleGO;

        public static Action<PongBallGO, Collider2D> OnPongBallTriggerEnter2D;
        public static Action<PongBallGO, Collision2D> OnPongBallCollisionEnter2D;


        private float currentSpeed;
        private Vector2 cachedStartPosition;

        public Vector2 BallStartPosition { get { return cachedStartPosition; } }

        private Vector2 startDirection=Vector2.right+Vector2.up;
        public Vector2 StartDirection { set { startDirection = value.normalized; } }


        PongAudioPlayerService audioPlayer;

        private void Start()
        {
            audioPlayer = PongServiceLocator.AudioPlayerService;

            cachedStartPosition = transform.position;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject collidingGO = collision.gameObject;

            if (collidingGO.CompareTag(TagCommonGO))
            {
                audioPlayer.PlaySFX(AudioClipSFX_key.SFX_02_BallHitWall);

                ReflectOnNormal(collision.contacts[0].normal);
            }
            else if(collidingGO.CompareTag(TagPaddleGO))
            {
                audioPlayer.PlaySFX(AudioClipSFX_key.SFX_01_BallHitPaddle);

            }
            else if (collidingGO.CompareTag(TagGoalGO))
            {
                audioPlayer.PlaySFX(AudioClipSFX_key.SFX_03_BallHitGoal);
            }

            OnPongBallCollisionEnter2D?.Invoke(this, collision);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnPongBallTriggerEnter2D?.Invoke(this,collision);
        }

        private void UpdateVelocity()
        {
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * currentSpeed;
            Debug.Log(rigidbody2D.velocity.magnitude);
        }

        /// <summary>
        /// to acceletate the speed of the pong ball
        /// </summary>
        public void Accelerate()
        {
            currentSpeed += buildUpRate;
            UpdateVelocity();
        }

        /// <summary>
        /// To Reset Pong Position
        /// </summary>
        [ContextMenu("Reset Pong Ball")]
        public void ResetPosition()
        {
            rigidbody2D.velocity = Vector2.zero;
            transform.position = cachedStartPosition;
        }

        /// <summary>
        /// To start a movement of ball
        /// </summary>
        [ContextMenu("start pong")]
        public void StartMovement()
        {
            ResetPosition();

            currentSpeed = startSpeed;

            rigidbody2D.velocity = startDirection.normalized * currentSpeed;

            UpdateVelocity();
        }

        /// <summary>
        /// Flips motion randomly on invoking on reflecting a normal
        /// </summary>
        public void RandomReflection(Vector2 normal)
        {
            Vector2 finalDirection,currDirection = rigidbody2D.velocity.normalized;
            float currentMagnitude =rigidbody2D.velocity.magnitude;

            Vector2 reflectedDirection = normal + currDirection;

            Vector2 vectorOne = normal.normalized;
            Vector2 vectorTwo = (reflectedDirection - Vector2.Dot(reflectedDirection, normal) * normal.normalized).normalized;

            finalDirection = UnityEngine.Random.value * vectorTwo + UnityEngine.Random.value * vectorOne;
            finalDirection = finalDirection.normalized;
            rigidbody2D.velocity = finalDirection.normalized*currentMagnitude;

            UpdateVelocity();
        }

        /// <summary>
        /// Flips motion perfectly based on a given normal direction
        /// </summary>
        /// <param name="normal">normal vector </param>
        public void ReflectOnNormal(Vector2 normal)
        {
            rigidbody2D.velocity = Vector2.Reflect(rigidbody2D.velocity, normal);
            UpdateVelocity();
        }
        /// <summary>
        /// Reflects the motion of ball in a given direction
        /// </summary>
        /// <param name="dir"></param>
        public void ReflectInDirection(Vector2 dir)
        {
            rigidbody2D.velocity = rigidbody2D.velocity.magnitude*dir.normalized;

            UpdateVelocity();
        }

    }
}


