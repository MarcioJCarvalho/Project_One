using System.Collections;
using UnityEngine;

namespace Assets._Scripts.UI.Panels
{
    public class EyebrowPanel : ChoiceOfEventsSystem
    {
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

    }
}