using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WindowFM.Shared.ViewModels
{
    public class DirectoryTabItemViewModel : BaseViewModel
    {
        #region Public Methods
        public string FilePath { get; set; }

        public string Name { get; set; }

        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; }
            = new ObservableCollection<FileEntityViewModel>();

        public FileEntityViewModel SelectedFileEntity { get; set; }

        #endregion

        #region Commands

        public ICommand OpenCommand { get; }

        public ICommand CloseCommand { get; }
        #endregion

        #region Events

        public event EventHandler Closed;

        #endregion

        #region Constructor
        public DirectoryTabItemViewModel()
        {
            Name = "Этот компьютер";

            OpenCommand = new DelegateCommand(Open);
            CloseCommand = new DelegateCommand(OnClose);

            foreach (var logicDrives in Directory.GetLogicalDrives())
                DirectoriesAndFiles.Add(new DirectoryViewModel(logicDrives));
        }
        #endregion

        #region Commands Meethod

        private void OnClose(object ob)
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }

        private void Open(object parameter)
        {
            if (parameter is DirectoryViewModel directoryViewModel)
            {
                FilePath = directoryViewModel.FullName;
                Name = directoryViewModel.Name;
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
