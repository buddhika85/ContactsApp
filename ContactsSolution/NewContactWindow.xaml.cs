using ContactsSolution.Classes;
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

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void SaveBtn_OnClick(object sender, RoutedEventArgs e)
        {
            // To Do: save contact
            Contact contact = new()
            {
                Name = NameTxtBox.Text,
                Email = EmailTxtBox.Text,
                Phone = PhoneTxtBox.Text,
            };

            DataAccess.InsertContact(contact);

            Close();        // Close this instance of window
        }
    }
}
