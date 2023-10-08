using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MOB.Framework.Game2D.UI;
using UnityEngine;

namespace MOB.Framework.Game2D.Samples
{
    public sealed class SampleDialog : DialogBase<SampleDialog.ViewData>
    {
        public sealed class ViewData
        {
            public string Title { get; set; }
            public string Body { get; set; }

            public IReadOnlyList<ButtonData> FooterButtonDataList { get; set; }
        }

        public override void Initialize(ViewData viewData)
        {
            AddButtons(viewData.FooterButtonDataList);
        }

        public override UniTask Open()
        {
            throw new System.NotImplementedException();
        }

        public override UniTask Close()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// ボタンを追加します.
        /// </summary>
        /// <param name="buttonData">ボタン設定データ.</param>
        private void AddButton(ButtonData buttonData)
        {
            var prefab = Resources.Load<CustomButton>("");
            var button = Instantiate(prefab, _footerButtonsParent);
            button.Initialize(buttonData);
        }

        /// <summary>
        /// 複数ボタンを追加します.
        /// </summary>
        /// <param name="buttonDataList">ボタン設定データリスト.</param>
        private void AddButtons(IReadOnlyList<ButtonData> buttonDataList)
        {
            foreach (var buttonData in buttonDataList)
            {
                AddButton(buttonData);
            }
        }
    }
}
