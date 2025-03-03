public class AudSub
{
    public static void Audio(string language, LibVLCSharp.Shared.MediaPlayer mediaPlayer, string moviePath)
    {
        string audioPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(moviePath), $"{language}.mp3");
        mediaPlayer.Media.AddOption($":input-slave={audioPath}");
        
    }
    public static void Subtitle(string language, LibVLCSharp.Shared.MediaPlayer mediaPlayer, string moviePath)
    {
        string subtitlePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(moviePath), $"{language}.srt");
        mediaPlayer.Media.AddOption($":sub-file={subtitlePath}");

    }
}

