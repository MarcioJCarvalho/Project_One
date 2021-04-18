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

        public Material skinMaterial;

        private void Awake()
        {
            instance = this;
            GetSkinMetrial();
        }

        public void GetSkinMetrial()
        {
            GameObject skin = GameObject.Find("body");
            Material skinMat = skin.GetComponentInChildren<SkinnedMeshRenderer>().material;
            skinMaterial = skinMat;
        }
    }
}