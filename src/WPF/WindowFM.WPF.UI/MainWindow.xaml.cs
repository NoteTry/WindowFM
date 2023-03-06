using WindowFM.Shared.ViewModels;

namespace WindowFM.WPF.UI
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }
    }
}
