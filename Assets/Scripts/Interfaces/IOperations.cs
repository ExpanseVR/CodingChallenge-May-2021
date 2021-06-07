using static OperationCommand;

public interface IOperations
{
    void StoreValue(int newValue);
    void Operation(OperationType operationType);
    OperationType GetOperationType();
    int GetStoredValue();
    int ExecuteOperation(int firstNumber, int secondNumber);
}
