namespace opl4wop
{
    public interface ICloudStorageProvider
    {
        string ProviderName { get; }
        string RootFolderId { get; }

        void Connect();
        List<CloudFile> GetFiles(string path); 
        void DownloadFile(string fileId, string localPath);
        void UploadFile(string localPath, string remotePath);
        void DeleteFile(string fileId);
        void RenameFile(string fileId, string newName);
        string CreateFolder(string parentId, string folderName);
        string NormalizePath(string path);
    }

    public class CloudFile
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsDirectory { get; set; }
        public long Size { get; set; }
        public string MimeType { get; set; }
        public string DownloadUrl { get; set; }
    }
}