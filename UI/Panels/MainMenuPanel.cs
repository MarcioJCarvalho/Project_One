using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace Assets._Scripts.UI.Panels
{
    public class MainMenuPanel : MonoBehaviour
    {
        [Space]
        [Header("Audio Source")]
        [Tooltip("Audio de cancelamento ou voltar do menu.")]
        public AudioSource backOrCancelSoundEFX;

        [SerializeField]
        private TextMeshProUGUI VersionLog;    

        // Use this for initialization
        void Start()
        {
            VersionLog.text += " " + Application.version;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonUp("B") || Input.GetKeyUp(KeyCode.Escape))
            {
                CancelSoundEffect();
            }
        }

        private void CancelSoundEffect()
        {
            backOrCancelSoundEFX.Play();
        }

        #region Ações dos botões

        IEnumerator NewGameAsyncScene()
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("CharacterSelect");

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }

        public void NewGame()
        {
            StartCoroutine(NewGameAsyncScene());
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        #endregion
    }
}