using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pong.Game.GameObjects;

namespace Pong.Game.Interfaces
{

    [SerializeField]
    public enum AttachableType
    {
        Paddle_UP,
        Paddle_DOWN
    }

    public interface IPongAttachable
    {
        public AttachableType AttachableType { get; }
        public void Shoot();
        public void AttachToTransform(Transform parent);
        public void SelfDestruct();
    }

    public abstract class PongAttachableBase : MonoBehaviour , IPongAttachable
    {
        [SerializeField]
        public AttachableType attachableType;
        public AttachableType AttachableType { get { return attachableType; } }

        public abstract void Shoot();
 
        public virtual void AttachToTransform(Transform parent)
        {
            transform.SetParent(parent);
            transform.localPosition = Vector2.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
        public virtual void SetPosition(Vector2 position)
        {
            transform.localPosition = position;
        }
        public virtual void SelfDestruct()
        {
            Destroy(this);
        }

    }
}