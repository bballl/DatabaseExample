using System.Collections.Generic;
using System.Windows;

namespace DatabaseExampleEFCore
{
    /// <summary>
    /// Логика взаимодействия для WindowAllPurchases.xaml
    /// </summary>
    public partial class WindowAllPurchases : Window
    {
        public WindowAllPurchases(List<Product> products)
        {
            InitializeComponent();
            listProductDataView.ItemsSource = products;
        }
    }
}
