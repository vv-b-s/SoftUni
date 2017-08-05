package com.company;
import java.util.*;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args){
        char letter = Input.next().charAt(0);
        String output;
        if(isVowel(letter))
            output = "vowel";
        else if(Character.isDigit(letter))
            output = "digit";
        else
            output = "other";

        System.out.println(output);
    }

    private static boolean isVowel(char letter) {
        ArrayList<Character> vowels = new ArrayList<>();
        vowels.add('a');
        vowels.add('e');
        vowels.add('i');
        vowels.add('o');
        vowels.add('u');
        return vowels.contains(letter);
    }
}