package com.company;

import java.util.*;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args){
        String word = Input.next().toLowerCase();
        if(word.compareTo("true")==0)
            System.out.println("Yes");
        else if(word.compareTo("false")==0)
            System.out.println("No");
    }
}