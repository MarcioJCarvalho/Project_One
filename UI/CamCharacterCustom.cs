using System.Collections;
using UnityEngine;

namespace Assets._Scripts.UI
{
    public class CamCharacterCustom : MonoBehaviour
    {
        public static CamCharacterCustom instance;

        [Tooltip("Posições que a câmera focará durante a customização do character")]
        public GameObject[] positions;

        [Tooltip("Ajuste de velocidade de movimanteção da câmera")]
        public float speedMove = 2;

        public int indexPositions = 0;

        private Camera camera;

        private void Start()
        {
            instance = this;
            camera = GetComponentInChildren<Camera>();
        }

        private void FixedUpdate()
        {
            CameraUpdate();
        }

        public void CameraUpdate()
        {
            camera.transform.position = Vector3.Lerp(camera.transform.position,
               positions[indexPositions].transform.position, speedMove * Time.deltaTime);
        }

        public void ChangePositionCam(int camPosition)
        {
            if (camPosition == 0)
            {
                indexPositions = 0;
            }
            else if (camPosition == 1)
            {
                indexPositions = 1;
            }
            else
            {
                indexPositions = 2;
            }

        }
    }
}