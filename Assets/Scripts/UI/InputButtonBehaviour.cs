using System;
using TMPro;
using UnityEngine;
using static OperationCommand;

namespace SingularHealth.UI
{
    public class InputButtonBehaviour : MonoBehaviour
    {
        public static event Action OnButtonPressed;

        [SerializeField] protected TMP_Text _displayText;
        
        protected int _inputNumber;

        private void OnEnable()
        {
            InputDropDownController.OnButtonSet += SetButton;
        }
 
        protected void CallOnButtonPressed()
        {
            OnButtonPressed?.Invoke();
        }


        private void SetButton(GameObject button, int inputNumber)
        {
            if (button == this.gameObject)
            {
                _displayText.text = inputNumber.ToString();
                this._inputNumber = inputNumber;
            }
        }

        private void OnDisable()
        {
            InputDropDownController.OnButtonSet += SetButton;
        }
    }
}