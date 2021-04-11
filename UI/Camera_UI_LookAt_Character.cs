using System.Collections;
using UnityEngine;

namespace Assets._Scripts.UI
{
    public class Camera_UI_LookAt_Character : MonoBehaviour
    {
        [HideInInspector]
        public GameObject faceTarget;
        [HideInInspector]
        public GameObject bodyTarget;
        [HideInInspector]
        public GameObject midBodyTarget;

        private void Start()
        {
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
            faceTarget = GameObject.Find("mixamorig:Head");
            bodyTarget = GameObject.Find("mixamorig:Spine");
            midBodyTarget = GameObject.Find("mixamorig:Spine2");
        }
    }
}