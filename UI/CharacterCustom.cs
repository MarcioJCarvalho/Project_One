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

        public SkinnedMeshRenderer skinnedMeshRenderer;

        public Material skinMaterial;

        //public int lastIndexPosition = 0;

        private GameObject skinnedMR;

        private void Awake()
        {
            instance = this;
            GetSkinMetrial();
            GetSkinnedMeshRenderer();
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

        private void CancelSoundEffect()
        {
            backOrCancelSoundEFX.Play();
        }
    }
}