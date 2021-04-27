using System.Collections;
using UnityEngine;

namespace Assets._Scripts.UI
{
    public class Camera_UI_LookAt_Character : MonoBehaviour
    {
        public static Camera_UI_LookAt_Character instance;

        [HideInInspector]
        public GameObject faceTarget;
        [HideInInspector]
        public GameObject bodyTarget;
        [HideInInspector]
        public GameObject midBodyTarget;

        public float yOffset;

        private void Start()
        {
            instance = this;
            GetTargetCam();
        }
        private void LateUpdate()
        {
            LookAtCam();
        }

        public void LookAtCam()
        {
            if (CamCharacterCustom.instance.indexPositions == 0)
            {
                transform.LookAt(bodyTarget.transform);
            }
            else if (CamCharacterCustom.instance.indexPositions == 1)
            {
                transform.LookAt(midBodyTarget.transform);
            }
            else
            {
                transform.LookAt(faceTarget.transform);
            }
        }

        public void GetTargetCam()
        {
            faceTarget = GameObject.Find("target03");
            bodyTarget = GameObject.Find("target01");
            midBodyTarget = GameObject.Find("target02");
        }
    }
}