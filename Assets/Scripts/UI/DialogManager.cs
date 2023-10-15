using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MOB.Framework.Game2D.UI
{
    /// <summary>
    ///     ダイアログマネージャ.
    /// </summary>
    public static class DialogManager
    {
        /// <summary>
        ///     Prefabのディレクトリパス.
        /// </summary>
        private static string PrefabDirectoryPath { get; set; }

        /// <summary>
        ///     初期化を行います.
        /// </summary>
        /// <param name="prefabDirectoryPath">プレハブのディレクトリPath.</param>
        public static void Initialize(string prefabDirectoryPath)
        {
            PrefabDirectoryPath = prefabDirectoryPath;
        }

        /// <summary>
        ///     ダイアログを表示します.
        /// </summary>
        /// <param name="prefabPath">DialogのPrefabPath.</param>
        /// <param name="initializeData">初期化用データ.</param>
        /// <param name="parent">生成先となる親.</param>
        /// <typeparam name="TDialog">ダイアログ型.</typeparam>
        /// <typeparam name="TInitializeData">初期化用データ型.</typeparam>
        /// <returns>ダイアログを閉じた応答情報.</returns>
        public static UniTask<DialogResponse> ShowDialogAsync<TDialog, TInitializeData>(
            TInitializeData initializeData,
            Transform parent)
            where TInitializeData : struct
            where TDialog : Object, IDialog<TInitializeData>
        {
            // ダイアログを生成します.
            var prefabPath = Path.Combine(PrefabDirectoryPath, nameof(TDialog));
            var prefab = Resources.Load<TDialog>(prefabPath);
            TDialog dialog = GameObject.Instantiate(prefab, parent);
            // ダイアログを初期化します.
            dialog.Initialize(initializeData);

            return dialog.ShowAsync();
        }
    }
}
