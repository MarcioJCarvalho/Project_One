using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Assets._Scripts.UI.Panels
{
    public class SkinPanel : ChoiceOfEventsSystem
    {
        /*
        public Texture2D[] skinColor = new Texture2D[16];
        private Button[] btn;
         */
        [Space]
        [Tooltip("Texturas das peles")]
        public Texture2D color_01, color_02, color_03, color_04, 
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

        #region métodos de set colors dos botões
        public void SetColor01()
        {
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", color_01);
        }

        public void SetColor02()
        {
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", color_02);
        }

        public void SetColor03()
        {
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", color_03);
        }

        public void SetColor04()
        {
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", color_04);
        }

        public void SetColor05()
        {
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", color_05);
        }

        public void SetColor06()
        {
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", color_06);
        }

        public void SetColor07()
        {
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", color_07);
        }

        public void SetColor08()
        {
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", color_08);
        }

        public void SetColor09()
        {
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", color_09);
        }

        public void SetColor10()
        {
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", color_10);
        }

        public void SetColor11()
        {
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", color_11);
        }

        public void SetColor12()
        {
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", color_12);
        }

        public void SetColor13()
        {
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", color_13);
        }
        public void SetColor14()
        {
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", color_14);
        }

        public void SetColor15()
        {
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", color_15);
        }
        public void SetColor16()
        {
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", color_16);
        }
        #endregion

        #region trabalhando com listas
        /*
        private void GetButtons()  
        {                          
            btn = GetComponentsInChildren<Button>();
        }                          
                                   
        public void SetSkinColor() 
        {                          
            CharacterCustom.instance.skinMaterial.SetTexture("_BaseColorMap", skinColor[15]);
        }                          

        public void SetTextureInButton()
        {
            for (int i = 0; i < skinColor.Length; i++)
            {
                Texture2D color = skinColor[i];
                //btn[i] = gameObject.AddComponent(typeof(Texture2D)) as color;
            }
        }
         */
        #endregion
    }
}