using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dante.RecollectionSnooker
{
    #region Enums
    public enum CargoTypes
    {
        SCREW_PART, 
        SUPPLIES,
        MEDICINE,
        FUEL,
        CREW_MEMBER,
        NONE
    }
    #endregion

    #region Structs

    #endregion

    public class Cargo : Token
    {

        #region Knobs
        public CargoTypes cargoType;
        #endregion

        #region References

        #endregion

        #region Runtime Variables
        [Header("Runtime Variables")]

        [SerializeField] protected bool isLoaded;

        #endregion

        #region Runtime Variables

        #endregion

        #region Unity Methods
        void Start()
        {
            base.InitializeToken();

        }


        #endregion

        #region Runtime Methods

        #endregion

        #region Public Methods

        #endregion

        #region Getters and Setters

        #endregion
    }

}
