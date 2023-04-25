using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;

namespace DatabaseExampleEFCore
{
    public class Handler
    {
        private MainWindow mainWindow;
        private StoreDbContext context;
        private BindingList<Client> listClients;

        public Handler()
        {
            context = new StoreDbContext();
        }
        public void WindowInit(WindowType windowType, Client client = null)
        {
            switch (windowType)
            {
                case WindowType.MainWindow:
                    context.Clients.Load();
                    listClients = context.Clients.Local.ToBindingList();
                    mainWindow = new MainWindow(listClients, this);
                    mainWindow.Show();
                    break;

                case WindowType.WindowClientData:
                    new WindowClientData(client, this).Show();
                    break;

                case WindowType.WindowAddClient:
                    new WindowAddClient(this).Show();
                    break;

                case WindowType.WindowAllPurchases:
                    var listProducts = context.Products.ToList(); //другой вариант                                              
                                                                  //context.Products.Load();
                                                                  //var listProducts = context.Products.Local.ToList<Product>();
                    new WindowAllPurchases(listProducts).Show();
                    break;

                default:
                    MessageBox.Show("Неизвестная ошибка.", "Информационное окно", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
        }

        public void DeleteClientData(Client client)
        {
            var clientPurchases = context.Products.Where(e => e.Email == client.Email);
            
            foreach (var item in clientPurchases)
            {
                context.Products.Remove(item);
            }

            context.Clients.Remove(client);

            context.SaveChanges();
        }

        public void EditClientData(Client newData, Client currentData)
        {
            currentData.LastName = newData.LastName;
            currentData.FirstName = newData.FirstName;
            currentData.MiddleName = newData.MiddleName;
            currentData.Email = newData.Email;
            currentData.Phone = newData.Phone;

            context.SaveChanges();

            mainWindow.listClientDataView.Items.Refresh();
        }

        public void AddClient(Client newData)
        {
            Client newClient = new Client()
            {
                LastName = newData.LastName,
                FirstName = newData.FirstName,
                MiddleName = newData.MiddleName,
                Phone = newData.Phone,
                Email = newData.Email,
            };

            context.Clients.Add(newClient);
            context.SaveChanges();
        }

        public List<Product> GetPurchases(Client client)
        {
            var clientPurchases = context.Products.Where(e => e.Email == client.Email).ToList();
            return clientPurchases;
        }
    }
}
