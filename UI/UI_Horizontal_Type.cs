using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.UI
{
    /// <summary>
    /// Classe responsavel por ativar e desativar botoes alinhados horizontalmente usando controle, teclado ou o mouse
    /// </summary>
    public class UI_Horizontal_Type : MonoBehaviour
    {
        [Tooltip("Grupo de tipos de objetos!")]
        [Header("Type Group")]
        public GameObject typeGroup_I;
        public GameObject typeGroup_II;
        public GameObject typeGroup_III;

        [Space]
        [Tooltip("Grupo de tipos de objetos!")]
        [Header("Cursor Group")]
        public Button btn_I;
        public Button btn_II;
        public Button btn_III;

        [Space]
        [Tooltip("Grupo de tipos de objetos!")]
        [Header("Button Group")]
        public Button btnGroup_I;
        public Button btnGroup_II;
        public Button btnGroup_III;

        [Space]
        [Tooltip("Grupo de tipos de objetos!")]
        [Header("Button Color Group")]
        public Button topBtnColor_I;
        public Button topBtnColor_II;
        public Button topBtnColor_III;
        public Button topBtnColor_IV;
        public Button topBtnColor_V;

        [Header("Audio Source")]
        [Tooltip("Audio ao movimentar o cursor horizontalmente")]
        public AudioSource horizonCursorSoundEFX;

        private int i;

        void Start()
        {
            i = 0;
            btn_I.image.color = Color.white;
            typeGroup_I.SetActive(true);
            typeGroup_II.SetActive(false);
            typeGroup_III.SetActive(false);

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.PageUp) || Input.GetButton("RB"))
            {
                ProgressiveChange();
                HorizonCursorSoundEffect();
            }

            if (Input.GetKeyDown(KeyCode.PageDown) || Input.GetButton("LB"))
            {
                RegressiveChange();
                HorizonCursorSoundEffect();
            }

            if (i == 0)
            {
                TypeGorup_I();
            }
            if (i == 1)
            {
                TypeGorup_II();
            }
            if (i == 2)
            {
                TypeGorup_III();
            }
        }

        #region Botões de Ativa e Desativa os TypeGroups
        public void TypeGorup_I()
        {
            btn_I.image.color = Color.white;
            btn_II.image.color = Color.gray;
            btn_III.image.color = Color.gray;

            typeGroup_I.SetActive(true);
            typeGroup_II.SetActive(false);
            typeGroup_III.SetActive(false);

            i = 0;


            #region Precisa melhorar código
            /*
            muda o selectOnUp dos botoes color para os botoes de tipos em cima 
            tornando dinamicamente controlavel a navegação dos menus pelos controles e teclados
             */

            Navigation navigation_I = topBtnColor_I.navigation;
            navigation_I.selectOnUp = btnGroup_I;
            topBtnColor_I.navigation = navigation_I;

            Navigation navigation_II = topBtnColor_II.navigation;
            navigation_II.selectOnUp = btnGroup_I;
            topBtnColor_II.navigation = navigation_II;

            Navigation navigation_III = topBtnColor_III.navigation;
            navigation_III.selectOnUp = btnGroup_I;
            topBtnColor_III.navigation = navigation_III;

            Navigation navigation_IV = topBtnColor_IV.navigation;
            navigation_IV.selectOnUp = btnGroup_I;
            topBtnColor_IV.navigation = navigation_IV;

            Navigation navigation_V = topBtnColor_V.navigation;
            navigation_V.selectOnUp = btnGroup_I;
            topBtnColor_V.navigation = navigation_V;

            #endregion

        }

        public void TypeGorup_II()
        {
            btn_I.image.color = Color.gray;
            btn_II.image.color = Color.white;
            btn_III.image.color = Color.gray;

            typeGroup_I.SetActive(false);
            typeGroup_II.SetActive(true);
            typeGroup_III.SetActive(false);

            i = 1;

            #region Precisa melhorar código
            /*
            muda o selectOnUp dos botoes color para os botoes de tipos em cima 
            tornando dinamicamente controlavel a navegação dos menus pelos controles e teclados
             */

            Navigation navigation_I = topBtnColor_I.navigation;
            navigation_I.selectOnUp = btnGroup_II;
            topBtnColor_I.navigation = navigation_I;

            Navigation navigation_II = topBtnColor_II.navigation;
            navigation_II.selectOnUp = btnGroup_II;
            topBtnColor_II.navigation = navigation_II;

            Navigation navigation_III = topBtnColor_III.navigation;
            navigation_III.selectOnUp = btnGroup_II;
            topBtnColor_III.navigation = navigation_III;

            Navigation navigation_IV = topBtnColor_IV.navigation;
            navigation_IV.selectOnUp = btnGroup_II;
            topBtnColor_IV.navigation = navigation_IV;

            Navigation navigation_V = topBtnColor_V.navigation;
            navigation_V.selectOnUp = btnGroup_II;
            topBtnColor_V.navigation = navigation_V;

            #endregion
        }

        public void TypeGorup_III()
        {
            btn_I.image.color = Color.gray;
            btn_II.image.color = Color.gray;
            btn_III.image.color = Color.white;

            typeGroup_I.SetActive(false);
            typeGroup_II.SetActive(false);
            typeGroup_III.SetActive(true);

            i = 2;

            #region Precisa melhorar código
            /*
            muda o selectOnUp dos botoes color para os botoes de tipos em cima 
            tornando dinamicamente controlavel a navegação dos menus pelos controles e teclados
             */

            Navigation navigation_I = topBtnColor_I.navigation;
            navigation_I.selectOnUp = btnGroup_III;
            topBtnColor_I.navigation = navigation_I;

            Navigation navigation_II = topBtnColor_II.navigation;
            navigation_II.selectOnUp = btnGroup_III;
            topBtnColor_II.navigation = navigation_II;

            Navigation navigation_III = topBtnColor_III.navigation;
            navigation_III.selectOnUp = btnGroup_III;
            topBtnColor_III.navigation = navigation_III;

            Navigation navigation_IV = topBtnColor_IV.navigation;
            navigation_IV.selectOnUp = btnGroup_III;
            topBtnColor_IV.navigation = navigation_IV;

            Navigation navigation_V = topBtnColor_V.navigation;
            navigation_V.selectOnUp = btnGroup_III;
            topBtnColor_V.navigation = navigation_V;

            #endregion
        }
        #endregion

        public void ProgressiveChange()
        {
            i++;

            if (i > 2)
            {
                i = 0;
            }
            if (i < 0)
            {
                i = 2;
            }
        }

        public void RegressiveChange()
        {
            i--;

            if (i > 2)
            {
                i = 0;
            }
            if (i < 0)
            {
                i = 2;
            }
        }

        private void HorizonCursorSoundEffect()
        {
            if (horizonCursorSoundEFX)
            {
                horizonCursorSoundEFX.Play();
            }
        }
    }
}