
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
    }
}