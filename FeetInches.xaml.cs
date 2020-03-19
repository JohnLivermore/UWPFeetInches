using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPFeetInches
{
    public sealed partial class FeetInches : UserControl
    {
        public FeetInches()
        {
            this.InitializeComponent();
        }

        #region Feet
        public int Feet
        {
            get { return (int)GetValue(FeetProperty); }
            set
            {
                SetValue(FeetProperty, value);
            }
        }

        public static readonly DependencyProperty FeetProperty = DependencyProperty.Register(nameof(Feet), typeof(int), typeof(FeetInches), new PropertyMetadata(0, OnPropertyChanged));
        #endregion

        #region Inches
        public decimal Inches
        {
            get { return (decimal)GetValue(InchesProperty); }
            set
            {
                SetValue(InchesProperty, value);
            }
        }

        public static readonly DependencyProperty InchesProperty = DependencyProperty.Register(nameof(Inches), typeof(decimal), typeof(FeetInches), new PropertyMetadata(0M, OnPropertyChanged));
        #endregion

        #region Value
        public decimal? Value
        {
            get { return (decimal)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value), typeof(decimal?), typeof(FeetInches), new PropertyMetadata(null, ValueOnPropertyChanged));
        #endregion

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as FeetInches;
            control.Value = control.Feet * 12 + control.Inches;
        }

        private static void ValueOnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as FeetInches;
            var inches = control.Value;
            control.Feet = inches.HasValue ? (int)(inches.Value / 12M) : 0;
            control.Inches = inches.HasValue ? inches.Value - (control.Feet * 12M) : 0M;
        }
    }
}
