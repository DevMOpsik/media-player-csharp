using System;

namespace MediaPlayer.Models
{
    public class Track
    {
        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public TimeSpan Duration { get; set; }

        public Track(string filePath)
        {
            FilePath = filePath;
            Title = System.IO.Path.GetFileNameWithoutExtension(filePath);
            Artist = "Неизвестен";
            Duration = TimeSpan.Zero;
        }

        public override string ToString()
        {
            return $"{Artist} - {Title}";
        }
    }
}
