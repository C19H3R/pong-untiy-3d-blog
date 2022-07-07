using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespaces
using Pong.Game.Interfaces;

namespace Pong.Game.GameObjects.Commands
{

    public class PaddleMoveUpCommand : IPongCommand
    {
        PongPaddleGO pongPaddle;

        public PaddleMoveUpCommand(PongPaddleGO pongPaddleGO)
        {
            pongPaddle = pongPaddleGO;
        }
        ~PaddleMoveUpCommand()
        {

        }
        public void Invoke()
        {
            pongPaddle.MovePaddle(true);
        }
    }

    public class PaddleMoveDownCommand : IPongCommand
    {
        PongPaddleGO pongPaddle;

        public PaddleMoveDownCommand(PongPaddleGO pongPaddleGO)
        {
            pongPaddle = pongPaddleGO;
        }
        public PaddleMoveDownCommand()
        {

        }
        public void Invoke()
        {
            pongPaddle.MovePaddle(false);
        }
    }

    public class PaddleAttachAttachmentCommand : IPongCommand<PongAttachableBase>
    {
        readonly PongPaddleGO paddle;

        public PaddleAttachAttachmentCommand(PongPaddleGO pongPaddleGO)
        {
            paddle = pongPaddleGO;
        }

        public void Invoke(PongAttachableBase attachableBase)
        {
            paddle.AttachAttachment(attachableBase);
        }
    }

    public class PaddleAttachmentShootCommand : IPongCommand<AttachableType>
    {
        readonly PongPaddleGO paddle;

        public PaddleAttachmentShootCommand(PongPaddleGO pongPaddleGO)
        {
            paddle = pongPaddleGO;
        }
        public void Invoke(AttachableType type)
        {
            paddle.ShootFromAttachment(type);
        }
    }

    public class PaddleDetachAttachment : IPongCommand<AttachableType>
    {
        readonly PongPaddleGO paddle;

        public PaddleDetachAttachment(PongPaddleGO pongPaddleGO)
        {
            paddle = pongPaddleGO;
        }
        public void Invoke(AttachableType type)
        {
            paddle.DetachAttachment(type);
        }
    }

}





