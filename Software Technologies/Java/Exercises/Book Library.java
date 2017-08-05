package com.company;
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

        System.out.println(lib.ListAuthorSalery());
    }
}

class Book
{

    public String Title;
    public String Publisher;
    public String ReleaseDate;
    String ISBN;
    public Double Price;

    public Book(String title, String publisher, String releaseDate, String ISBN, String price)
    {
        Title = title;
        Publisher = publisher;
        ReleaseDate = releaseDate;
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

    public String ListAuthorSalery()
    {
        Comparator<Author> orderBySaleryThenByName = Comparator.comparing(a->a.getSallery(),Comparator.reverseOrder());
        orderBySaleryThenByName = orderBySaleryThenByName.thenComparing(a->a.Name);

        Stream<Author> authorStream = authors.stream().sorted(orderBySaleryThenByName);
        authors = authorStream.collect(Collectors.toList());

        StringBuffer sB = new StringBuffer();
        for(Author author: authors)
            sB.append(author.Name + " -> " + String.format("%.2f",author.getSallery())+"\n");

        return sB.toString();
    }
}
