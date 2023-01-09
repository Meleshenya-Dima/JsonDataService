using Service.ApplicationViewModel;
using System.Windows;

namespace Service
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new ViewModel();
            InitializeComponent();
        }
    }
}
