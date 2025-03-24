using LibVLCSharp.Shared;

namespace oplb2
{
    public interface IMediaSource
    {
        Media LoadMedia(LibVLC libVLC);
    }

    public class LocalFile : IMediaSource
    {
        private string filePath;

        public LocalFile(string Path)
        {
            filePath = Path;
        }

        public Media LoadMedia(LibVLC libVLC)
        {
            return new Media(libVLC, filePath);
        }
    }


    public class UrlMedia
    {
        private string url;

        public UrlMedia(string link)
        {
            url = link;
        }

        public string MediaUrl()
        {
            return url;
        }
    }


    public class UrlAdapter : IMediaSource
    {
        private UrlMedia urlMedia;

        public UrlAdapter(string link)
        {
            urlMedia = new UrlMedia(link);
        }

        public Media LoadMedia(LibVLC libVLC)
        {
            return new Media(libVLC, urlMedia.MediaUrl(), FromType.FromLocation);
        }
    }
}