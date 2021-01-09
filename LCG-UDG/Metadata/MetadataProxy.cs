using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Rappen.XTB.LCG
{
    public class MetadataProxy: INotifyPropertyChanged
    {
        protected bool IsVisible;

        public event PropertyChangedEventHandler PropertyChanged;

        [Browsable(false)]
        public bool IsSelected { get; private set; }

        public virtual void SetSelected(bool value)
        {
            if (IsSelected != value)
            {
                IsSelected = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal static string StringToCSharpIdentifier(string name)
        {
            name = name
                .Replace(" ", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace(".", "")
                .Replace(",", "")
                .Replace(";", "")
                .Replace(":", "")
                .Replace("'", "")
                .Replace("*", "")
                .Replace("&", "")
                .Replace("%", "")
                .Replace("-", "_")
                .Replace("+", "_")
                .Replace("/", "_")
                .Replace("\\", "_")
                .Replace("[", "_")
                .Replace("]", "_");
            return UnicodeCharacterUtilities.MakeValidIdentifier(name);
        }
    }
}