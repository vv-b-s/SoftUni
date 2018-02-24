using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Radio_Database
{
    public class Song
    {
        string artistName;
        string songName;
        int minutes;
        int seconds;

        public Song(string artistName, string songName, int minutes, int seconds)
        {
            ArtistName = artistName;
            SongName = songName;
            Minutes = minutes;
            Seconds = seconds;
        }

        public string ArtistName
        {
            get => artistName;
            set
            {
                if (LengthIsValid(value.Length, 3, 20)) 
                    artistName = value;
                
                else throw new InvalidArtistException();
            }
        }

        public string SongName
        {
            get => songName;
            set
            {
                if (LengthIsValid(value.Length, 3, 30)) 
                    songName = value;

                else throw new InvalidSongNameException();
            }
        }

        public int Minutes
        {
            get => minutes;
            set
            {
                if (LengthIsValid(value, 0, 14))
                    minutes = value;

                else throw new InvalidSongMinutesException();
            }
        }

        public int Seconds
        {
            get => seconds;
            set
            {
                if (LengthIsValid(value, 0, 59))
                    seconds = value;

                else throw new InvalidSongSecondsException();
            }
        }

        public int PlaytimeInSeconds => Seconds + Minutes * 60;

        private bool LengthIsValid(int valueLength, int minLength, int maxLength) => valueLength>= minLength && valueLength<= maxLength;
    }
}
