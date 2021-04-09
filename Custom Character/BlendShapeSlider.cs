using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.Custom_Character
{
    [RequireComponent(typeof(Slider))]
    public class BlendShapeSlider : MonoBehaviour
    {
        // não precisa de sulfixo
        public string blendShapeName;
        private Slider slider;
        private void Start()
        {
            blendShapeName = blendShapeName.Trim();
            GetComponent<Slider>();
            // quando o controle deslizante é movido chame as funções com base nas combinações
            //method(blendShapeName, sliderValue)
            //slider.onValueChanged.AddListener;
        }
    }
}