using System.Collections;
using UnityEngine;

namespace Assets._Scripts.UI
{
    public class CharacterCustom : MonoBehaviour
    {
        public GameObject bodyTypeA;
        public GameObject bodyTypeB;
        public Transform instantTransform;

        // Use this for initialization
        void Start()
        {
            // Default
            SelectBodyTypeA();
        }

        public void SelectBodyTypeA()
        {
            Instantiate(bodyTypeA, instantTransform.position, instantTransform.rotation);
            
        }

        public void SelectBodyTypeB()
        {
            Instantiate(bodyTypeB, instantTransform.position, instantTransform.rotation);
        }
    }
}