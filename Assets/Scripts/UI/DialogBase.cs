using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MOB.Framework.Game2D.UI
{
    public struct DialogResponse
    {
        public int Id { get; }
    }
    
    /// <summary>
    /// ダイアログ基底.
    /// TODO: コード以外からのボタン作成対応.
    /// </summary>
    public abstract class DialogBase<TViewData> : MonoBehaviour
    {
        [SerializeField]
        protected RectTransform _footerButtonsParent;
        
        public abstract void Initialize(TViewData viewData);
        public abstract UniTask Open();
        public abstract UniTask Close();
    }
}
