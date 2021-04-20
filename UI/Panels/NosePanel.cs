using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.UI.Panels
{
    public class NosePanel : ChoiceOfEventsSystem
    {
        public Slider rootBackwardForward, rootNarrowWide, ridgeBackwardForward,
                      ridgeNarrowWide, tipBackwardForward, tipNarrowWide, 
                      nostrilsSmallBig, nostrilsNarrowWide;

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

        public void RootBackwardForward()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(9, rootBackwardForward.value);
        }

        public void RootNarrowWide()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(10, rootNarrowWide.value);
        }

        public void RidgeBackwardForward()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(11, ridgeBackwardForward.value);
        }
        public void RidgeNarrowWide()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(12, ridgeNarrowWide.value);
        }

        public void TipBackwardForward()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(13, tipBackwardForward.value);
        }

        public void TipNarrowWide()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(14, tipNarrowWide.value);
        }

        public void NostrilsSmallBig()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(15, nostrilsSmallBig.value);
        }

        public void NostrilsNarrowWide()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(16, nostrilsNarrowWide.value);
        }
    }
}