using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MOB.Framework.Game2D.UI
{
    /// <summary>
    /// ダイアログ基底.
    /// </summary>
    public abstract class DialogBase<TViewData> : MonoBehaviour
    {
        [SerializeField]
        protected RectTransform _footerButtonsParent;
        
        public abstract void Initialize(TViewData viewData);
        public abstract UniTask Open();
        public abstract UniTask Close();

        /// <summary>
        /// ボタンを追加します.
        /// </summary>
        /// <param name="buttonData">ボタン設定データ.</param>
        protected void AddButton(ButtonData buttonData)
        {
            CreateButtonPrivate(buttonData, _footerButtonsParent);
        }

        /// <summary>
        /// 複数ボタンを追加します.
        /// </summary>
        /// <param name="buttonDataList">ボタン設定データリスト.</param>
        protected void AddButtons(IReadOnlyList<ButtonData> buttonDataList)
        {
            foreach (var buttonData in buttonDataList)
            {
                CreateButtonPrivate(buttonData, _footerButtonsParent);
            }
        }

        private CustomButton CreateButtonPrivate(ButtonData buttonData, RectTransform parent)
        {
            var prefab = Resources.Load<CustomButton>("");
            var button = Instantiate(prefab, parent);
            button.Initialize(buttonData);

            return button;
        }
    }
}
