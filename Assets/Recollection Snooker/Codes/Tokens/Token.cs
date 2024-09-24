using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dante.RecollectionSnooker
{
    #region Enums

    #endregion

    #region Structs

    [System.Serializable]
    public struct GameplayAtrributes
    {
        public bool isAvailableForFlicking;
        public bool isOutOfTheBoard;
        public bool isBeingDragged;
    }

    #endregion

    [RequireComponent(typeof(RS_TokenFSM))]
    
    public class Token : MonoBehaviour
    {

        #region Knobs

        #endregion

        #region References

        protected RS_TokenFSM _tokenPhysicalFSM;

        #endregion

        #region Runtime Variables
        [Header("Runtime Variables")]

        [SerializeField] protected GameplayAtrributes _gameplayAtrributes;

        #endregion

        #region Runtime Variables

        #endregion

        #region Unity Methods

        private void FixedUpdate()
        {
            
        }

        #endregion

        #region Runtime Methods

        protected virtual void InitializeToken()
        {
            if (_tokenPhysicalFSM == null)
            {
                _tokenPhysicalFSM = GetComponent<RS_TokenFSM>();
            }
        }

        #endregion

        #region Public Methods

        public void StateMechanic(TokenStateMechanics value)
        {
            _tokenPhysicalFSM.StateMechanic(value);
        }

        #endregion

        #region Getters and Setters

       

        #endregion
    }
}