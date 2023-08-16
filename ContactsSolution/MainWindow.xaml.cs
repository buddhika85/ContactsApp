using ContactsSolution.Classes;
using SQLite;
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

            ReadContacts();
        }


        private void NewContactBtn_OnClick(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new();

            // will allow to activate previous window back and forth
            //newContactWindow.Show();    

            // now NewContactWindow is opened and active,
            // you cannot activate Main window/previous window until you close NewContactWindow
            newContactWindow.ShowDialog();

            ReadContacts();
        }



        private void ReadContacts()
        {
            using SQLiteConnection connection = new(App.DatabasePath);
            connection.CreateTable<Contact>();      //if table already exists, it will not do anything (no re creation)
            var contacts = connection.Table<Contact>().ToList();
        }
    }
}
