using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Game.GameObjects
{
    public class PongPaddleGO : MonoBehaviour
    {
        public float VerticalBounds { get; set; }
        public float HorizontalBounds { get; set; }
        public float MoveSpeed { get; set; }

        private Vector2 cachedInitialPos;

        private void Start()
        {
            cachedInitialPos = transform.position;
        }


        public void MovePaddle(Vector2 dir)
        {
            transform.Translate(MoveSpeed * Time.deltaTime * dir.normalized);
            if (transform.position.y > cachedInitialPos.y + VerticalBounds)
            {
                transform.position = new Vector2(transform.position.x, cachedInitialPos.y + VerticalBounds);
                return;
            }
            else if (transform.position.y< cachedInitialPos.y - VerticalBounds)
            {
                transform.position = new Vector2(transform.position.x, cachedInitialPos.y - VerticalBounds);
                return;
            }
            else if (transform.position.x > cachedInitialPos.x + HorizontalBounds)
            {
                transform.position = new Vector2(cachedInitialPos.x + HorizontalBounds, transform.position.y);
                return;
            }
            else if (transform.position.x < cachedInitialPos.x - HorizontalBounds)
            {
                transform.position = new Vector2(cachedInitialPos.x - HorizontalBounds, transform.position.y);
                return;
            }

        }

    }

}
