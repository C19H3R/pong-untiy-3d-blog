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

        [SerializeField]
        PongUISystem pongUISystem;


        private int leftScore;
        private int rightScore;

        private void OnEnable()
        {
            ballAndGoalSystem.OnLeftGoal += OnPongGoal;
            ballAndGoalSystem.OnLeftGoal += UpdateRightScore;

            ballAndGoalSystem.OnRightGoal += OnPongGoal;
            ballAndGoalSystem.OnRightGoal += UpdateLeftScore;

        }
        private void OnDisable()
        {
            ballAndGoalSystem.OnLeftGoal -= OnPongGoal;
            ballAndGoalSystem.OnLeftGoal -= UpdateRightScore;

            ballAndGoalSystem.OnRightGoal -= OnPongGoal;
            ballAndGoalSystem.OnRightGoal -= UpdateLeftScore;
        }

        private void OnPongGoal()
        {
            ballAndGoalSystem.ResetAndStart();
        }
        private void UpdateLeftScore()
        {
            leftScore++;
            pongUISystem.UpdateScore(leftScore, rightScore);
        }
        private void UpdateRightScore()
        {
            rightScore++;
            pongUISystem.UpdateScore(leftScore, rightScore);
        }


    }
}

