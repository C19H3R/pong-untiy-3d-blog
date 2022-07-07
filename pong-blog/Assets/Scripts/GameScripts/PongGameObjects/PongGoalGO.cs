using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Pong.Services;
using Pong.Services.AudioServices;

namespace Pong.Game.GameObjects
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PongGoalGO : MonoBehaviour
    {
        [TagSelector]
        [SerializeField]
        private string ballCollisionTag;

        [TagSelector]
        [SerializeField]
        private string untaggetTagged;
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        public static Action<PongGoalGO,Collision2D> OnPongGoalCollisionEnter2D;
        

        private Vector2 upperBound;
        private Vector2 lowerBound;

        public Vector2 UpperBound { get { return upperBound; } }
        public Vector2 LowerBBound { get { return lowerBound; } }

        private bool disabled;
        public bool IsGoalDisabled
        {
            get { return disabled; }
            set
            {
                disabled = value;

                Color tmpColor = spriteRenderer.color;
                if (disabled)
                {
                    tmpColor.a=0.3f;
                    gameObject.tag = untaggetTagged;
                }
                else
                {
                    tmpColor.a = 1;
                }
                spriteRenderer.color = tmpColor;
            }
        }
        public Color Color { set { spriteRenderer.color = value; } }


        private void Start()
        {
            upperBound = transform.position + transform.up*transform.localScale.y / 2;
            lowerBound = transform.position - transform.up * transform.localScale.y / 2;

        }

        private void OnCollisionEnter2D(Collision2D collision)
    {
            OnPongGoalCollisionEnter2D?.Invoke(this,collision);
        }
    }

}
