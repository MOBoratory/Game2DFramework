using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
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
        /// <summary> 肯定ボタン. </summary>
        Positive = 0,

        /// <summary> 否定ボタン. </summary>
        Negative = 1,

        /// <summary> その他のボタン. </summary>
        Other1 = 1000,

        /// <summary> その他のボタン. </summary>
        Other2 = 1001,

        /// <summary> その他のボタン. </summary>
        Other3 = 1002
    }

    /// <summary>
    ///     ダイアログ基底.
    ///     TODO: コード以外からのボタン作成対応.
    /// </summary>
    public abstract class DialogBase<TInitializeData> : MonoBehaviour, IDialog<TInitializeData>
        where TInitializeData : struct
    {
        [SerializeField]
        protected RectTransform _footerButtonsParent;

        [SerializeField]
        private float _openAnimationDuration = 0.4f;

        /// <summary>
        ///     ダイアログの結果を待機するオブジェクト.
        /// </summary>
        private readonly UniTaskCompletionSource<DialogResult> _dialogResultAwaiter = new();

        public abstract void Initialize(TInitializeData initializeData);

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
        ///     ダイアログを開きます.
        /// </summary>
        /// <param name="ct">キャンセルトークン.</param>
        /// <returns>Open完了.</returns>
        public UniTask OpenAsync(CancellationToken ct = default)
        {
            var rect = GetComponent<RectTransform>();
            // アニメーション準備.
            rect.localScale = Vector3.zero;

            return rect
                .DOScale(Vector3.one, _openAnimationDuration)
                .ToUniTask(cancellationToken: ct);
        }

        /// <summary>
        ///     ダイアログを閉じます.
        /// </summary>
        /// <param name="ct">キャンセルトークン.</param>
        /// <returns>Close完了.</returns>
        public UniTask CloseAsync(CancellationToken ct = default)
        {
            var rect = GetComponent<RectTransform>();

            if (rect.localScale == Vector3.zero)
            {
                // 既に閉じている場合は即結果を返す.
                return UniTask.CompletedTask;
            }

            return rect
                .DOScale(Vector3.zero, _openAnimationDuration)
                .ToUniTask(cancellationToken: ct);
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
