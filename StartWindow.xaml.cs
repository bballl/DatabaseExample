using System.Windows;

namespace DatabaseExampleEFCore
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();

            FillDatabase.Fill();
            new Handler().WindowInit(WindowType.MainWindow);
            this.Close();
        }
    }
}
