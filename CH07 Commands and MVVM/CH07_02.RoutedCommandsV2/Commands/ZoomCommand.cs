using System;
using System.Windows.Input;

namespace CH07_02.RoutedCommandsV2.Commands
{
    internal enum ZoomType
    {
        ZoomIn,
        ZoomOut,
        ZoomNormal
    }

    internal class ZoomCommand : ICommand
    {
        private ImageData _data;

        public ZoomCommand(ImageData data)
        {
            _data = data;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return _data.ImagePath != null;
        }

        public void Execute(object? parameter)
        {
            var zoomType = (ZoomType)Enum.Parse(typeof(ZoomType), (string)parameter, true);
            switch (zoomType)
            {
                case ZoomType.ZoomIn:
                    _data.Zoom *= 1.2;
                    break;

                case ZoomType.ZoomOut:
                    _data.Zoom /= 1.2;
                    break;

                case ZoomType.ZoomNormal:
                    _data.Zoom = 1.0;
                    break;
            }
        }
    }
}