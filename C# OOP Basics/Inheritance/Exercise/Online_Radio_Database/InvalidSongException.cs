using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Radio_Database
{
    public class InvalidSongException:ArgumentException
    {
        public override string Message => "Invalid song.";
    }

    public class InvalidArtistException:InvalidSongException
    {
        public override string Message => "Artist name should be between 3 and 20 symbols.";
    }

    public class InvalidSongNameException:InvalidSongException
    {
        public override string Message => "Song name should be between 3 and 30 symbols.";
    }

    public class InvalidSongLengthException:InvalidSongException
    {
        public override string Message => "Invalid song length.";
    }

    public class InvalidSongMinutesException:InvalidSongLengthException
    {
        public override string Message => "Song minutes should be between 0 and 14.";
    }

    public class InvalidSongSecondsException:InvalidSongLengthException
    {
        public override string Message => "Song seconds should be between 0 and 59.";
    }
}
