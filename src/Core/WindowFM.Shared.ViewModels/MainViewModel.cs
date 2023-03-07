using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;

namespace WindowFM.Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Public Methods
        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; } =
            new ObservableCollection<DirectoryTabItemViewModel>();

        public DirectoryTabItemViewModel CurrntDirectoryTabItem { get; set; }

        #endregion

        #region Commands

        public DelegateCommand AddTabItemCommand { get; }

        public DelegateCommand CloseCommand { get; }

        #endregion

        #region Constructor
        public MainViewModel()
        {
            AddTabItemCommand = new DelegateCommand(OnAdd);
            CloseCommand = new DelegateCommand(OnClose);

            AddTabItemViewModel();

            CurrntDirectoryTabItem = DirectoryTabItems.FirstOrDefault();   
        }
        #endregion

        #region Public Methods
        public void AppClosing()
        {
            
        }
        #endregion

        #region Private Methods

        private void OnClose(object ob)
        {
            if (ob is DirectoryTabItemViewModel directoryTabItemViewModel)
            {
                CloseTab(directoryTabItemViewModel);
            }
        }

        private void OnAdd(object obj)
        {
            AddTabItemViewModel();
        }

        private void AddTabItemViewModel()
        {
            var vm = new DirectoryTabItemViewModel();
            
            DirectoryTabItems.Add(vm);
            CurrntDirectoryTabItem = vm;
        }

        private void CloseTab(DirectoryTabItemViewModel directoryTabItemViewModel)
        {
            
            DirectoryTabItems.Remove(directoryTabItemViewModel);
            CurrntDirectoryTabItem = DirectoryTabItems.FirstOrDefault();
        }
        #endregion
    }
}