using ContactsSolution.Classes;
using System.Windows;

namespace ContactsSolution
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        private readonly Contact _contact;
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            _contact = contact;
            PopulateForm();
        }

        private void PopulateForm()
        {
            NameTxtBox.Text = _contact.Name;
            PhoneTxtBox.Text = _contact.Phone;
            EmailTxtBox.Text = _contact.Email;
        }

        private void UpdateBtn_OnClick(object sender, RoutedEventArgs e)
        {
            _contact.Name = NameTxtBox.Text;
            _contact.Phone = PhoneTxtBox.Text;
            _contact.Email = EmailTxtBox.Text;
            DataAccess.UpdateContact(_contact);
            Close();
        }

        private void DeleteBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DataAccess.DeleteContact(_contact);
            Close();
        }
    }
}
