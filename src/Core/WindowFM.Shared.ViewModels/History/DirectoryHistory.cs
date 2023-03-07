using System.Collections;

namespace WindowFM.Shared.ViewModels
{
    internal class DirectoryHistory : IDirectoryHistory
    {
        private DirectoryNode _head;

        public bool CanMoveBack => Current.PreviousNode != null;

        public bool CanMoveForward => Current.NexNode != null;

        public DirectoryNode Current { get; private set; }

        #region Enumerator
        public IEnumerator<DirectoryNode> GetEnumerator()
        {
            yield return Current;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        #region Constructor
        public DirectoryHistory(string directoryPath, string directoryPathName)
        {
            _head = new DirectoryNode(directoryPath, directoryPathName);
            Current = _head;
        }
        #endregion

        #region Events

        public event EventHandler HistoryChanged;

        #endregion

        #region Puplic Methods

        public void Add(string filePath, string name)
        {
            var node = new DirectoryNode(filePath, name);

            Current.NexNode = node;
            node.PreviousNode = Current;
            Current = node;

            RaiseHistoryChanged();
        }

        public void MoveBack()
        {
            var prev = Current.PreviousNode;

            Current = prev;

            RaiseHistoryChanged();
        }

        public void MoveForward()
        {
            var next = Current.NexNode;

            Current = next;

            RaiseHistoryChanged();
        }
        #endregion

        #region Private Methods
        private void RaiseHistoryChanged() => HistoryChanged?.Invoke(this, EventArgs.Empty);
        #endregion
    }
}