package imdb.entity;

import javax.persistence.*;

@Entity
@Table(name = "films")
public class Film {
	private Integer id;
	private String name;
	private String genre;
	private String director;
	private Integer year;

	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    @Column(name = "name", nullable = false)
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Column(name = "genre", nullable = false)
    public String getGenre() {
        return genre;
    }

    public void setGenre(String genre) {
        this.genre = genre;
    }

    @Column(name = "director", nullable = false)
    public String getDirector() {
        return director;
    }

    public void setDirector(String director) {
        this.director = director;
    }

    @Column(name = "year", nullable = false)
    public Integer getYear() {
        return year;
    }

    public void setYear(Integer year) {
        this.year = year;
    }

    public Film() {}
    public Film(String name, String genre, String director, Integer year)
    {
        this.name = name;
        this.genre = genre;
        this.director = director;
        this.year = year;
    }

    public boolean allDataHasValue()
    {
        return !(this.name.isEmpty()||this.genre.isEmpty()||this.director.isEmpty()||this.year==0);
    }

    public void mergeData(Film otherFilm){
	    this.name = otherFilm.name;
	    this.genre = otherFilm.genre;
	    this.director = otherFilm.director;
	    this.year = otherFilm.year;
    }
}
