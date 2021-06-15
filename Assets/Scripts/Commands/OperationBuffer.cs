using System;
using System.Collections.Generic;
using UnityEngine;

namespace SingularHealth.Command
{
    [Serializable]
    public class OperationBuffer
    {
        [SerializeField] public List<string> operationsList = new List<string>();
    }
}