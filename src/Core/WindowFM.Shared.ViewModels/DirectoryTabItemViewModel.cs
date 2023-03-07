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
        #region Private Filds

        private readonly IDirectoryHistory _history;

        #endregion

        #region Public Methods
        public string FilePath { get; set; }

        public string Name { get; set; }

        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; }
            = new ObservableCollection<FileEntityViewModel>();

        public FileEntityViewModel SelectedFileEntity { get; set; }

        #endregion

        #region Commands

        public DelegateCommand OpenCommand { get; }

        public DelegateCommand MoveBackCommand { get; }

        public DelegateCommand MoveForwardCommand { get; }
        #endregion

        #region Constructor
        public DirectoryTabItemViewModel()
        {
            _history = new DirectoryHistory("Этот компьютер", "Этот компьютер");

            OpenCommand = new DelegateCommand(Open);
            MoveBackCommand = new DelegateCommand(OnMoveBack, OnCanMoveBack);
            MoveForwardCommand = new DelegateCommand(OnMoveForward, OnCanMoveForward);

            Name = _history.Current.DirectoryPathName;
            FilePath = _history.Current.DirectoryPath;

            OpenDirectory();

            _history.HistoryChanged += _HistoryChanged;
        }

        #endregion

        #region Commands Method

        private void Open(object parameter)
        {
            if (parameter is DirectoryViewModel directoryViewModel)
            {
                FilePath = directoryViewModel.FullName;
                Name = directoryViewModel.Name;

                _history.Add(FilePath, Name);

                OpenDirectory();
            }
        }

        private bool OnCanMoveBack(object obj) => _history.CanMoveBack;

        private bool OnCanMoveForward(object obj) => _history.CanMoveForward;

        private void OnMoveForward(object obj)
        {
            _history.MoveForward();

            var current = _history.Current;

            FilePath = current.DirectoryPath;
            Name = current.DirectoryPathName;

            OpenDirectory();
        }

        private void OnMoveBack(object obj)
        {
            _history.MoveBack();

            var current = _history.Current;

            FilePath = current.DirectoryPath;
            Name = current.DirectoryPathName;

            OpenDirectory();
        }

        #endregion

        #region Private Methods

        private void _HistoryChanged(object? sender, EventArgs e)
        {
            MoveBackCommand?.RaiseItemChanged();
            MoveForwardCommand?.RaiseItemChanged();
        }

        private void OpenDirectory()
        {
            DirectoriesAndFiles.Clear();

            if (Name == "Этот компьютер")
            {
                foreach (var logicDrives in Directory.GetLogicalDrives())
                    DirectoriesAndFiles.Add(new DirectoryViewModel(logicDrives));

                return;
            }

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

        #endregion
    }
}
