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

        protected GameStates gameState;

        #endregion

        #region Unity Methods

        #endregion
    }
}


