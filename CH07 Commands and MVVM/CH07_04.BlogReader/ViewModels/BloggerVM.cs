using CH07_03.CookbookMVVM;
using CH07_04.BlogReader.Models;
using System;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CH07_04.BlogReader.ViewModels
{
    internal class BloggerVM : ViewModelBase<Blogger>
    {
        private ICommand? _sendEmailCommand;

        public ImageSource Picture
        {
            get
            {
                if (Model.Picture == null)
                {
                    return new BitmapImage(new Uri("/Images/blogger.jpg", UriKind.Relative));
                }

                var bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = Model.Picture;
                bmp.EndInit();
                return bmp;
            }
        }

        public ICommand SendEmailCommand
        {
            get
            {
                return _sendEmailCommand ??= new RelayCommand<string>(email => Process.Start("mailto:" + email));
            }
        }
    }
}