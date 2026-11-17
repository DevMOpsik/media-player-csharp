using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MediaPlayer.Models;
namespace MediaPlayer.Services
{
    public static class PlaylistService
    {
        private static readonly string FilePath = "playlist.json";
        public static void Save(List<Track> playlist) => File.WriteAllText(FilePath, JsonSerializer.Serialize(playlist, new JsonSerializerOptions { WriteIndented = true }));
        public static List<Track> Load() => File.Exists(FilePath) ? JsonSerializer.Deserialize<List<Track>>(File.ReadAllText(FilePath)) ?? new List<Track>() : new List<Track>();
    }
}
