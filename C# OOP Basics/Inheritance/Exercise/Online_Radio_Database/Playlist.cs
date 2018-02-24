using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Radio_Database
{
    public class Playlist
    {
        private Queue<Song> songs;

        public Playlist() => songs = new Queue<Song>();

        public void AddSong(Song song) => songs.Enqueue(song);

        public override string ToString() =>
            $"Songs added: {songs.Count}\n" +
            $"Playlist length: {GetPlaylistLength()}";

        /// <summary>
        /// Sum all the playtime from the playlist
        /// </summary>
        /// <returns></returns>
        private string GetPlaylistLength()
        {
            var secondsOfPlaying = 0L;

            foreach(var song in songs)
                secondsOfPlaying += song.PlaytimeInSeconds;

            int hours = (int)(secondsOfPlaying / 3600);
            secondsOfPlaying -= hours * 3600L;

            int minutes = (int)(secondsOfPlaying / 60);
            secondsOfPlaying -= minutes * 60L;

            return $"{hours}h {minutes}m {secondsOfPlaying}s";
        }
    }
}
