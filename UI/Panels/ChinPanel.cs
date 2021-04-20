using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.UI.Panels
{
    public class ChinPanel : ChoiceOfEventsSystem
    {
        public Slider chinDownUp, chinNarrowWide, jawNarrowWide;

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

        public void ChinDownUp()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(17, chinDownUp.value);
        }

        public void ChinNarrowWide()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(18, chinNarrowWide.value);
        }

        public void JawNarrowWide()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(4, jawNarrowWide.value);
        }
    }
}