using ContactsSolution.Classes;
using SQLite;
using System.Collections.Generic;
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
            List<Contact> contacts;
            using SQLiteConnection connection = new(App.DatabasePath);
            {
                connection.CreateTable<Contact>();      //if table already exists, it will not do anything (no re creation)
                contacts = connection.Table<Contact>().ToList();
            }


            if (contacts != null)
            {
                //contacts.ForEach(x =>
                //{
                //    ContactsListView.Items.Add(new ListViewItem { Content = x });
                //});
                ContactsListView.ItemsSource = contacts;
            }
        }
    }
}
