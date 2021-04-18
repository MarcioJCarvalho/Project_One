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

        public SkinnedMeshRenderer skinnedMeshRenderer;

        public Material skinMaterial;

        private GameObject skinnedMR;

        private void Awake()
        {
            instance = this;
            GetSkinMetrial();
        }

        public void GetSkinMetrial()
        {
            skinnedMR = GameObject.Find("body");
            Material skin = skinnedMR.GetComponentInChildren<SkinnedMeshRenderer>().material;
            skinMaterial = skin;
        }

        public void GetSkinnedMeshRenderer()
        {
            skinnedMeshRenderer = skinnedMR.GetComponentInChildren<SkinnedMeshRenderer>();
        }
    }
}