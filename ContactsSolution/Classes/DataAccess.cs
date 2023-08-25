using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsSolution.Classes
{
    public static class DataAccess
    {
        public static List<Contact> ReadContacts()
        {

            using SQLiteConnection connection = new(App.DatabasePath);
            {
                connection.CreateTable<Contact>();      //if table already exists, it will not do anything (no re creation)
                return (connection.Table<Contact>().ToList()).OrderBy(x => x.Name).ToList();
            }
        }

        public static List<Contact> FilterContacts(string searchText)
        {

            //return ReadContacts().Where(x => Filter(x, text)).ToList();
            return (from contact in ReadContacts()
                    where
                    contact.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                    contact.Email.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                    contact.Phone.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                    select contact).ToList();
        }

        public static void InsertContact(Contact contact)
        {
            using SQLiteConnection connection = new(App.DatabasePath);
            connection.CreateTable<Contact>();
            connection.Insert(contact);
        }

        public static void DeleteContact(Contact contact)
        {
            using SQLiteConnection connection = new(App.DatabasePath);
            connection.CreateTable<Contact>();
            connection.Delete(contact);
        }

        public static void UpdateContact(Contact contact)
        {
            using SQLiteConnection connection = new(App.DatabasePath);
            connection.CreateTable<Contact>();
            connection.Update(contact);
        }

        private static bool Filter(Contact? contact, string searchText)
        {
            if (contact == null) return false;

            return !string.IsNullOrWhiteSpace(contact.Name) && contact.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                   !string.IsNullOrWhiteSpace(contact.Phone) && contact.Phone.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                   !string.IsNullOrWhiteSpace(contact.Email) && contact.Email.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }

    }
}
