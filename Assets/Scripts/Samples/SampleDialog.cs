using System.Collections.Generic;
using MOB.Framework.Game2D.UI;
using UnityEngine;

namespace MOB.Framework.Game2D.Samples
{
    public sealed class SampleDialog : DialogBase<SampleDialog.ViewData>, IDialog<SampleDialog.ViewData>
    {
        public override void Initialize(ViewData viewData)
        {
            AddButtons(viewData.FooterButtonDataList);
        }

        /// <summary>
        ///     ボタンを追加します.
        /// </summary>
        /// <param name="buttonData">ボタン設定データ.</param>
        private void AddButton(ButtonData buttonData)
        {
            var prefab = Resources.Load<CustomButton>("");
            CustomButton button = Instantiate(prefab, _footerButtonsParent);
            button.Initialize(buttonData);
        }

        /// <summary>
        ///     複数ボタンを追加します.
        /// </summary>
        /// <param name="buttonDataList">ボタン設定データリスト.</param>
        private void AddButtons(IReadOnlyList<ButtonData> buttonDataList)
        {
            foreach (ButtonData buttonData in buttonDataList) AddButton(buttonData);
        }

        public struct ViewData
        {
            public string Title { get; set; }
            public string Body { get; set; }

            public IReadOnlyList<ButtonData> FooterButtonDataList { get; set; }
        }
    }
}
