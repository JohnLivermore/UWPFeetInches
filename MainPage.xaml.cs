using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPFeetInches
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new InchesViewModel();
        }

        public InchesViewModel ViewModel { get; set; }
    }

    public class InchesViewModel : INotifyPropertyChanged
    {
        private decimal? _Inches { get; set; }
        public decimal? Inches
        {
            get { return _Inches; }
            set
            {
                if (value != _Inches)
                {
                    _Inches = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Inches)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
