using ContactsSolution.Classes;
using System.Windows;
using System.Windows.Controls;

namespace ContactsSolution.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {

        public Contact Contact
        {
            get => (Contact)GetValue(ContactProperty);
            set => SetValue(ContactProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register(nameof(Contact), typeof(Contact), typeof(ContactControl),
                new PropertyMetadata(new Contact { Name = "John Doe", Email = "doe@gmail.com", Phone = "(123) 456 789" },
                    SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ContactControl contactControl)
            {
                contactControl.NameTxtBlock.Text = (e.NewValue as Contact)?.Name;
                contactControl.EmailTxtBlock.Text = (e.NewValue as Contact)?.Email;
                contactControl.PhoneTxtBlock.Text = (e.NewValue as Contact)?.Phone;
            }
        }


        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
