using Cysharp.Threading.Tasks;
using MOB.Framework.Game2D.UI;
using UniRx;
using UnityEngine;

namespace MOB.Framework.Game2D.Samples
{
    /// <summary>
    ///     サンプルシーン.
    /// </summary>
    public sealed class SampleScene : MonoBehaviour
    {
        [SerializeField]
        private CustomButton _showSampleDialogButton;

        [SerializeField]
        private RectTransform _dialogParent;

        private void Awake()
        {
            _showSampleDialogButton.OnClickAsObservable()
                .Subscribe(async _ =>
                {
                    var dialogResult = DialogManager.ShowDialogAsync<SampleDialog, SampleDialog.InitializeData>(
                        new SampleDialog.InitializeData
                        {
                            Title = string.Empty,
                            Body = string.Empty,
                            FooterButtonDataList = null
                        },
                        _dialogParent,
                        gameObject.GetCancellationTokenOnDestroy()
                    );
                })
                .AddTo(this);
        }
    }
}
