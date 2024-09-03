using Dante.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dante.RecollectionSnooker
{

    #region Enum
    public enum RS_GameStates
    {
        //START OF THE GAME
        DROP_CARGO,
        CANNON_BY_DROPPED_CARGO,
        //PLAYER ORDINARY TURN STATES
        TURN_FLICK_BY_PLAYER,
        CANNON_BY_NAVIGATION,
        NAVIGATING_SHIP_OF_THE_PLAYER,
        ANCHOR_SHIP_BY_PLAYER,
        CANNON_CARGO,
        LOADING_CARGO_BY_PLAYER,
        ORGANIZE_CARGO_BY_PLAYER,
        MOVE_COUNTER,
        DROP_CARGO_BY_PREVIOUS_PLAYER,
        //MONSTER ATTACK
        PREPARING_MONSTER_ATTACK,
        //PLAYER MONSTER ATTACK STATES
        TURN_DROP_DICE_BY_PLAYER,
        CANNON_DICE,
        MOVE_LIMB_BY_PLAYER,
        MOVE_BODY_BY_PLAYER,
        //META MECHANICS
        VICTORY_OF_THE_PLAYER
    }
    #endregion

    public class RS_GameReferee : GameReferee
    {

        #region Runtime Variables
        protected RS_GameStates rs_gameState;
        #endregion

        #region Unity Methods

        void Start()
        {

        }

        void Update()
        {

        }

        #endregion
    }
}
