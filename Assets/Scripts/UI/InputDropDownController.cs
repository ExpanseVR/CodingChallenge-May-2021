using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace SingularHealth.UI
{
    public class InputDropDownController : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _menu;

        private int _minValue;
        private int _maxValue;

        public void SetMenu(int min, int max)
        {
            _minValue = min;
            _maxValue = max;
            SetMenuDisplay();
        }

        private void SetMenuDisplay()
        {
            _menu.ClearOptions();
            List<string> options = new List<string>();

            int count = _minValue;

            while (count <= _maxValue)
            {
                options.Add(count.ToString());
                count++;
            }
            _menu.AddOptions(options);
            _menu.SetValueWithoutNotify(-1);
        }
    }
}