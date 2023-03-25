using System.Windows;

namespace CH07_04.BlogReader.Views
{
    /// <summary>
    /// Interaction logic for NewCommentWindow.xaml
    /// </summary>
    public partial class NewPostWindow : Window
    {
        public NewPostWindow()
        {
            InitializeComponent();
        }

        private void OnOk(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}