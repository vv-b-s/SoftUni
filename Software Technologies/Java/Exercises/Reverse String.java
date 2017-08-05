package com.company;
import java.util.*;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args){
        String word = Input.nextLine();
        for(int i = word.length()-1;i>=0;i--)
            System.out.print(word.charAt(i));
        System.out.println();
    }
}