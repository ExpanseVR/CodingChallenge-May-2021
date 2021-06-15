using System;

namespace SingularHealth.UI
{
    public class InitialInputButton : InputButtonBehaviour
    {
        public static event Action<int> OnSelection;
        public static event Action OnClosePanel;

        public void OnPointerEnter()
        {
            OnSelection?.Invoke(_inputNumber);
        }

        public void OnPointerExit()
        {
            //OnClosePanel?.Invoke();
        }
    }
}
