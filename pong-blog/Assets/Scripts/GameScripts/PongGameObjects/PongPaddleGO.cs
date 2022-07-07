using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Pong.Services;
using Pong.Services.AudioServices;
using Pong.Game.Interfaces;



namespace Pong.Game.GameObjects
{
    public partial class PongPaddleGO : MonoBehaviour
    {
        

        public float MovementBounds { set {
                boundPointOne = transform.position - transform.up * (value - spriteExtends.y * (1+ extraGap));
                boundPointTwo = transform.position + transform.up * (value - spriteExtends.y * (1 + extraGap));
            } }

        public float MoveSpeed { get; set; }

        public static Action<PongPaddleGO,Collision2D> OnPongBallCollisionEnter2D;

        [Header("Core Variables")]
        [Space(5)]
        [TagSelector]
        [SerializeField]
        private string collidingPongBallTag;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private Vector3 boundPointOne;
        private Vector3 boundPointTwo;
        private Vector3 spriteExtends;
        private float extraGap = 0.5f;

        private float lerpValueForMove=0.5f;

        private void Start()
        {
            spriteExtends = spriteRenderer.bounds.extents;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnPongBallCollisionEnter2D?.Invoke(this,collision);
        }


        /// <summary>
        /// moves the given paddle to eigther of the two possible directions
        /// </summary>
        /// <param name="toUp">if tru to one side other wise to the other </param>
        public void MovePaddle(bool toUp)
        {
            if (toUp)
            {
                lerpValueForMove += Time.deltaTime * MoveSpeed;
                if (lerpValueForMove > 1)
                {
                    lerpValueForMove = 1;
                }
                transform.position = Vector3.Lerp(boundPointOne, boundPointTwo, lerpValueForMove);
            }
            else
            {
                lerpValueForMove -= Time.deltaTime * MoveSpeed;
                if (lerpValueForMove < 0)
                {
                    lerpValueForMove = 0;
                }
                transform.position = Vector3.Lerp(boundPointOne, boundPointTwo, lerpValueForMove);
            }
        }


    }

}
