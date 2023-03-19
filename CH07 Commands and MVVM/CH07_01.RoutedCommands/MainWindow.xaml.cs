using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;

namespace CH07_01.RoutedCommands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageData _image;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnIsImageExist(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _image != null;
        }

        private void OnOpen(object sender, ExecutedRoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.png"
            };
            if (dlg.ShowDialog() == true)
            {
                _image = new ImageData(dlg.FileName);
                DataContext = _image;
            }
        }

        private void OnZoomIn(object s, ExecutedRoutedEventArgs e)
        {
            _image.Zoom *= 1.2;
        }

        private void OnZoomNormal(object s, ExecutedRoutedEventArgs e)
        {
            _image.Zoom = 1.0;
        }

        private void OnZoomOut(object s, ExecutedRoutedEventArgs e)
        {
            _image.Zoom /= 1.2;
        }
    }
}