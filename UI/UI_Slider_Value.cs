using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets._Scripts.UI
{
    public class UI_Slider_Value : MonoBehaviour
    {
        [HideInInspector]
        public Slider slider;
        [HideInInspector]
        public TextMeshProUGUI value;
        [Tooltip("Para valores onde o padrão definido é zero")]
        public bool setToZero = false;

        private void Start()
        {
            slider = GetComponent<Slider>();
            value = GetComponentInChildren<TextMeshProUGUI>();
        }
        void Update()
        {
            SliderValue();
        }

        private void SliderValue()
        {
            if (!setToZero)
            {
                if (slider.value == 50)
                {
                    value.text = "0";
                }
                else if (slider.value < 50)
                {
                    float decrement = slider.value - 50;
                    int iValue = (int)decrement;
                    value.text = iValue.ToString();
                }
                else
                {
                    float increment = slider.value - 50;
                    int iValue = (int)increment;
                    value.text = iValue.ToString();
                }
            }
            else
            {
                float increment = slider.value;
                int iValue = (int)increment;
                value.text = iValue.ToString();
            }
        }
    }
}