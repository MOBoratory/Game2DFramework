using System.Collections.Generic;
using MOB.Framework.Game2D.UI;

namespace MOB.Framework.Game2D.Samples
{
    public sealed class SampleDialog : DialogBase<SampleDialog.ViewData>, IDialog<SampleDialog.ViewData>
    {
        public struct ViewData
        {
            public string Title { get; set; }
            public string Body { get; set; }

            public IReadOnlyList<ButtonData> FooterButtonDataList { get; set; }
        }

        public override void Initialize(ViewData viewData)
        {
            AddButtons(viewData.FooterButtonDataList);
        }
    }
}
