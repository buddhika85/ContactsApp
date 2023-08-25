using ContactsSolution.Classes;
using System.Windows;
using System.Windows.Controls;

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
            RefreshListView();
        }

        private void RefreshListView() => ContactsListView.ItemsSource = DataAccess.ReadContacts();


        private void NewContactBtn_OnClick(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new();

            // will allow to activate previous window back and forth
            //newContactWindow.Show();    

            // now NewContactWindow is opened and active,
            // you cannot activate Main window/previous window until you close NewContactWindow
            newContactWindow.ShowDialog();

            RefreshListView();
        }


        private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = (sender as TextBox)?.Text;
            if (string.IsNullOrWhiteSpace(searchText))
            {
                RefreshListView();
                return;
            }

            ContactsListView.ItemsSource = DataAccess.FilterContacts(searchText);
        }


        private void ContactsListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ContactsListView.SelectedItem as Contact;
            if (selected == null)
                return;
            new ContactDetailsWindow(selected).ShowDialog();
        }
    }
}
