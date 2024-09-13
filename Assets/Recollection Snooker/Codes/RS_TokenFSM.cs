using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dante.RecollectionSnooker
{
    #region Enums

    public enum TokenPhysicalStates
    {
        PHYSICAL, //RB: active, COLL: active
        STATIC, //RB: deactive, COLL: active
        GHOST //RB: deactive, COLL: deactive
    }

    public enum TokenStateMechanics
    {
        SET_PHYSICS,
        SET_RIGID,
        SET_GHOST
    }

    #endregion

    #region Structs

    #endregion

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MeshCollider))]
    public class RS_TokenFSM : MonoBehaviour
    {

        #region Knobs

        #endregion

        #region References

        protected Rigidbody _rigidbody;
        protected MeshCollider _meshCollider;

        #endregion

        #region Runtime Variables

        [SerializeField]
        protected TokenPhysicalStates _physicalState;

        #endregion

        #region Unity Methods

        private void Start()
        {
            InitializeTokenFSM();
        }

        #endregion

        #region Runtime Methods

        protected virtual  void InitializeTokenFSM()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _meshCollider = GetComponent<MeshCollider>();
        }

        #endregion

        #region Prepare FSM States

        protected virtual void InitializePhysicalState()
        {
            _rigidbody.isKinematic = false;
            _meshCollider.enabled = true;
            _physicalState = TokenPhysicalStates.PHYSICAL;
        }

        protected virtual void InitializeStaticState()
        {
            _rigidbody.isKinematic = true;
            _meshCollider.enabled = true;
            _physicalState = TokenPhysicalStates.STATIC;
        }

        protected virtual void InitializeGhostState()
        {
            _rigidbody.isKinematic = true;
            _meshCollider.enabled = false;
            _physicalState = TokenPhysicalStates.GHOST;
        }

        #endregion

        #region Public Methods

        public void StateMechanic(TokenStateMechanics value)
        {
            switch (value)
            {
                case TokenStateMechanics.SET_PHYSICS:
                    InitializePhysicalState();
                    break;

                case TokenStateMechanics.SET_RIGID:
                    InitializeStaticState();
                    break;
                case TokenStateMechanics.SET_GHOST:
                    InitializeGhostState();
                    break;
            }
        }

        #endregion

        #region Getters and Setters

        #endregion
    }

}
