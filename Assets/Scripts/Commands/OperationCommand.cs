using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationCommand : IOperations
{
    public enum OperationType
    {
        Add,
        Subtract,
        Mulitply,
        Divide,
        Square,
        Power,
        Store
    }
    
    private int _storedValue;
    private OperationType _operationType;

    public void StoreValue(int newValue)
    {
        _storedValue = newValue;
    }

    public void Operation(OperationType operationType)
    {
        this._operationType = operationType;
    }

    public OperationType GetOperationType()
    {
        return _operationType;
    }

    public int GetStoredValue()
    {
        return _storedValue;
    }

    public int ExecuteOperation(int firstNumber, int secondNumber)
    {
        switch (_operationType)
        {
            case OperationType.Add:
                return firstNumber + secondNumber;
            case OperationType.Subtract:
                return firstNumber - secondNumber;
            case OperationType.Mulitply:
                return firstNumber * secondNumber;
            case OperationType.Divide:
                return firstNumber / secondNumber;
            case OperationType.Power:
                return (int)Mathf.Pow(firstNumber, secondNumber);
            case OperationType.Square:
                return (int)Mathf.Sqrt(secondNumber);
            default:
                return 0;
        }
    }
}