using MOB.Framework.Game2D.Constants;

namespace MOB.Framework.Game2D.UI
{
    public struct ButtonData
    {
        public int Id { get; }
        public string Text { get; }
        public ButtonSizes Size { get; }
        public ButtonTypes Type { get; }

        public ButtonData(int id, string text, ButtonSizes size, ButtonTypes type)
        {
            Id = id;
            Text = text;
            Size = size;
            Type = type;
        }

        public static ButtonData CreateOK(int id, ButtonSizes size, ButtonTypes type)
        {
            return new ButtonData(id, "OK", size, type);
        }

        public static ButtonData CreateClose(int id, ButtonSizes size, ButtonTypes type)
        {
            return new ButtonData(id, "閉じる", size, type);
        }
    }
}
