using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SingularHealth.UI
{
    public class UIState_Header : UIState
    {
        [Header("Component References")]
        [SerializeField] private Image    _background;
        [SerializeField] private Image    _dropDownOpBackground;
        [SerializeField] private Image    _dropDownOpItemBackground;
        [SerializeField] private TMP_Text _dropDownOpItemText;
        [SerializeField] private Image    _dropDownInputBackground;
        [SerializeField] private Image    _dropDownInputItemBackground;
        [SerializeField] private TMP_Text _dropDownInputItemText;

        [Header("Colors")]
        [SerializeField] private Color _backgroundLightColor;
        [SerializeField] private Color _backgroundDarkColor;
        [SerializeField] private Color _dropDownBGLightColor;
        [SerializeField] private Color _dropDownBGDarkColor;
        [SerializeField] private Color _dropDownTextLightColor;
        [SerializeField] private Color _dropDownTextDarkColor;

        public override void SetDarkMode()
        {
            _background.color = _backgroundDarkColor;
            _dropDownOpBackground.color = _dropDownBGDarkColor;
            _dropDownInputBackground.color = _dropDownBGDarkColor;
            _dropDownOpItemBackground.color = _dropDownBGDarkColor;
            _dropDownInputItemBackground.color = _dropDownBGDarkColor;
            _dropDownOpItemText.color = _dropDownTextDarkColor;
            _dropDownInputItemText.color = _dropDownTextDarkColor;
        }

        public override void SetLightMode()
        {
            _background.color = _backgroundLightColor;
            _dropDownOpBackground.color = _dropDownBGLightColor;
            _dropDownInputBackground.color = _dropDownBGLightColor;
            _dropDownOpItemBackground.color = _dropDownBGLightColor;
            _dropDownInputItemBackground.color = _dropDownBGLightColor;
            _dropDownOpItemText.color = _dropDownTextLightColor;
            _dropDownInputItemText.color = _dropDownTextLightColor;
        }
    }
}