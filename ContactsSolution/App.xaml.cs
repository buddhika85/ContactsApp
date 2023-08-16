using System;
using System.Windows;

namespace ContactsSolution
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // SqLite Db configurations
        public const string DbName = "Contacts.db";
        public static string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string DatabasePath = System.IO.Path.Combine(FolderPath, DbName);
    }
}
