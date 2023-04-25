using System;
using System.Windows;

namespace DatabaseExampleEFCore
{
    /// <summary>
    /// Логика взаимодействия для WindowAddClient.xaml
    /// </summary>
    public partial class WindowAddClient : Window
    {
        private Handler handler;
        public WindowAddClient(Handler handler)
        {
            InitializeComponent();
            this.handler = handler;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbLastName.Text == String.Empty || tbFirstName.Text == String.Empty ||
                tbMiddleName.Text == String.Empty || tbEmail.Text == String.Empty)
            {
                MessageBox.Show("Ошибка. \nНе все обязательные поля заполнены.");
                return;
            }

            Client client = new Client()
            {
                LastName = tbLastName.Text,
                FirstName = tbFirstName.Text,
                MiddleName = tbMiddleName.Text,
                Phone = tbPhoneNumber.Text,
                Email = tbEmail.Text
            };

            handler.AddClient(client);

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
