using System.Threading;
using Cysharp.Threading.Tasks;

namespace MOB.Framework.Game2D.UI
{
    /// <summary>
    ///     ダイアログ I/F.
    /// </summary>
    /// <typeparam name="TInitializeData">初期化用データ型.</typeparam>
    public interface IDialog<TInitializeData>
        where TInitializeData : struct
    {
        /// <summary>
        ///     初期化を行います.
        /// </summary>
        /// <param name="initializeData">初期化用データ.</param>
        void Initialize(TInitializeData initializeData);

        /// <summary>
        ///     表示します.
        /// </summary>
        /// <param name="ct">キャンセルトークン.</param>
        /// <returns>ダイアログを閉じた結果.</returns>
        UniTask<DialogResult> ShowAsync(CancellationToken ct = default);
    }
}
