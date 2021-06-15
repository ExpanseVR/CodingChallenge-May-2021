using System;
using UnityEngine;
using static OperationCommand;

namespace SingularHealth.Command
{
    public static class OperationToString
    {
        public static string ToString (IOperations operation)
        {
            string convertedOperation = operation.GetOperationType().ToString();

            if (operation.GetOperationType() == OperationType.Store)
                convertedOperation += ":" + operation.GetStoredValue().ToString();

            return convertedOperation;
        }

        public static IOperations ToOperation(string operationString)
        {
            OperationCommand convertedOperation = new OperationCommand();

            int operationIndex = operationString.IndexOf(":");

            if (operationIndex > 0)
            {
                string enumString = operationString.Substring(0, operationIndex);
                OperationType convertedEnum = (OperationType)Enum.Parse(typeof(OperationType), enumString);
                convertedOperation.Operation(convertedEnum);

                if (convertedEnum == OperationType.Store)
                {
                    string stringValue = operationString.Substring(operationIndex +1);
                    int storeValue = int.Parse(stringValue);
                    convertedOperation.StoreValue(storeValue);
                }
            }
            else
            {
                OperationType convertedEnum = (OperationType)Enum.Parse(typeof(OperationType), operationString);
                convertedOperation.Operation(convertedEnum);
            }

            return convertedOperation;
        }
    }
}