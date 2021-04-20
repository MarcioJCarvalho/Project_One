using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.UI.Panels
{
    public class MouthPanel : ChoiceOfEventsSystem
    {
        public Slider upperlipSmallBig, lowerlipSmallBig, mouthDownUp, mouthNarrowWide;

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

        public void UpperlipSmallBig()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(7, upperlipSmallBig.value);
        }

        public void LowerlipSmallBig()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(8, lowerlipSmallBig.value);
        }

        public void MouthDownUp()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(5, mouthDownUp.value);
        }

        public void MouthNarrowWide()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(6, mouthNarrowWide.value);
        }
    }
}