using System;
using System.Linq;

namespace Online_Radio_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputLength = int.Parse(Console.ReadLine());
            var playlist = new Playlist();

            while(inputLength-->0)
            {
                try
                {
                    var inputData = Console.ReadLine().Split(';');
                    var time = inputData[2].Split(':');

                    if (!int.TryParse(time[0], out int minutes) || !int.TryParse(time[1], out int seconds)) 
                        throw new InvalidSongLengthException();

                    var song = new Song(artistName: inputData[0], songName: inputData[1], minutes, seconds);
                    playlist.AddSong(song);
                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(playlist);
        }
    }
}
