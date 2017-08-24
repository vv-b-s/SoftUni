using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IMDB.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public int Year { get; set; }

        public Film() { }
        public Film(string name, string genre, string director, int year)
        {
            Name = name;
            Genre = genre;
            Director = director;
            Year = year;
        }

        public void MergeFilms(Film otherFilm)
        {
            Name = otherFilm.Name;
            Genre = otherFilm.Genre;
            Director = otherFilm.Director;
            Year = otherFilm.Year;
        }

        public bool HasNullData() => Name == ""|| Name==null || Genre == "" || Genre==null || Director == "" || Director==null || Year == 0;
    }
}