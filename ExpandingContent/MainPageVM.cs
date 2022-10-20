using System;
using System.Windows.Input;

namespace ExpandingContent
{
    public class MainPageVM : BindableBase
    {
        public ICommand ChangeHeightOfBoxViewCmd { get; set; }

        private double _boxHeight = 200d;
        public double BoxHeight
        {
            get => _boxHeight;
            set => SetProperty(ref _boxHeight, value);
        }

        public MainPageVM()
        {
            ChangeHeightOfBoxViewCmd = new Command(() =>
            {
                BoxHeight = BoxHeight >= 200d ? 30d : 200d;
                System.Diagnostics.Debug.WriteLine($"Height of box changed to {BoxHeight}");
            });
        }
    }
}

