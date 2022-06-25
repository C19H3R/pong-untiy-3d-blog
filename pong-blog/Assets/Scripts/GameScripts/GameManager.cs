using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespaces
using Pong.Game.GameObjects;
using Pong.Game.GameObjects.Commands;
using Pong.Game.Systems;

namespace Pong.Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        BallAndGoalSystem ballAndGoalSystem;

        private void Start()
        {
            
        }
    }
}

