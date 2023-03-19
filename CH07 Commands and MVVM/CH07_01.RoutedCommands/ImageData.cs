using System.ComponentModel;

namespace CH07_01.RoutedCommands
{
    public class ImageData : INotifyPropertyChanged
    {
        private double zoom = 1.0;

        public ImageData(string path)
        {
            ImagePath = path;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ImagePath { get; private set; }

        public double Zoom
        {
            get
            {
                return zoom;
            }
            set
            {
                zoom = value;
                OnPropertyChanged("Zoom");
            }
        }

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