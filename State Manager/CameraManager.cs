using System.Collections;
using UnityEngine;
using Cinemachine;
using Assets._Scripts.FSM;

namespace Assets._Scripts.State_Manager
{
    /// <summary>
    /// Classe responsavel por setar o Look On e Follow das Cameras Virtuais do Cinemachine 
    /// </summary>
    public class CameraManager : StateManager
    {
        // states é uma instancia da minha classe PlayerStateManager

        #region Variaveis Publicas

        //[HideInInspector]
        public Transform follow, lookAt;
        //[HideInInspector]
        public CinemachineFreeLook vCam;
        //[HideInInspector]
        public GameObject lookOnTarget, followTarget;

        #endregion

        #region Callback StateManager

        public override void Init()
        {
            lookOnTarget = GameObject.Find("Look Camera Target");
            followTarget = GameObject.Find("Chal_Rig");

            vCam = GetComponent<CinemachineFreeLook>();

            SetTargetCam();
        }

        public void SetTargetCam()
        {
            lookAt = lookOnTarget.transform;
            follow = followTarget.transform;
            vCam.m_Follow = follow;
            vCam.m_LookAt = lookAt;
        }

        #endregion
    }
}