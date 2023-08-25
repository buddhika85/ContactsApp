using ContactsSolution.Classes;
using System.Windows;

namespace ContactsSolution
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        public readonly Contact _contact;
        public ContactDetailsWindow(Contact contact)
        {
            _contact = contact;
            InitializeComponent();
        }

        private void UpdateBtn_OnClick(object sender, RoutedEventArgs e)
        {
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
