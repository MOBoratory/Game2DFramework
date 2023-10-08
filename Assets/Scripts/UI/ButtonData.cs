namespace MOB.Framework.Game2D.UI
{
    public struct ButtonData
    {
        public string Text { get; }

        public ButtonData(string text)
        {
            Text = text;
        }

        public static ButtonData CreateOK()
        {
            return new ButtonData("OK");
        }

        public static ButtonData CreateClose()
        {
            return new ButtonData("閉じる");
        }
    }
}
