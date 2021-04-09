using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets._Scripts.UI
{
   public class ChoiceOfEventsSystem : MonoBehaviour
    {
        [Header("Event System")]
        [Tooltip("Primeiro botão a ser selecionado na navegação da UI")]
        public GameObject firstSelected;
        [Tooltip("Botão para onde voltará a seleção após o fechamento do painel")]
        public GameObject lastSelected;

        protected void EnterButton()
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstSelected);
        }

        protected void ScapeButton()
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(lastSelected);
        }
    }
}