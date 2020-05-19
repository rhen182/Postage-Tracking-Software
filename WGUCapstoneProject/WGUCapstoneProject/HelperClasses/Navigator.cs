using System.Linq;
using System.Windows;
using WGUCapstoneProject.AppViews;

namespace WGUCapstoneProject.Models
{
    public class Navigator
    {
        public static void StartupWindow(Window startupWindow)
        {
            startupWindow.Show();
        }
        public static void NavigateToWindow(Window destinationWindow)
        {
            GetCurrentWindow().Close();
            destinationWindow.Show();
        }
        public static Window GetCurrentWindow()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            return currentWindow;
        }
    }
}