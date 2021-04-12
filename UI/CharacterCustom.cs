using System.Collections;
using UnityEngine;

namespace Assets._Scripts.UI
{
    public class CharacterCustom : MonoBehaviour
    {
        public GameObject bodyTypeA;
        public GameObject bodyTypeB;

        private Vector3 basePosition;
     
        // Use this for initialization
        void Start()
        {
            // Default
            SelectBodyTypeA();
            basePosition = Vector3.zero;
        }

        public void SelectBodyTypeA()
        {
            bodyTypeA.SetActive(true);
            bodyTypeA.transform.position = basePosition;
            if (bodyTypeA.activeInHierarchy)
            {
                bodyTypeB.SetActive(false);
            }
            
        }

        public void SelectBodyTypeB()
        {
            bodyTypeB.SetActive(true);
            bodyTypeB.transform.position = basePosition;
            if (bodyTypeB.activeInHierarchy)
            {
                bodyTypeA.SetActive(false);
            }
        }
    }
}