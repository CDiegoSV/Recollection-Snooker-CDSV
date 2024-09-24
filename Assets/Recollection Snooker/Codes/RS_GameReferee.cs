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

    public enum PlayerIndex 
    { 
        ONE,
        TWO,
        THREE,
        FOUR 
    }

    #endregion

    public class RS_GameReferee : GameReferee
    {

        #region References

        [Header("References")]
        [SerializeField, HideInInspector]
        public Cargo[] allCargo;

        #endregion

        #region Runtime Variables
        protected new RS_GameStates _gameState;
        protected PlayerIndex _playerIndex;
        #endregion

        #region Unity Methods

        void Start()
        {
            InitializeGameReferee();
        }

        #endregion

        #region RuntimeMethods

        protected override void InitializeGameReferee()
        {
            _gameState = RS_GameStates.DROP_CARGO;
            InitializeDropCargoState();
        }

        #endregion

        #region FiniteStateMachine

        #region DropCargo

        protected void InitializeDropCargoState()
        {

            foreach (Cargo cargo in allCargo)
            {
                cargo.StateMechanic(TokenStateMechanics.SET_GHOST);
            }
        }

        protected void ManageDropCargoState()
        {

        }

        protected void ExitDropCargoState()
        {

        }

        #endregion DropCargo

        #region CannonByDroppedCargo

        #endregion CannonByDroppedCargo

        #endregion
    }
}
