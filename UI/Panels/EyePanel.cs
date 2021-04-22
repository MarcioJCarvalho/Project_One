using System.Collections;
using UnityEngine;

namespace Assets._Scripts.UI.Panels
{
    public class EyePanel : ChoiceOfEventsSystem
    {
        [Space]
        [Tooltip("Texturas das peles")]
        public Color32 color_01, color_02, color_03, color_04,
                         color_05, color_06, color_07, color_08,
                         color_09, color_10, color_11, color_12,
                         color_13, color_14, color_15, color_16;

        #region Inicialização dos botões

        private void OnEnable()
        {
            EnterButton();
        }

        private void OnDisable()
        {
            ScapeButton();
        }

        #endregion

        #region Funções de cores das iris

        public void SetColor01()
        {
            CharacterCustom.instance.irisMaterial.SetColor("_BaseColor", color_01);
        }

        public void SetColor02()
        {
            CharacterCustom.instance.irisMaterial.SetColor("_BaseColor", color_02);
        }

        public void SetColor03()
        {
            CharacterCustom.instance.irisMaterial.SetColor("_BaseColor", color_03);
        }

        public void SetColor04()
        {
            CharacterCustom.instance.irisMaterial.SetColor("_BaseColor", color_04);
        }

        public void SetColor05()
        {
            CharacterCustom.instance.irisMaterial.SetColor("_BaseColor", color_05);
        }

        public void SetColor06()
        {
            CharacterCustom.instance.irisMaterial.SetColor("_BaseColor", color_06);
        }

        public void SetColor07()
        {
            CharacterCustom.instance.irisMaterial.SetColor("_BaseColor", color_07);
        }

        public void SetColor08()
        {
            CharacterCustom.instance.irisMaterial.SetColor("_BaseColor", color_08);
        }

        public void SetColor09()
        {
            CharacterCustom.instance.irisMaterial.SetColor("_BaseColor", color_09);
        }

        public void SetColor10()
        {
            CharacterCustom.instance.irisMaterial.SetColor("_BaseColor", color_10);
        }

        public void SetColor11()
        {
            CharacterCustom.instance.irisMaterial.SetColor("_BaseColor", color_11);
        }

        public void SetColor12()
        {
            CharacterCustom.instance.irisMaterial.SetColor("_BaseColor", color_12);
        }

        public void SetColor13()
        {
            CharacterCustom.instance.irisMaterial.SetColor("_BaseColor", color_13);
        }
        public void SetColor14()
        {
            CharacterCustom.instance.irisMaterial.SetColor("_BaseColor", color_14);
        }

        public void SetColor15()
        {
            CharacterCustom.instance.irisMaterial.SetColor("_BaseColor", color_15);
        }
        public void SetColor16()
        {
            CharacterCustom.instance.irisMaterial.SetColor("_BaseColor", color_16);
        }

        #endregion
    }
}