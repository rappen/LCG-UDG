using System;
using System.Drawing;

namespace Rappen.XTB.LCG
{
    public class EntityGroup
    {
        public string Name = "Group";
        internal Color Color = Color.White;

        public int ColorAsArgb
        {
            get => Color == null ? Color.White.ToArgb() : Color.ToArgb();
            set => Color = Color.FromArgb(value);
        }

        public string ColorToString =>
            Color == null || Color == Color.White || (Color.R == 255 && Color.G == 255 && Color.B == 255) ? "" :
            Color.IsNamedColor ? Color.Name :
            Color.IsKnownColor ? Color.ToKnownColor().ToString() :
            $"{Color.R:X2}{Color.G:X2}{Color.B:X2}";

        public override string ToString() => Name;
    }
}