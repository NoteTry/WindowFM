namespace WindowFM.Shared.ViewModels
{
    internal class DirectoryNode
    {
        public DirectoryNode PreviousNode { get; set; }

        public DirectoryNode NexNode { get; set; }

        public string DirectoryPathName { get; }

        public string DirectoryPath { get; }

        public DirectoryNode(string directoryPath, string directoryPathName)
        {
            DirectoryPath = directoryPath;
            DirectoryPathName = directoryPathName;
        }
    }
}