using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SingularHealth.UI
{
    public class InputLimitControl : MonoBehaviour
    {
        [SerializeField] private InputDropDownController _inputControl;
        [SerializeField] private Slider _slideMin;
        [SerializeField] private Slider _slideMax;
        [SerializeField] private TMP_Text _minText;
        [SerializeField] private TMP_Text _maxText;


        private int _minValue;
        private int _maxValue;

        private void Start()
        {
            GetValues();
        }

        public void MinScrollChange()
        {
            GetValues();

            if (_minValue >= _maxValue)
                _slideMin.value -= 1;

            _inputControl.SetMenu(_minValue, _maxValue);
        }

        public void MaxScrollChange()
        {
            GetValues();

            if (_maxValue <= _minValue)
                _slideMax.value += 1;

            _inputControl.SetMenu(_minValue, _maxValue);
        }

        private void GetValues()
        {
            _minValue = (int)_slideMin.value;
            _maxValue = (int)(9 - _slideMax.value);
            _minText.text = _minValue.ToString();
            _maxText.text = _maxValue.ToString();
        }
    }
}