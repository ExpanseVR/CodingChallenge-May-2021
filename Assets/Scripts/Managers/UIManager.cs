using SingularHealth.UI;
using TMPro;
using UnityEngine;
using static OperationCommand;

namespace SingularHealth.Managers
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager _instance;
        public static UIManager Instance
        {
            get
            {
                if (_instance == null)
                    Debug.LogError("The UIManager is NULL");

                return _instance;
            }
        }

        [SerializeField] private InputDropDownController _inputController;
        [SerializeField] private TMP_Dropdown           _operationDropDown;
        [SerializeField] private TMP_Dropdown           _inputDropDown;
        [SerializeField] private TMP_Text               _operationHistoryText;
        [SerializeField] private TMP_Text               _resultText;

        private void Awake()
        {
            _instance = this;
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
                UndoClick();
            if (Input.GetKeyDown(KeyCode.Y))
                RedoClick();
        }

        public void OperationItemClick()
        {
            OperationType operationType = GetOperationChosen();
            IOperations newClick = new OperationCommand();
            newClick.Operation(operationType);
            CommandManager.Instance.AddOperation(newClick);
        }

        public void InputItemClick()
        {
            int parsedInteger = int.Parse(_inputDropDown.options[_inputDropDown.value].text);
            _inputController.SetButtons(parsedInteger);
        }

        public void UndoClick()
        {
            CommandManager.Instance.UndoOperation();
        }

        public void RedoClick()
        {
            CommandManager.Instance.RedoOperation();
        }

        public void SetOperationHistoryText(string history)
        {
            _operationHistoryText.text = history;
        }

        public void SetResultText(string result)
        {
            _resultText.text = result;
        }

        private OperationType GetOperationChosen()
        {
            int operatinTypeValue = _operationDropDown.value;
            return ((OperationType) operatinTypeValue);
        }
    }
}