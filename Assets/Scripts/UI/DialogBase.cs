using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MOB.Framework.Game2D.UI
{
    /// <summary>
    /// ダイアログ基底.
    /// </summary>
    public abstract class DialogBase<TViewData> : MonoBehaviour
    {
        public abstract void Initialize(TViewData viewData);
        public abstract UniTask Open();
        public abstract UniTask Close();
    }
}
