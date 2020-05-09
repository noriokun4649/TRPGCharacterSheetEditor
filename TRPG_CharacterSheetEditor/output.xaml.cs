using System.Windows;

namespace TRPG_PointCalculation
{
    /// <summary>
    /// output.xaml の相互作用ロジック
    /// </summary>
    public partial class Output : Window
    {
        public Output()
        {
            InitializeComponent();
        }
        public void SetText(string text)
        {
            output_text.Text = text;
        }
    }
}
