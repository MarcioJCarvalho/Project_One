using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets._Scripts.UI
{
    /// <summary>
    /// Classe responsavel por habilitar a si mesmo logo após o objeto estar ativo
    /// </summary>
    public class SelectSelf : MonoBehaviour
    {
        private Button btn;
        private void OnEnable()
        {
            btn = GetComponent<Button>();
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(btn.gameObject);
        }
    }
}