package com.company;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args) {
        Map<String, String> phonebook = new TreeMap<>();

        String commandLine;
        while ((commandLine = Input.nextLine()).compareTo("END")!=0){
            String[] temp  = commandLine.split(" ");
            String command = temp[0];
            String name    = temp.length>=2? temp[1]:"";
            String number  = temp.length==3? temp[2]:"";

            switch (command){
                case "A": phonebook.put(name, number); break;
                case "S":
                    System.out.println(
                            phonebook.containsKey(name)?
                                    name + " -> " + phonebook.get(name):
                                    "Contact " + name + " does not exist."
                    );
                    break;
                case "ListAll":
                    for(String person:phonebook.keySet())
                        System.out.println(person + " -> " + phonebook.get(person));
                    break;
            }
        }
    }
}