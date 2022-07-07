using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pong.Game.GameObjects;

using Pong.Game.Systems;

namespace Pong.Game.Interfaces
{

    public interface IPongCollectable 
    {
        public void Collect(PongPlayerSystem pongPlayerSystem);
    }
}
