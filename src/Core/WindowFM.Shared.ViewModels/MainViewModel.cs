using System.Collections.ObjectModel;

namespace WindowFM.Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Public Methods
        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; } =
            new ObservableCollection<DirectoryTabItemViewModel>();

        public DirectoryTabItemViewModel CurrntDirectoryTabItem { get; set; }

        #endregion
        public DelegateCommand AddTabItemCommand { get; }
        #region Commands

        #endregion

        #region Constructor
        public MainViewModel()
        {
            AddTabItemCommand = new DelegateCommand(OnAdd);

            AddTabItemViewModel();

            CurrntDirectoryTabItem = DirectoryTabItems.FirstOrDefault();   
        }
        #endregion

        #region Private Methods

        private void OnAdd(object obj)
        {
            AddTabItemViewModel();
        }

        private void AddTabItemViewModel()
        {
            var vm = new DirectoryTabItemViewModel();
            vm.Closed += Vm_Clossed;
            DirectoryTabItems.Add(vm);
            CurrntDirectoryTabItem = vm;
        }

        private void Vm_Clossed(object? sender, EventArgs e)
        {
            if (sender is DirectoryTabItemViewModel directoryTabItemViewModel)
            {
                CloseTab(directoryTabItemViewModel);
            }
        }

        private void CloseTab(DirectoryTabItemViewModel directoryTabItemViewModel)
        {
            directoryTabItemViewModel.Closed -= Vm_Clossed;
            DirectoryTabItems.Remove(directoryTabItemViewModel);
            CurrntDirectoryTabItem = DirectoryTabItems.FirstOrDefault();
        }
        #endregion
    }
}