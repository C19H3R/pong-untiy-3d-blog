using Pong.Game.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Pong.Game.Interfaces;
using Pong.Game.GameObjects.Commands;

public class PowerUpCollectable : MonoBehaviour,IPongCollectable
{
    [SerializeField]
    PongAttachableBase attachable;

    IPongCommand<PongAttachableBase> attachCommand;



    public void Collect(PongPlayerSystem pongPlayerSystem)
    {
        attachCommand = new PaddleAttachAttachmentCommand(pongPlayerSystem.Paddle);

        attachCommand.Invoke(attachable);

        Destroy(gameObject);
    }
}
