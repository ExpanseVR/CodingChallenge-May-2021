using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SingularHealth.UI
{
    public class UIState_HistoryPanel : UIState
    {
        [Header("Component References")]
        [SerializeField] private Image    _panelBackground;
        [SerializeField] private Image    _totalBackground;
        [SerializeField] private TMP_Text _historyText;

        [Header("Colors")]
        [SerializeField] private Color _lightTextColor;
        [SerializeField] private Color _darkTextColor;
        [SerializeField] private Color _lightBackgroundColor;
        [SerializeField] private Color _darkBackgroundColor;
        [SerializeField] private Color _lightTotalBackgroundColor;
        [SerializeField] private Color _darkTotalBackgroundColor;

        public override void SetDarkMode()
        {
            _panelBackground.color = _darkBackgroundColor;
            _historyText.color = _darkTextColor;
            _totalBackground.color = _darkTotalBackgroundColor;
        }

        public override void SetLightMode()
        {
            _historyText.color = _lightTextColor;
            _panelBackground.color = _lightBackgroundColor;
            _totalBackground.color = _lightTotalBackgroundColor;
        }
    }
}