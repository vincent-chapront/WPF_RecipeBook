using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;

namespace CH07_02.RoutedCommandsV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ImageData();
        }
    }
}