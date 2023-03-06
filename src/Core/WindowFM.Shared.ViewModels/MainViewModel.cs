using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WindowFM.Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Public Methods
        public string FilePath { get; set; }

        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; } 
            = new ObservableCollection<FileEntityViewModel>();

        public FileEntityViewModel SelectedFileEntity { get; set; }
        #endregion

        #region Commands

        public ICommand OpenCommand { get; }

        #endregion

        #region Constructor
        public MainViewModel()
        {
            OpenCommand = new DelegateCommand(Open);

            foreach (var logicDrives in Directory.GetLogicalDrives()) 
                DirectoriesAndFiles.Add(new DirectoryViewModel(logicDrives));
        }
        #endregion

        #region Commands Meethod

        private void Open(object parameter)
        {
            if (parameter is DirectoryViewModel directoryViewModel)
            {
                FilePath = directoryViewModel.FullName;

                DirectoriesAndFiles.Clear();

                var directoryInfo = new DirectoryInfo(FilePath);

                foreach (var directory in directoryInfo.GetDirectories())
                {
                    DirectoriesAndFiles.Add(new DirectoryViewModel(directory));
                }

                foreach (var fileInfo in directoryInfo.GetFiles())
                {
                    DirectoriesAndFiles.Add(new FileViewModel(fileInfo));
                }
            }
        }

        #endregion
    }
}