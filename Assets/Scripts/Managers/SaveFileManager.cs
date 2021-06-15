using System.Collections;
using System.Collections.Generic;
using SingularHealth.Command;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SingularHealth.Managers
{
    public class SaveFileManager : MonoBehaviour
    {
        private OperationBuffer _operationBuffer = new OperationBuffer();
        private string _filePath;

        void Start()
        {
            _filePath = Application.persistentDataPath + "SaveFile.dat";
        }

        public void SaveFile()
        {
            OperationBuffer savedBuffer = CommandManager.Instance.GetOperations();
            BinaryFormatter binaryFormat = new BinaryFormatter();
            FileStream file;

            if (File.Exists(_filePath))
                file = File.Open(_filePath, FileMode.Open);
            else
                file = File.Create(_filePath);

            binaryFormat.Serialize(file, savedBuffer);
            file.Close();
        }

        public void LoadFile()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream file = File.Open(_filePath, FileMode.Open))
            {
                _operationBuffer = (OperationBuffer)binaryFormatter.Deserialize(file);
                CommandManager.Instance.SetOperations(_operationBuffer);
            }
        }
    }
}