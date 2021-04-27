using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace Assets._Scripts.UI
{
    public class CharacterCustom : MonoBehaviour
    {
        public static CharacterCustom instance;

        public GameObject bodyTypeA;
        public GameObject bodyTypeB;

        [Space]
        [Header("Audio Source")]
        [Tooltip("Audio de cancelamento ou voltar do menu.")]
        public AudioSource backOrCancelSoundEFX;

        [HideInInspector] public Material skinMaterial;
        [HideInInspector] public Material eyeMaterial;
        [HideInInspector] public Material scleraMaterial;
        [HideInInspector] public Material irisMaterial;

        [HideInInspector] public SkinnedMeshRenderer skinnedMeshRenderer;

        

        //public int lastIndexPosition = 0;

        private GameObject skinnedMR;
        private GameObject eye;
        private GameObject sclera;
        private GameObject iris;

        private void Awake()
        {
            instance = this;
            GetSkinMetrial();
            GetSkinnedMeshRenderer();
            GetEyes();
        }

        private void Update()
        {
            if (Input.GetButton("B") || Input.GetKey(KeyCode.Escape))
            {
                UI_AppearencePanel.instance.UnloadAllPanels();
                /*
                for (int i = 0; i < UI_AppearencePanel.instance.panels.Length; i++)
                {
                    if (!UI_AppearencePanel.instance.panels[i].activeInHierarchy)
                    {
                        CamCharacterCustom.instance.ChangePositionCam(0);
                    }
                }
                 */
            }

            if (Input.GetButtonUp("B") || Input.GetKeyUp(KeyCode.Escape))
            {
                CancelSoundEffect();
            }
        }

        public GameObject GetBody()
        {
            skinnedMR = GameObject.Find("body");
            return skinnedMR;
        }

        public GameObject GetEye()
        {
            eye = GameObject.Find("eyes");
            return eye;
        }

        public GameObject GetSclera()
        {
            sclera = GameObject.Find("sclera");
            return sclera;
        }

        public GameObject GetIris()
        {
            iris = GameObject.Find("iris");
            return iris;
        }

        public void GetSkinMetrial()
        {
            GetBody();
            Material skin = skinnedMR.GetComponentInChildren<SkinnedMeshRenderer>().material;
            skinMaterial = skin;
        }

        public void GetSkinnedMeshRenderer()
        {
            GetBody();
            SkinnedMeshRenderer skmr = skinnedMR.GetComponentInChildren<SkinnedMeshRenderer>();
            skinnedMeshRenderer = skmr;
        }

        public void GetEyes()
        {
            GetEye();
            GetSclera();
            GetIris();
            Material eyeMat = eye.GetComponentInChildren<SkinnedMeshRenderer>().material;
            Material scleraMat = sclera.GetComponentInChildren<SkinnedMeshRenderer>().material;
            Material irisMat = iris.GetComponentInChildren<SkinnedMeshRenderer>().material;
            
            eyeMaterial = eyeMat;
            scleraMaterial = scleraMat;
            irisMaterial = irisMat;
        }

        private void CancelSoundEffect()
        {
            backOrCancelSoundEFX.Play();
        }
    }
}