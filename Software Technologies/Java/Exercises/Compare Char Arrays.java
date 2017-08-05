package com.company;
import java.util.*;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args){
        String[] letters = new String[2];

        for(int i=0;i<letters.length;i++)
            letters[i] = String.join("",Input.nextLine().split("\\s"));

        Arrays.sort(letters);

        System.out.println(String.join("\n",letters));
    }
}