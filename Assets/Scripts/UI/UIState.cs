using UnityEngine;

namespace SingularHealth.UI
{
    public abstract class UIState : MonoBehaviour
    {
        private void OnEnable()
        {
            UIStateController.OnStateChange += SetUIMode;
        }

        virtual protected void SetUIMode(bool _isDarkMode)
        {
            if (_isDarkMode)
                SetDarkMode();
            else
                SetLightMode();
        }

        public abstract void SetDarkMode();

        public abstract void SetLightMode();


        private void OnDisable()
        {
            UIStateController.OnStateChange += SetUIMode;
        }
    }
}