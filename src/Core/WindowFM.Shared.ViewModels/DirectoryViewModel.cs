namespace WindowFM.Shared.ViewModels
{
    public sealed class DirectoryViewModel : FileEntityViewModel
    {
        public DirectoryViewModel(string name) : base(name)
        {
            FullName = name;
        }

        public DirectoryViewModel(DirectoryInfo directoryName) : base(directoryName.Name)
        {
            FullName = directoryName.FullName;
        }
    }
}
