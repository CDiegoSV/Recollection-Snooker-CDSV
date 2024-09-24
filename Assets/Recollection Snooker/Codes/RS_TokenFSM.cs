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

    [System.Serializable]
    public struct MaterialAssets
    {
        public Material physicalMaterial, ghostMaterial;
    }

    #endregion

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MeshCollider))]
    [RequireComponent(typeof(MeshRenderer))]
    public class RS_TokenFSM : MonoBehaviour
    {

        #region Knobs

        #endregion

        #region References
        [Header("References")]


        [SerializeField, HideInInspector] protected Rigidbody _rigidbody;
        [SerializeField, HideInInspector] protected MeshCollider _meshCollider;
        [SerializeField, HideInInspector] protected MeshRenderer _meshRenderer;

        #endregion

        #region Assets
        [Header("Asset References")]

        public MaterialAssets materialAssets;

        #endregion

        #region Runtime Variables
        [Header("Runtime Variables")]
        [SerializeField] protected TokenPhysicalStates _physicalState;
        [SerializeField] protected bool _isStill;

        #endregion

        #region Unity Methods

        private void Start()
        {
            InitializeTokenFSM();
        }

        private void FixedUpdate()
        {
            if (_physicalState == TokenPhysicalStates.PHYSICAL)
            {
                _isStill = _rigidbody.velocity.magnitude < 0.1f && _rigidbody.angularVelocity.magnitude < 0.1f;
            }
            else
            {
                _isStill= false;
            }
        }

        #endregion

        #region Runtime Methods

        protected virtual  void InitializeTokenFSM()
        {
            if (_rigidbody == null)
            {
                Debug.LogWarning(gameObject.name + "_rigidbody component reference not assigned by editor.");
                _rigidbody = GetComponent<Rigidbody>();
            }
            if (_meshCollider == null)
            {
                Debug.LogWarning(gameObject.name + "_meshCollider component reference not assigned by editor.");
                _meshCollider = GetComponent<MeshCollider>();
            }
            if(_meshRenderer == null)
            {
                Debug.LogWarning(gameObject.name + "_meshRenderer component reference not assigned by editor.");
                _meshRenderer = GetComponent<MeshRenderer>();
            }
        }

        #endregion

        #region Prepare FSM States

        protected virtual void InitializePhysicalState()
        {
            _rigidbody.isKinematic = false;
            _meshCollider.enabled = true;
            _physicalState = TokenPhysicalStates.PHYSICAL;
            _meshRenderer.material = materialAssets.physicalMaterial;
        }

        protected virtual void InitializeStaticState()
        {
            _rigidbody.isKinematic = true;
            _meshCollider.enabled = true;
            _physicalState = TokenPhysicalStates.STATIC;
            _meshRenderer.material = materialAssets.physicalMaterial;
        }

        protected virtual void InitializeGhostState()
        {
            _rigidbody.isKinematic = true;
            _meshCollider.enabled = false;
            _physicalState = TokenPhysicalStates.GHOST;
            _meshRenderer.material = materialAssets.ghostMaterial;
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

        public TokenPhysicalStates GetPhysicalState
        {
            get { return _physicalState; }
        }

        #endregion
    }

}
