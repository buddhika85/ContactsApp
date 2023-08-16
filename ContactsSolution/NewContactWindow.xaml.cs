using ContactsSolution.Classes;
using SQLite;
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
            Contact contact = new()
            {
                Name = NameTxtBox.Text,
                Email = EmailTxtBox.Text,
                Phone = PhoneTxtBox.Text,
            };

            using (SQLiteConnection connection = new(App.DatabasePath))     // connection is deposed when it leaves the using block
            {
                connection.CreateTable<Contact>();      //if table already exists, it will not do anything (no re creation)
                connection.Insert(contact);
            }

            Close();        // Close this instance of window
        }
    }
}
