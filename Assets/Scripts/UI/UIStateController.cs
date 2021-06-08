using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SingularHealth.UI
{
    public class UIStateController : MonoBehaviour
    {
        public static event Action<bool> OnStateChange;

        [Header ("Component References")]
        [SerializeField] private Toggle   _darkModeToggle;
        [SerializeField] private TMP_Text _toggleText;
        [SerializeField] private Image    _toggleBackground;
        [SerializeField] private Camera   _mainCamera;

        [Header("Colors")]
        [SerializeField] private Color _lightTextColor;
        [SerializeField] private Color _darkTextColor;
        [SerializeField] private Color _lightToggleBackgroundColor;
        [SerializeField] private Color _darkToggleBackgroundColor;
        [SerializeField] private Color _mainBackgroundLightColor;
        [SerializeField] private Color _mainBackgroundDarkColor;

        public void SetUIMode ()
        {
            if (_darkModeToggle.isOn)
                SetDarkMode();
            else
                SetLightMode();
        }

        private void SetLightMode()
        {
            _toggleText.text = "Dark Mode";
            _toggleText.color = _lightTextColor;
            _toggleBackground.color = _lightToggleBackgroundColor;
            _mainCamera.backgroundColor = _mainBackgroundLightColor;
            OnStateChange?.Invoke(false);
        }

        private void SetDarkMode()
        {
            _toggleText.text = "Light Mode";
            _toggleText.color = _darkTextColor;
            _toggleBackground.color = _darkToggleBackgroundColor;
            _mainCamera.backgroundColor = _mainBackgroundDarkColor;
            OnStateChange?.Invoke(true);
        }
    }
}