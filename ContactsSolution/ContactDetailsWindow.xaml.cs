﻿using ContactsSolution.Classes;
using System;
using System.Windows;

namespace ContactsSolution
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        private Contact _contact;
        public ContactDetailsWindow(Contact contact)
        {
            _contact = contact;
            InitializeComponent();
        }

        private void UpdateBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}