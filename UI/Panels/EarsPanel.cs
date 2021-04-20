using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.UI.Panels
{
    public class EarsPanel : ChoiceOfEventsSystem
    {
        public Slider downUp, forwardBackward, smallBig,
                      narrowWide, rotateZOutZIn, rotateYInYOut, 
                      roundedPointy, noLobeLobed;

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

        public void DownUp()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(19, downUp.value);
        }

        public void ForwardBackward()
        {
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(20, forwardBackward.value);
        }                                                                   

        public void SmallBig()                                   
        {                                                                    
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(21, smallBig.value);
        }                                                                    
        public void NarrowWide()                                        
        {                                                                    
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(22, narrowWide.value);
        }                                                                    
                                                                             
        public void RotateZOutZIn()                                     
        {                                                                    
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(23, rotateZOutZIn.value);
        }                                                                    
                                                                             
        public void RotateYInYOut()                                          
        {                                                                    
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(24, rotateYInYOut.value);
        }                                                                    
                                                                             
        public void RoundedPointy()                                       
        {                                                                    
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(25, roundedPointy.value);
        }                                                                    
                                                                             
        public void NoLobeLobed()                                     
        {                                                                    
            CharacterCustom.instance.skinnedMeshRenderer.SetBlendShapeWeight(26, noLobeLobed.value);
        }
    }
}