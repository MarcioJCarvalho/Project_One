using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Assets._Scripts.UI.Panels
{
    public class SkinPanel : ChoiceOfEventsSystem
    {
        public Texture2D[] skinColor;
        private Button[] btn;


        #region Inicialização dos botões

        private void OnEnable()
        {
            EnterButton();
            GetButtons();
        }

        private void OnDisable()
        {
            ScapeButton();
        }

        #endregion

        private void GetButtons()
        {
            btn = GetComponentsInChildren<Button>();
        }

        public void SetSkinColor()
        {
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", skinColor[15]);
        }
    }
}