using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace MOB.Framework.Game2D.UI
{
    /// <summary>
    ///     ダイアログ結果.
    /// </summary>
    public struct DialogResult
    {
        public object Value { get; set; }

        public DialogButtonType? ButtonType { get; set; }
    }

    /// <summary>
    ///     ダイアログボタン種別.
    /// </summary>
    public enum DialogButtonType
    {
        /// <summary>
        ///     肯定ボタン.
        ///     NOTE: OKボタン等.
        /// </summary>
        Positive = 0,

        /// <summary>
        ///     否定ボタン.
        ///     NOTE: Cancelボタン等.
        /// </summary>
        Negative = 1,

        /// <summary>
        ///     その他のボタン.
        ///     NOTE: 閉じるボタン、要素選択ボタン等.
        /// </summary>
        Other1 = 999
    }

    /// <summary>
    ///     ダイアログ基底.
    ///     TODO: コード以外からのボタン作成対応.
    /// </summary>
    public abstract class DialogBase<TInitializeData> : MonoBehaviour, IDialog<TInitializeData>
        where TInitializeData : struct
    {
        /// <summary>
        ///     ダイアログの結果を待機するオブジェクト.
        /// </summary>
        private readonly UniTaskCompletionSource<DialogResult> _dialogResultAwaiter = new();

        /// <summary>
        ///     黒幕部分のタップ範囲ボタン.
        /// </summary>
        [SerializeField]
        protected CustomButton _modalTapAreaButton;

        [SerializeField]
        protected RectTransform _layout;

        [SerializeField]
        protected RectTransform _footerButtonsParent;

        [SerializeField]
        private float _openAnimationDuration = 0.4f;

        /// <summary>
        ///     初期化を行います.
        /// </summary>
        /// <param name="initializeData">初期化用データ.</param>
        public abstract void Initialize(TInitializeData initializeData);

        public void InitializeCore()
        {
            _modalTapAreaButton
                .OnClickAsObservable()
                .Subscribe(_ => CloseAsync().Forget())
                .AddTo(this);
        }

        /// <summary>
        ///     表示します.
        /// </summary>
        /// <param name="ct">キャンセルトークン.</param>
        /// <returns>ダイアログ結果.</returns>
        public async UniTask<DialogResult> ShowAsync(CancellationToken ct = default)
        {
            await OpenAsync(ct);

            // 結果を待機.
            DialogResult result = await _dialogResultAwaiter.Task.AttachExternalCancellation(ct);

            await CloseAsync(ct);

            return result;
        }

        /// <summary>
        ///     ダイアログを閉じます.
        /// </summary>
        /// <param name="ct">キャンセルトークン.</param>
        /// <returns>Close完了.</returns>
        public async UniTask CloseAsync(CancellationToken ct = default)
        {
            if (_layout.localScale == Vector3.zero)
            {
                // 既に閉じている場合は即結果を返す.
                return;
            }

            await _layout
                .DOScale(Vector3.zero, _openAnimationDuration)
                .ToUniTask(cancellationToken: ct);

            Destroy(gameObject);
        }

        /// <summary>
        ///     ダイアログを開きます.
        /// </summary>
        /// <param name="ct">キャンセルトークン.</param>
        /// <returns>Open完了.</returns>
        public UniTask OpenAsync(CancellationToken ct = default)
        {
            // アニメーション準備.
            _layout.localScale = Vector3.zero;

            return _layout
                .DOScale(Vector3.one, _openAnimationDuration)
                .ToUniTask(cancellationToken: ct);
        }

        /// <summary>
        ///     ボタンを追加します.
        /// </summary>
        /// <param name="buttonData">ボタン設定データ.</param>
        protected void AddButton(ButtonData buttonData)
        {
            var prefab = Resources.Load<CustomButton>("");
            CustomButton button = Instantiate(prefab, _footerButtonsParent);
            button.Initialize(buttonData);
        }

        /// <summary>
        ///     複数ボタンを追加します.
        /// </summary>
        /// <param name="buttonDataList">ボタン設定データリスト.</param>
        protected void AddButtons(IReadOnlyList<ButtonData> buttonDataList)
        {
            if (buttonDataList == null)
            {
                Debug.LogWarning($"{nameof(buttonDataList)}がNull.");
                return;
            }

            foreach (ButtonData buttonData in buttonDataList) AddButton(buttonData);
        }

        /// <summary>
        ///     結果をセットします.
        /// </summary>
        protected void SetResult(DialogResult dialogResult)
        {
            _dialogResultAwaiter?.TrySetResult(dialogResult);
        }
    }
}
