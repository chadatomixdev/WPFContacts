using DesktopContactsApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;

        public MainWindow()
        {
            contacts = new List<Contact>();
            InitializeComponent();
            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();
            ReadDatabase();
        }

        void ReadDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().ToList().OrderBy(c => c.Name).ToList();
            }

            if (contacts != null)
            {
                listviewContacts.ItemsSource = contacts;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            //var filteredList2 = (from contact in contacts
            //                     where contact.Name.ToLower().Contains(searchTextBox.Text.ToLower())
            //                     orderby contact.Name
            //                     select contact).ToList();

            listviewContacts.ItemsSource = filteredList;
        }

        private void listviewContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = listviewContacts.SelectedItem as Contact;

            if (selectedContact != null)
            {
                DetailsContactWindow detailsContactWindow = new DetailsContactWindow(selectedContact);
                detailsContactWindow.ShowDialog();
            }
        }
    }
}