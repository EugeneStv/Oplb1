using LibVLCSharp.Shared;

namespace oplb2
{

    public class LFile
    {
        private string filePath;

        public LFile(string Path)
        {
            filePath = Path;
        }

        public Media LoadMedia(LibVLC libVLC)
        {
            return new Media(libVLC, filePath);
        }
    }


    public class UrlM
    {
        private string url;

        public UrlM(string link)
        {
            url = link;
        }

        public string MediaUrl()
        {
            return url;
        }
    }
}