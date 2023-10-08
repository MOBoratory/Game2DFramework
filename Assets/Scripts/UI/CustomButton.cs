using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MOB.Framework.Game2D.UI
{
    /// <summary>
    /// ボタン基底.
    /// </summary>
    public sealed class CustomButton : Button
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        public void Initialize(string text)
        {
            _text.SetText(text);
        }
    }
}