using UnityEngine;

namespace Assets._Scripts.UI.Panels
{
    public class BodyTypePanel : ChoiceOfEventsSystem
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

        public void SelectBodyTypeA()
        {
            CharacterCustom.instance.bodyTypeA.SetActive(true);
            if (CharacterCustom.instance.bodyTypeA.activeInHierarchy)
            {
                CharacterCustom.instance.bodyTypeB.SetActive(false);
                CharacterCustom.instance.bodyTypeB.transform.position = Vector3.zero;
                CharacterCustom.instance.bodyTypeB.transform.rotation = Quaternion.Euler(0, 180, 0);
                CharacterCustom.instance.GetSkinMetrial();
                CharacterCustom.instance.GetSkinnedMeshRenderer();
                CharacterCustom.instance.GetEyes();
                Camera_UI_LookAt_Character.instance.GetTargetCam();
            }
        }

        public void SelectBodyTypeB()
        {
            CharacterCustom.instance.bodyTypeB.SetActive(true);
            if (CharacterCustom.instance.bodyTypeB.activeInHierarchy)
            {
                CharacterCustom.instance.bodyTypeA.SetActive(false);
                CharacterCustom.instance.bodyTypeA.transform.position = Vector3.zero;
                CharacterCustom.instance.bodyTypeA.transform.rotation = Quaternion.Euler(0, 180, 0);
                CharacterCustom.instance.GetSkinMetrial();
                CharacterCustom.instance.GetSkinnedMeshRenderer();
                CharacterCustom.instance.GetEyes();
                Camera_UI_LookAt_Character.instance.GetTargetCam();
            }
        }
    }
}