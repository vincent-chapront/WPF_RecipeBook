using CH07_02.RoutedCommandsV2.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace CH07_02.RoutedCommandsV2
{
    public class ImageData : INotifyPropertyChanged
    {
        private string imagePath;
        private double zoom = 1.0;

        public ImageData()
        {
            OpenImageFileCommand = new OpenImageFileCommand(this);
            ZoomCommand = new ZoomCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        public ICommand OpenImageFileCommand { get; }

        public double Zoom
        {
            get
            {
                return zoom;
            }
            set
            {
                zoom = value;
                OnPropertyChanged(nameof(Zoom));
            }
        }

        public ICommand ZoomCommand { get; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var pc = PropertyChanged;
            if (pc != null)
            {
                pc(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}