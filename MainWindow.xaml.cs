using System.ComponentModel;
using System.Windows;

namespace DatabaseExampleEFCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Handler handler;

        public MainWindow(BindingList<Client> listClients, Handler handler)
        {
            InitializeComponent();

            this.handler = handler;
            listClientDataView.ItemsSource = listClients;
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            var selectedData = (Client)listClientDataView.SelectedItem;

            if (selectedData == null)
                return;

            handler.WindowInit(WindowType.WindowClientData, selectedData);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedData = (Client)listClientDataView.SelectedItem;

            if (selectedData == null)
                return;

            handler.DeleteClientData(selectedData);
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            handler.WindowInit(WindowType.WindowAddClient);
        }

        private void btnPurchases_Click(object sender, RoutedEventArgs e)
        {
            handler.WindowInit(WindowType.WindowAllPurchases);
        }
    }
}
