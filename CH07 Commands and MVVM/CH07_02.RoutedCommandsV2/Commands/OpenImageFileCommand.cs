using Microsoft.Win32;
using System;
using System.Windows.Input;

namespace CH07_02.RoutedCommandsV2.Commands
{
    internal class OpenImageFileCommand : ICommand
    {
        private readonly ImageData _data;

        public OpenImageFileCommand(ImageData data)
        {
            _data = data;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.png"
            };
            if (dlg.ShowDialog() == true)
            {
                _data.ImagePath = dlg.FileName;
            }
        }
    }
}