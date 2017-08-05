package com.company;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

 public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args) {
        System.out.println(MessageGenerator.GenerateMessages(Input.nextInt()));
    }
}

class MessageGenerator{
    static private ArrayList<String> phrases =
            addListItems(
                    new String[]{
                            "Excellent product.",
                            "Such a great product.",
                            "I always use that product.",
                            "Best `product of its category.",
                            "Exceptional product.",
                            "I can’t live without this product."
                    });
    static private ArrayList<String> events  =
            addListItems(
                    new String[]
                            {
                                    "Now I feel good.",
                                    "I have succeeded with this p`roduct.",
                                    "Makes miracles.I am happy of the results!",
                                    "I cannot believe but now I feel awesome.",
                                    "Try it yourself, I am very satisfied.",
                                    "I feel great!"
                            });
    static private ArrayList<String> authors =
            addListItems(
                    new String[]{
                            "Diana",
                            "Petya",
                            "Stella",
                            "Elena",
                            "Katya",
                            "Iva",
                            "Annie",
                            "Eva"
                    });
    static private ArrayList<String> cities  = addListItems(
            new String[]{
                    "Burgas",
                    "Sofia",
                    "Plovdiv",
                    "Varna",
                    "Ruse"
            });

    private static ArrayList<String> addListItems(String[] arr){
        ArrayList<String> outList = new ArrayList<>();
        for(String item:arr)
            outList.add(item);
        return outList;
    }

    public static String GenerateMessages(int numberOfMessages){
        StringBuffer messages = new StringBuffer();
        Random rand = new Random();

        for(int i=0;i<numberOfMessages;i++)
            messages.append(String.format("%s %s %s - %s",
                    phrases.get(rand.nextInt(phrases.size())),
                    events.get(rand.nextInt(events.size())),
                    authors.get(rand.nextInt(authors.size())),
                    cities.get(rand.nextInt(cities.size()))
            )+"\n");
        return messages.toString();
    }
}