using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Pong.Game.GameObjects;
using Pong.Game.GameObjects.Commands;
using Pong.Game.Interfaces;



namespace Pong.Game.Systems
{
    public partial class PongPlayerSystem : MonoBehaviour
    {

        public string PlayerName { get { return playerName; } set { playerName = value; } }
        public Color GoalColor { get { return goalColor; } set { goalColor = value; } }

        public static int LifeLimit { get { return lifeLimit; } set { lifeLimit = value; } }
        public int CurrentLives { get { return currLives; } set { currLives = value; } }

        public PongPaddleGO Paddle { get { return pongPaddle; } }
        public PongGoalGO Goal { get { return pongGoal; } }



        [SerializeField] private PongGoalGO pongGoal;

        [SerializeField] private PongPaddleGO pongPaddle;

        [SerializeField] private Color goalColor;

        [SerializeField] private string playerName;

        [SerializeField] [TagSelector] private string pongBallTag;
        [SerializeField] [TagSelector] private string collectableTag;

        [SerializeField] private int currLives;

        private static int lifeLimit;

        


        private IPongCommand pongCommand;
        private IPongCommand<bool> pongCommandBool;
        private IPongCommand<Vector2> pongCommandVec2;
        private IPongCommand<Vector2, Vector2> pongCommandVec2Vec2;

        public static Action<PongPlayerSystem> OnGoal;
        public static Action<PongPlayerSystem> OnLifeEnd;

        private static readonly Dictionary<int, PongBallGO> cachedPongBallDictionary = new();
        private static readonly Dictionary<int, PongPaddleGO> cachedPongBallLastHitPaddle = new();
        private void OnEnable()
        {
            PongGoalGO.OnPongGoalCollisionEnter2D += OnPongHitGoal;
            PongPaddleGO.OnPongBallCollisionEnter2D += OnPongHitPaddle;
            PongBallGO.OnPongBallTriggerEnter2D += OnPongHitPowerUp;
        }
        private void OnDisable()
        {
            PongGoalGO.OnPongGoalCollisionEnter2D -= OnPongHitGoal;
            PongPaddleGO.OnPongBallCollisionEnter2D = OnPongHitPaddle;
            PongBallGO.OnPongBallTriggerEnter2D -= OnPongHitPowerUp;
        }

        private void Start()
        {
            pongPaddle.MovementBounds = pongGoal.transform.localScale.y / 2;
            //pongPaddle.MoveSpeed = MoveSpeed;
            pongPaddle.MoveSpeed = 1;
            pongGoal.Color = goalColor;
        }
 }

}
