using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Photon.Pun;
using Assets._Scripts.FSM;
using Assets._Scripts.State_Action;

namespace Assets._Scripts.State_Manager
{
    /// <summary>
    /// Classe responsavel pelo estado do player herdada de CharacterStateManager
    /// Gerente de Estado do Jogador
    /// </summary>
    public class PlayerStateManager : CharacterStateManager
    {
        #region Variaveis Publicas
        [Header("Inputs")]
        public float mouseX;
        public float mouseY;
        public float moveAmount;
        public Vector3 rotateDirection;

        [Header("Cameras References")]
        public  CinemachineFreeLook normalCamera;
        public  CinemachineFreeLook lockOnCamera;
        [HideInInspector]
        public new Transform cameraTransform;

        [Header("Cameras Instances")]
        public GameObject camForInstance;

        [Header("Movement Stats")]
        public float frontRayOffset = .5f;
        public float movementSpeed = 1;
        public float adaptSpeed = 1;
        public float rotationSpeed = 10;

        [HideInInspector]
        public PhotonView photonView; // para uso do photonview

        [HideInInspector]
        public LayerMask ignoreForGroundCheck;
        
        public string locomotionId = "locomotion";
        public string attckStateId = "attckState";

        #endregion

        public override void Init()
        {
            // chamada de metodo abstrato Init da classe pai CharacterStateManager
            base.Init();
            State locomotion = new State(
                new List<StateAction>() // Fixed Update
                {
                    new MovePlayerCharacter(this)
                },
                new List<StateAction>() // Update
                {
                    new InputManager(this)
                },
                new List<StateAction>() // Late Update
                {

                }
                );
     
            locomotion.onEnter = DisableRootMotion;

            State attckState = new State(
               new List<StateAction>() // Fixed Update
               {

               },
               new List<StateAction>() // Update
               {
                   new MonitorInteratingAnimation(this, "isInteracting", locomotionId),
               },
               new List<StateAction>() // Late Update
               {

               }
               );

            attckState.onEnter = EnableRootMotion;

            RegisterState(locomotionId, locomotion);
            RegisterState(attckStateId, locomotion);

            ChangeState(locomotionId);
            ignoreForGroundCheck = ~(1 << 9 | 1 << 10);

            photonView = GetComponent<PhotonView>(); //pegando o photonview

            #region Implementação das cameras para uso do Photon2

            // instanciamento das cameras
            if (photonView.IsMine)
            {
                Instantiate(camForInstance);
                Instantiate(normalCamera);
                Instantiate(lockOnCamera);

                if (lockOnCamera == true)
                {
                    lockOnCamera.gameObject.SetActive(false);
                }

                SetReferenceCamera();
            }

            #endregion          
        }

        private void FixedUpdate()
        {
            delta = Time.fixedDeltaTime;

            base.FixedTick();
        }


        //public bool debugLock;
        private void Update()
        {
            delta = Time.deltaTime;

            base.Tick();
        }

        private void LateUpdate()
        {
            base.LateTick();
        }

        private void SetReferenceCamera()
        {
            camForInstance = GameObject.Find("Camera Actual(Clone)");
            cameraTransform = camForInstance.transform;
        }

        #region Lock On Câmera

        public override void OnAssignLookOverride(Transform traget)
        {
            base.OnAssignLookOverride(traget);

            if (lockOn == false)
                return;

            normalCamera.gameObject.SetActive(false);
            lockOnCamera.gameObject.SetActive(true);
            lockOnCamera.m_LookAt = target;
        }

        public override void OnClearLookOverride()
        {
            base.OnClearLookOverride();
            normalCamera.gameObject.SetActive(true);
            lockOnCamera.gameObject.SetActive(false);
        }

        #endregion

        #region State Events

        void DisableRootMotion()
        {
            useRootMotion = false;
        }

        void EnableRootMotion()
        {
            useRootMotion = true;
        }

        #endregion
    }
}