using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SingularHealth.UI
{
    public class UIState_Slider : UIState
    {
        [Header("Component References")]
        [SerializeField] private Image _amountBackground;
        [SerializeField] private TMP_Text _minText;
        [SerializeField] private TMP_Text _maxText;

        [Header("Colors")]
        [SerializeField] private Color _amountLightColor;
        [SerializeField] private Color _amountDarkColor;
        [SerializeField] private Color _textLightColor;
        [SerializeField] private Color _textDarkColor;

        public override void SetDarkMode()
        {
            _amountBackground.color = _amountDarkColor;
            _minText.color = _textDarkColor;
            _maxText.color = _textDarkColor;
        }

        public override void SetLightMode()
        {
            _amountBackground.color = _amountLightColor;
            _minText.color = _textLightColor;
            _maxText.color = _textLightColor;
        }
    }
}