using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Pong.Services;
using Pong.Services.AudioServices;
using Pong.Game.Interfaces;



namespace Pong.Game.GameObjects
{
    public partial class PongPaddleGO
    {
        private readonly Dictionary<AttachableType, IPongAttachable> attachmentDict = new();

        [Serializable]
        private struct InternalAttachmenTransformContainer
        {
            public AttachableType Type;
            public Transform Transform;
        }
        [Header("Attachment Variables")]
        [Space(5)]
        [SerializeField]
        private List<InternalAttachmenTransformContainer> attachmentTransformContainer;

        public void AttachAttachment(PongAttachableBase attachableBase)
        {

            IPongAttachable attachable = Instantiate(attachableBase);

            DetachAttachment(attachable.AttachableType);

            attachmentDict[attachable.AttachableType] = attachable;



            Transform attachTransform = attachmentTransformContainer.Find((container) => container.Type == attachable.AttachableType).Transform;

            if (!attachTransform)
            {
                throw new System.Exception("attachment Transform container not setup");
            }

            attachable.AttachToTransform(attachTransform);
        }

        public void ShootFromAttachment(AttachableType type)
        {
            if (attachmentDict.ContainsKey(type) && attachmentDict[type] != null)
            {
                attachmentDict[type].Shoot();
            }
        }

        public void DetachAttachment(AttachableType type)
        {
            if (attachmentDict.ContainsKey(type) && attachmentDict[type] != null)
            {
                attachmentDict[type].SelfDestruct();
                attachmentDict[type] = null;
            }
        }
    }

}
