namespace WindowFM.Shared.ViewModels
{
    internal interface IDirectoryHistory : IEnumerable<DirectoryNode>
    {
        bool CanMoveBack { get; }

        bool CanMoveForward { get; }

        DirectoryNode Current { get; } 

        event EventHandler HistoryChanged;

        void Add(string filePath, string name);

        void MoveBack();

        void MoveForward();
    }
}
