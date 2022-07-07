using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pong.Game.Interfaces;
using Pong.Game.Systems;

public class NewBehaviourScript : MonoBehaviour,IPongCollectable
{

    public void Collect(PongPlayerSystem pongPlayerSystem)
    {
        Debug.Log(pongPlayerSystem.PlayerName);
        Destroy(gameObject);
    }


}
