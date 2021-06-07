using System.Collections.Generic;
using UnityEngine;
using static OperationCommand;

namespace SingularHealth.Managers
{
    public class CommandManager : MonoBehaviour
    {
        private static CommandManager _instance;
        public static CommandManager Instance
        {
            get
            {
                if (_instance == null)
                    Debug.LogError("The CommandManager is NULL");

                return _instance;
            }
        }

        private List<IOperations> _operationBuffer     = new List<IOperations>();
        private List<IOperations> _operationRedoBuffer = new List<IOperations>();

        private void Awake()
        {
            _instance = this;
        }

        public void AddOperation(IOperations newOperation)
        {
            if (IsPreviousOperationSame(newOperation.GetOperationType()))
                return;

            _operationBuffer.Add(newOperation);

            int operationCount = _operationBuffer.Count;
            ExecuteOperations();
            UpdateOperationHistoryUI();
            _operationRedoBuffer = _operationBuffer.ConvertAll((p => p));
        }

        public void UndoOperation()
        {
            int operationCount = _operationBuffer.Count;
            if (operationCount == 0)
                return;

            _operationBuffer.RemoveAt(operationCount - 1);
            ExecuteOperations();
            UpdateOperationHistoryUI();
        }

        public void RedoOperation()
        {
            int operationCount = _operationBuffer.Count;
            int redoCount = _operationRedoBuffer.Count;

            if (redoCount == operationCount)
                return;

            _operationBuffer.Add(_operationRedoBuffer[operationCount]);
            ExecuteOperations();
            UpdateOperationHistoryUI();
        }

        private void UpdateOperationHistoryUI()
        {
            string operations = "";
            foreach (var operation in _operationBuffer)
            {
                if (operation.GetOperationType() == OperationType.Store)
                    operations += operation.GetStoredValue().ToString() + "\n";
                else
                    operations += operation.GetOperationType().ToString() + "\n";
            }

            UIManager.Instance.SetOperationHistoryText(operations);
        }

        private void ExecuteOperations()
        {
            bool isFirst = true;
            int total = 0;
            IOperations currentOperation = new OperationCommand();

            foreach (var operation in _operationBuffer)
            {
                if (operation.GetOperationType() == OperationType.Store)
                {
                    if (isFirst)
                    {
                        total = operation.GetStoredValue();
                        isFirst = false;
                    }
                    else
                    {
                        int nextInput = operation.GetStoredValue();
                        total = currentOperation.ExecuteOperation(total, nextInput);
                    }
                }
                else
                {
                    currentOperation = operation;
                }
            }

            UIManager.Instance.SetResultText(total.ToString());
        }

        private bool IsPreviousOperationSame(OperationType operationType)
        {
            int operationCount = _operationBuffer.Count;

            //check first call is of type Store
            if (operationCount == 0)
            {
                if (operationType == OperationType.Store)
                    return false;
                else
                    return true;
            }

            if (operationType == OperationType.Store)
            {
                if (_operationBuffer[operationCount - 1].GetOperationType() == OperationType.Store)
                    return true;
                else
                    return false;
            }
            else
            {
                if (_operationBuffer[operationCount - 1].GetOperationType() != OperationType.Store)
                    return true;
                else
                    return false;
            }
        }
    }
}