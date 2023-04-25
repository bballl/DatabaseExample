using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseExampleEFCore
{
    /// <summary>
    /// Логика взаимодействия для WindowClientData.xaml
    /// </summary>
    public partial class WindowClientData : Window
    {
        private List<TextBox> textBoxesList;
        private Client client;
        private Handler handler;

        public WindowClientData(Client client, Handler handler)
        {
            InitializeComponent();

            this.client = client;
            this.handler = handler;

            tbLastName.Text = client.LastName;
            tbFirstName.Text = client.FirstName;
            tbMiddleName.Text = client.MiddleName;
            tbPhoneNumber.Text = client.Phone;
            tbEmail.Text = client.Email;
            textBlockID.Text = "Уникальный идентификатор: " + client.ClientID.ToString();

            textBoxesList = new List<TextBox>() { tbLastName, tbFirstName, tbMiddleName, tbPhoneNumber, tbEmail };

            listProductDataView.ItemsSource = handler.GetPurchases(client);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            foreach (var element in textBoxesList)
            {
                element.IsReadOnly = false;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (var element in textBoxesList)
            {
                if (element == tbPhoneNumber)
                    continue;

                if (element.Text == String.Empty)
                {
                    MessageBox.Show("Ошибка. \nНе все обязательные поля заполнены.");
                    return;
                }
            }

            Client newDataClient = new Client()
            {
                LastName = tbLastName.Text,
                FirstName = tbFirstName.Text,
                MiddleName = tbMiddleName.Text,
                Phone = tbPhoneNumber.Text,
                Email = tbEmail.Text
            };

            foreach (var element in textBoxesList)
            {
                element.IsReadOnly = true;
            }

            handler.EditClientData(newDataClient, client);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            handler.DeleteClientData(client);
            this.Close();
        }
    }
}
