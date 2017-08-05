package com.company;
import java.util.*;
import java.util.stream.Collectors;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args){
      String word = Input.nextLine();
      for(char c:word.toCharArray())
          System.out.println(c+" -> "+((int)c-97));
    }
}