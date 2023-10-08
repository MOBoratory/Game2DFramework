using MOB.Framework.Game2D.Constants;

namespace MOB.Framework.Game2D.UI
{
    public struct ButtonData
    {
        public ButtonSizes ButtonSize { get; }
        public string Text { get; }

        public ButtonData(string text, ButtonSizes buttonSize)
        {
            Text = text;
            ButtonSize = buttonSize;
        }

        public static ButtonData CreateOK(ButtonSizes buttonSize)
        {
            return new ButtonData("OK", buttonSize);
        }

        public static ButtonData CreateClose(ButtonSizes buttonSize)
        {
            return new ButtonData("閉じる", buttonSize);
        }
    }
}
