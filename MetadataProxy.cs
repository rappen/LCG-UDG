using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Rappen.XTB.LCG
{
    public class MetadataProxy: INotifyPropertyChanged
    {
        private bool selected;

        protected bool IsVisible;

        public event PropertyChangedEventHandler PropertyChanged;

        [Browsable(false)]
        public bool IsSelected { get => selected; }

        public virtual void SetSelected(bool value)
        {
            if (selected != value)
            {
                selected = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}