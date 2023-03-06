namespace WindowFM.Shared.ViewModels
{
    public sealed class FileViewModel : FileEntityViewModel
    {
        public FileViewModel(string fileName) : base(fileName)
        {
        }

        public FileViewModel(FileInfo fileName) : base(fileName.Name)
        {
            FullName = fileName.FullName;
        }
    }
}
