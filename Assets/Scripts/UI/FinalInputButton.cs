using SingularHealth.Managers;
using static OperationCommand;

namespace SingularHealth.UI
{
    public class FinalInputButton : InputButtonBehaviour
    {
        public void ButtonPress()
        {
            IOperations newClick = new OperationCommand();
            newClick.Operation(OperationType.Store);
            newClick.StoreValue(_inputNumber);
            CommandManager.Instance.AddOperation(newClick);
            CallOnButtonPressed();
        }
    }
}