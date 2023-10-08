using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MOB.Framework.Game2D.UI;

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
    }
}
