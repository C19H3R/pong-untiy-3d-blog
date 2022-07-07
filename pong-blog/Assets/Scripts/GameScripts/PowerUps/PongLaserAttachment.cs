using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pong.Game.Interfaces;

namespace Pong.Game.attachments
{
    public class PongLaserAttachment : PongAttachableBase
    {
        [SerializeField]
        GameObject lazer;
        public override void Shoot()
        {
            lazer.SetActive(true);
        }
    }
}
