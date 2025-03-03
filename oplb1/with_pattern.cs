using System;

public interface IFilmFactory
{
    ISubtitle CreateSubtitle();
    IAudio CreateAudio();
}

public interface ISubtitle
{
    void ApplySubtitle(LibVLCSharp.Shared.MediaPlayer mediaPlayer, string moviePath);
}

public interface IAudio
{
    void ApplyAudio(LibVLCSharp.Shared.MediaPlayer mediaPlayer, string moviePath);
}

public class EnglishSubtitle : ISubtitle
{
    public void ApplySubtitle(LibVLCSharp.Shared.MediaPlayer mediaPlayer, string moviePath)
    {
        string subtitlePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(moviePath), "English.srt");
        mediaPlayer.Media.AddOption($":sub-file={subtitlePath}");
    }
}

public class RussianSubtitle : ISubtitle
{
    public void ApplySubtitle(LibVLCSharp.Shared.MediaPlayer mediaPlayer, string moviePath)
    {
        string subtitlePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(moviePath), "Russian.srt");
        mediaPlayer.Media.AddOption($":sub-file={subtitlePath}");
    }
}

public class EnglishAudio : IAudio
{
    public void ApplyAudio(LibVLCSharp.Shared.MediaPlayer mediaPlayer, string moviePath)
    {
        string audioPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(moviePath), "English.mp3");
        mediaPlayer.Media.AddOption($":input-slave={audioPath}");
    }
}

public class RussianAudio : IAudio
{
    public void ApplyAudio(LibVLCSharp.Shared.MediaPlayer mediaPlayer, string moviePath)
    {
        string audioPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(moviePath), "Russian.mp3");
        mediaPlayer.Media.AddOption($":input-slave={audioPath}");
    }
}
public class EnglishFilmFactory : IFilmFactory
{
    public ISubtitle CreateSubtitle()
    {
        return new EnglishSubtitle();
    }

    public IAudio CreateAudio()
    {
        return new EnglishAudio();
    }
    public override string ToString()
    {
        return "English"; 
    }
}

public class RussianFilmFactory : IFilmFactory
{
    public ISubtitle CreateSubtitle()
    {
        return new RussianSubtitle();
    }

    public IAudio CreateAudio()
    {
        return new RussianAudio();
    }
    public override string ToString()
    {
        return "Russian"; 
    }
}