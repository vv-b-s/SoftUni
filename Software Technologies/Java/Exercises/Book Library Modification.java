package com.company;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import static java.lang.System.in;

public class Main {
    static Scanner Input = new Scanner(in);

    public static void main(String[] args) {
        Library lib = new Library();

        for (int i = Integer.parseInt(Input.nextLine()); i > 0; i--)
        {
            String[] input     = Input.nextLine().split(" ");
            String bookName    = input[0];
            String bookAuthor  = input[1];
            String publisher   = input[2];
            String releaseDate = input[3];
            String ISBN        = input[4];
            String price       = input[5];

            if (lib.HasAuthor(bookAuthor))
                lib.AddBook(bookAuthor, new Book(bookName, publisher, releaseDate, ISBN, price));
            else
                lib.AddAuthor(bookAuthor, new Book(bookName, publisher, releaseDate, ISBN, price));
        }
        String afterDate = Input.nextLine();
        System.out.println(lib.ListBooksAfterDate(afterDate));
    }
}

class Book {
    SimpleDateFormat dateFormat = new SimpleDateFormat("d.MM.yyyy");

    public String Title;
    public String Publisher;
    public Calendar ReleaseDate = Calendar.getInstance();
    String ISBN;
    public Double Price;

    public Book(String title, String publisher, String releaseDate, String ISBN, String price)
    {
        Title = title;
        Publisher = publisher;
        try { ReleaseDate.setTime(dateFormat.parse(releaseDate)); } catch (ParseException ex){}
        this.ISBN = ISBN;
        Price = Double.parseDouble(price);
    }
}

class Author{
    public String Name;
    public ArrayList<Book> Books = new ArrayList<>();

    public  Author(String name, Book book){
        Name=name;
        Books.add(book);
    }

    public Double getSallery() {
        Double sum = 0.00;
        for(Book book:Books)
            sum+=book.Price;
        return sum;
    }
}

class Library
{
    private List<Author> authors = new ArrayList<>();

    public void AddAuthor(String name, Book book){
        authors.add(new Author(name,book));
    }

    public void AddBook(String authorName, Book book) {
        for(Author author: authors)
            if(author.Name.compareTo(authorName)==0)
                author.Books.add(book);
    }

    public Boolean HasAuthor(String name) {
        for(Author author:authors)
            if(author.Name.compareTo(name)==0)
                return true;
        return false;
    }

    public String ListBooksAfterDate(String date){
        try{
            SimpleDateFormat df = new SimpleDateFormat("d.MM.yyyy");

            Date dateToCompare = df.parse(date);
            List<Book> books = getAllBooks(authors);
            Comparator<Book> compareByDateThenByTitle = Comparator.comparing(b->b.ReleaseDate.getTime());
            compareByDateThenByTitle = compareByDateThenByTitle.thenComparing(b->b.Title);

            List<Book> booksToList = books
                    .stream()
                    .sorted(compareByDateThenByTitle)
                    .filter(b->b.ReleaseDate.getTime().compareTo(dateToCompare)>0)
                    .collect(Collectors.toList());

            StringBuffer list = new StringBuffer();
            for(Book book:booksToList)
                list.append(book.Title+" -> "+df.format(book.ReleaseDate.getTime())+"\n");  //display the datetime in wanted format
            return list.toString();
        }catch (ParseException ex){}
        return null;
    }

    private List<Book> getAllBooks(List<Author> authors) {
        List<Book> outList = new ArrayList<>();
        for(Author author:authors)
            outList.addAll(author.Books);
        return outList;
    }
}
