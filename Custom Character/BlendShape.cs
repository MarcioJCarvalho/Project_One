using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Custom_Character
{
    /// <summary>
    /// classe de embrulho para valores positivos e negativos de forma de mistura
    /// </summary>
    public class BlendShape
    {
        public int positiveIndex {get; set;}
        public int negativeIndex {get; set;} 

        public BlendShape (int positiveIndex, int negativeIndex)
        {
            this.positiveIndex = positiveIndex;
            this.negativeIndex = negativeIndex;
        }
    }
}