using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.UI.Panels
{
    public class CheekPanel : ChoiceOfEventsSystem
    {  
        public Slider cheekBackwardForward, cheekRecessBulge, cheekDownUp, cheekNarrowWide;

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

        #region funções dos sliders
        public void CheekBackwardForward()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(0, cheekBackwardForward.value);
        }

        public void CheekRecessBulge()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(1, cheekRecessBulge.value);
        }

        public void CheekDownUp()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(2, cheekDownUp.value);
        }

        public void CheekNarrowWide()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(3, cheekNarrowWide.value);
        }
        #endregion
    }
}