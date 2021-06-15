using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace SingularHealth.UI
{
    public class InputDropDownController : MonoBehaviour
    {
        public static event Action<GameObject, int> OnButtonSet;

        [SerializeField] private TMP_Dropdown _menu;
        [SerializeField] private GameObject   _inputButtonPrefab;
        [SerializeField] private GameObject   _initialButtonPrefab;
        [SerializeField] private Transform    _inputContent;
        [SerializeField] private Transform    _initialContent;
        [SerializeField] private GameObject   _initialInputPanel;
        [SerializeField] private GameObject   _extraInputPanel;

        private List<GameObject> _initialButtonsPool = new List<GameObject>();
        private List<GameObject> _inputButtonsPool = new List<GameObject>();

        private int _minValue;
        private int _maxValue;

        private void OnEnable()
        {
            InputButtonBehaviour.OnButtonPressed += ClosePanel;
            InitialInputButton.OnClosePanel += ClosePanel;
            InitialInputButton.OnSelection += SetButtons;
        }

        private void Start()
        {
            for (int i = 0; i < 10; i ++)
            {
                GameObject newButton = Instantiate(_initialButtonPrefab, _initialContent);
                _initialButtonsPool.Add(newButton);
                OnButtonSet?.Invoke(newButton, i);
            }
            for (int i = 0; i < 10; i++)
            {
                GameObject newButton = Instantiate(_inputButtonPrefab, _inputContent);
                _inputButtonsPool.Add(newButton);
                OnButtonSet?.Invoke(newButton, i);
            }

        }

        public void SetMenu(int min, int max)
        {
            _minValue = min;
            _maxValue = max;
            SetMenuDisplay();
        }

        public void SetButtons(int initialInput)
        {
            _extraInputPanel.SetActive(true);
            int count = initialInput * 10;
            foreach (var button in _inputButtonsPool)
            {
                OnButtonSet?.Invoke(button, count);
                count++;
            }
        }

        public void SetInitialDisplay()
        {
            _initialInputPanel.SetActive(true);
            int count = 0;
            foreach (var button in _initialButtonsPool)
            {
                OnButtonSet?.Invoke(button, count);
                count++;
            }
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

        private void ClosePanel()
        {
            _extraInputPanel.SetActive(false);
            _initialInputPanel.SetActive(false);
        }

        private void OnDisable()
        {
            InputButtonBehaviour.OnButtonPressed -= ClosePanel;
            InitialInputButton.OnClosePanel -= ClosePanel;
            InitialInputButton.OnSelection -= SetButtons;
        }
    }
}