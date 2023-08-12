using System.Windows;

namespace ContactsSolution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewContactBtn_OnClick(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new();

            // will allow to activate previous window back and forth
            //newContactWindow.Show();    

            // now NewContactWindow is opened and active,
            // you cannot activate Main window/previous window until you close NewContactWindow
            newContactWindow.ShowDialog();
        }
    }
}
