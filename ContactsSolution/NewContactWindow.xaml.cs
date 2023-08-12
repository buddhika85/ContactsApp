using System.Windows;

namespace ContactsSolution
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void SaveBtn_OnClick(object sender, RoutedEventArgs e)
        {
            // To Do: save contact

            Close();        // Close this instance of window
        }
    }
}
