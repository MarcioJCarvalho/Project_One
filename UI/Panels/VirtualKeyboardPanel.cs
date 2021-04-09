using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets._Scripts.UI.Panels
{
    public class VirtualKeyboardPanel : ChoiceOfEventsSystem
    {
        public static bool IsActive = false;

        private string word = null;
        private int wordIdex = 0;
        private string alpha;
        private string space = " ";

        [Header("Panel")]
        [Tooltip("Colocar o game object que se alto fachara em alguma ação que você ira determinar")]
        public GameObject IAmThis;

        [Header("Text In")]
        [Tooltip("colocar o component text para leitura / escrita")]
        public TextMeshProUGUI playerName = null;

        [Header("Boleanos")]
        [Tooltip("Marcar esta opção caso use para preencher dados para persistência")]
        public bool keyboardForNickname;



        #region Inicialização dos botões

        private void OnEnable()
        {
            EnterButton();
            IsActive = true;
        }

        private void OnDisable()
        {
            ScapeButton();
            IsActive = false;
        }

        #endregion

        private void Update()
        {
            OnJoistck();
        }

        public void AlphabetFunction(string alphabet)
        {
            wordIdex++;
            word += alphabet;
            playerName.text = word;
        }

        public void SpaceButton()
        {
            wordIdex++;
            word += space;
            playerName.text = word;
        }

        public void EnterBtn()
        {
            // aqui vai onde salva o nome no playerprefs
            IAmThis.SetActive(false);
        }

        #region Funções rodando em tempo real

        public void OnJoistck()
        {
            if (Input.GetButton("Y"))
            {
                SpaceButton();
            }
        }

        #endregion
    }
}