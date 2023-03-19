using System.Windows.Input;

namespace CH07_01.RoutedCommands
{
    public static class Commands
    {
        private static readonly RoutedUICommand _zoomNormalCommand =
            new RoutedUICommand("Zoom Normal", "Normal", typeof(Commands));

        public static RoutedUICommand ZoomNormalCommand
        {
            get { return _zoomNormalCommand; }
        }
    }
}