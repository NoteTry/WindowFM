using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WindowFM.Shared.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Public Methods
        public string MainDiskName { get; set; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion
        
        #region Constructor
        public MainViewModel()
        {
            MainDiskName = Environment.SystemDirectory;
        }
        #endregion

        #region Protected Methods
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}