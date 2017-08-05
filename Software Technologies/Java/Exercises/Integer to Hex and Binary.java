package com.company;
import java.util.*;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args){
        Integer integer = Input.nextInt();
        System.out.println(Integer.toString(integer,16).toUpperCase());
        System.out.println(Integer.toString(integer,2));
    }
}