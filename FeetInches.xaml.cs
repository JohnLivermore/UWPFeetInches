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
            set { SetValue(FeetProperty, value); }
        }

        public static readonly DependencyProperty FeetProperty = DependencyProperty.Register(nameof(Feet), typeof(int), typeof(FeetInches), new PropertyMetadata(0, OnPropertyChanged));
        #endregion

        #region Inches
        public decimal Inches
        {
            get { return (decimal)GetValue(InchesProperty); }
            set { SetValue(InchesProperty, value); }
        }

        public static readonly DependencyProperty InchesProperty = DependencyProperty.Register(nameof(Inches), typeof(decimal), typeof(FeetInches), new PropertyMetadata(0M, OnPropertyChanged));
        #endregion

        #region Value
        public decimal? Value
        {
            get
            {
                return Feet * 12 + Inches;
            }
            set
            {
                Feet = value.HasValue ? (int)(value.Value / 12M) : 0;
                Inches = value.HasValue ? value.Value - (Feet * 12M) : 0M;
            }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value), typeof(int), typeof(FeetInches), new PropertyMetadata(null));
        #endregion

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}
