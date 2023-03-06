using System.Windows;
using WindowFM.Shared.ViewModels;

namespace WindowFM.WPF.UI
{
    public partial class MainWindow
    {
        private readonly MainViewModel _mainVm;

        public MainWindow()
        {
            InitializeComponent();

            _mainVm = new MainViewModel();

            DataContext = _mainVm;
        }

        private void CloseButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _mainVm.AppClosing();
            Application.Current.Shutdown();
        }

        private void ExpandButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
            if (WindowState == WindowState.Maximized) 
                WindowState = WindowState.Normal;
        }

        private void CollapseButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
