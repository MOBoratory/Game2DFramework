using Cysharp.Threading.Tasks;

namespace MOB.Framework.Game2D.UI
{
    public static class DialogManager
    {
        public static UniTask<DialogResponse> ShowDialogAsync()
        {
            return UniTask.FromResult(new DialogResponse());
        }
    }
}
