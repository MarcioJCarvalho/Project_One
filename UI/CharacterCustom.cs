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
            basePosition = Vector3.zero;
        }

        public void SelectBodyTypeA()
        {
            bodyTypeA.SetActive(true);
            if (bodyTypeA.activeInHierarchy)
            {
                bodyTypeB.SetActive(false);
                bodyTypeB.transform.position = basePosition;
                bodyTypeB.transform.rotation = Quaternion.Euler(0, 180, 0);
                Camera_UI_LookAt_Character.instance.GetTargetCam();
            }

        }

        public void SelectBodyTypeB()
        {
            bodyTypeB.SetActive(true);
            
            if (bodyTypeB.activeInHierarchy)
            {
                bodyTypeA.SetActive(false);
                bodyTypeA.transform.position = basePosition;
                bodyTypeA.transform.rotation = Quaternion.Euler(0, 180, 0);
                Camera_UI_LookAt_Character.instance.GetTargetCam();
            }
        }
    }
}