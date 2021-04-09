using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets._Scripts.UI
{
    public class UI_AppearencePanel : MonoBehaviour
    {
        [Header("Panels")]
        public GameObject namePanel;
        public GameObject bodyPanel;
        public GameObject skinPanel;
        public GameObject eyePanel;
        public GameObject eyebrowPanel;
        public GameObject cheekPanel;
        public GameObject chinPanel;
        public GameObject mouthPanel;
        public GameObject nosePanel;
        public GameObject earsPanel;
        public GameObject hairPanel;

        [Header("Audio Source")]
        [Tooltip("Audio de cancelamento ou voltar do menu.")]
        public AudioSource backOrCancelSoundEFX;

        [Header("Panels List")]
        [Tooltip("Colocar todos os painéis a serem descarregados")]
        public GameObject[] panels;

        // Use this for initialization
        private void Start()
        {
            UnloadAllPanels();
        }

        /// <summary>
        /// Para comandos de interção usamos a update, caso contrario uso de fixedUpdate
        /// </summary>
        private void Update()
        {
            if (Input.GetButton("B") || Input.GetKey(KeyCode.Escape))
            {
                UnloadAllPanels();
                CamCharacterCustom.instance.ChangePositionCam(0);
            }

            if (Input.GetButtonUp("B") || Input.GetKeyUp(KeyCode.Escape))
            {
                CancelSoundEffect();
            }
        }

        /// <summary>
        /// Desativa todos os paines em cena(precaução para que não apareca painel desnecessário)
        /// </summary>
        private void UnloadAllPanels()
        {
            for (int i = 0; i < panels.Length; i++)
            {
                if (panels[i])
                {
                    panels[i].gameObject.SetActive(false);
                }
            }
        }

        /// <summary>
        /// Som do botão ao cancelar
        /// </summary>
        private void CancelSoundEffect()
        {
            backOrCancelSoundEFX.Play();
        }

        /// <summary>
        /// ChangePositionCam(0) = camera pega o corpo inteiro
        /// ChangePositionCam(1) = media distancia
        /// ChangePositionCam(2) = camera de perto
        /// </summary>
        #region Ativa e desativa os Painéis

        public void KeyboardPanel()
        {
            UnloadAllPanels();
            namePanel.SetActive(true);
            CamCharacterCustom.instance.ChangePositionCam(0);
        }

        public void BodyTypePanel()
        {
            UnloadAllPanels();
            bodyPanel.SetActive(true);
            CamCharacterCustom.instance.ChangePositionCam(0);
        }

        public void SkinPanel()
        {
            UnloadAllPanels();
            skinPanel.SetActive(true);
            CamCharacterCustom.instance.ChangePositionCam(1);
        }

        public void EyePanel()
        {
            UnloadAllPanels();
            eyePanel.SetActive(true);
            CamCharacterCustom.instance.ChangePositionCam(2);
        }

        public void EyebrowPanel()
        {
            UnloadAllPanels();
            eyebrowPanel.SetActive(true);
            CamCharacterCustom.instance.ChangePositionCam(2);
        }

        public void CheekPanel()
        {
            UnloadAllPanels();
            cheekPanel.SetActive(true);
            CamCharacterCustom.instance.ChangePositionCam(2);
        }

        public void ChinPanel()
        {
            UnloadAllPanels();
            chinPanel.SetActive(true);
            CamCharacterCustom.instance.ChangePositionCam(2);
        }

        public void MouthPanel()
        {
            UnloadAllPanels();
            mouthPanel.SetActive(true);
            CamCharacterCustom.instance.ChangePositionCam(2);
        }

        public void NosePanel()
        {
            UnloadAllPanels();
            nosePanel.SetActive(true);
            CamCharacterCustom.instance.ChangePositionCam(2);
        }

        public void EarsPanel()
        {
            UnloadAllPanels();
            earsPanel.SetActive(true);
            CamCharacterCustom.instance.ChangePositionCam(2);
        }

        public void HairPanel()
        {
            UnloadAllPanels();
            hairPanel.SetActive(true);
            CamCharacterCustom.instance.ChangePositionCam(2);
        }

        #endregion

    }
}