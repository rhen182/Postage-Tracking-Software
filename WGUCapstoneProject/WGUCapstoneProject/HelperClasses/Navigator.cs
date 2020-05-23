using System.Linq;
using System.Windows;
using WGUCapstoneProject.AppViews;

namespace WGUCapstoneProject.Models
{
    public class Navigator
    {
        /// <summary>
        /// Shows a window. Used to show the startup window in App.xaml
        /// </summary>
        public static void ShowWindow(Window selectedWindow)
        {
            selectedWindow.Show();
        }

        /// <summary>
        /// Navigates from the current window to a requested destination window
        /// </summary>
        public static void NavigateToWindow(Window destinationWindow)
        {
            GetCurrentWindow().Close();
            destinationWindow.Show();
        }

        /// <summary>
        /// Returns the current Window object
        /// </summary>
        public static Window GetCurrentWindow()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            return currentWindow;
        }
    }
}