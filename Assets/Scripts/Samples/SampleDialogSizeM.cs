using System.Collections.Generic;
using MOB.Framework.Game2D.UI;

namespace MOB.Framework.Game2D.Samples
{
    /// <summary>
    ///     サンプルダイアログ.
    /// </summary>
    public sealed class SampleDialogSizeM : DialogBase<SampleDialogSizeM.InitializeData>
    {
        public struct InitializeData
        {
            public string Title { get; set; }
            public string Body { get; set; }

            public IReadOnlyList<ButtonData> FooterButtonDataList { get; set; }
        }

        public override void Initialize(InitializeData initializeData)
        {
            AddButtons(initializeData.FooterButtonDataList);
        }
    }
}
