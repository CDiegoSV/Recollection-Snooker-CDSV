using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Dante.Game
{
    #region Enum

    public enum GameStates
    {
        Starting_Game,
        Game,
        Pause,
        Victory,
        Defeat,
        Draw
    }
    #endregion

    public class GameReferee : MonoBehaviour
    {
        #region Runtime Variables

        protected GameStates _gameState;

        #endregion

        #region Unity Methods

        private void Start()
        {
            InitializeGameReferee();
        }

        #endregion

        #region Runtime Methods

        protected virtual void InitializeGameReferee()
        {
            _gameState = GameStates.Starting_Game;
        }

        #endregion
    }
}


