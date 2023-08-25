using ContactsSolution.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ContactsSolution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Contact> _contacts;

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
            {
                connection.CreateTable<Contact>();      //if table already exists, it will not do anything (no re creation)
                _contacts = (connection.Table<Contact>().ToList()).OrderBy(x => x.Name).ToList();
            }
            ContactsListView.ItemsSource = _contacts;
        }

        private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = (sender as TextBox)?.Text;
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ContactsListView.ItemsSource = _contacts;
                return;
            }
            //ContactsListView.ItemsSource = _contacts.Where(x => Filter(x, text)).ToList();
            ContactsListView.ItemsSource = (from contact in _contacts
                                            where
                                                contact.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                                                contact.Email.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                                                contact.Phone.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                                            select contact).ToList();
        }

        private bool Filter(Contact? contact, string searchText)
        {
            if (contact == null) return false;

            return !string.IsNullOrWhiteSpace(contact.Name) && contact.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                   !string.IsNullOrWhiteSpace(contact.Phone) && contact.Phone.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                   !string.IsNullOrWhiteSpace(contact.Email) && contact.Email.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }
    }
}
