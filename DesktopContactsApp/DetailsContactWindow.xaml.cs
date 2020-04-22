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
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for DetailsContactWindow.xaml
    /// </summary>
    public partial class DetailsContactWindow : Window
    {
         Contact contact { get; set; }
        public DetailsContactWindow(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;
            textboxName.Text = contact.Name;
            textboxEmail.Text = contact.Email;
            textboxPhoneNumber.Text = contact.PhoneNumber;
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = textboxName.Text;
            contact.Email = textboxEmail.Text;
            contact.PhoneNumber = textboxPhoneNumber.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }

            Close();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }

            Close();
        }
    }
}