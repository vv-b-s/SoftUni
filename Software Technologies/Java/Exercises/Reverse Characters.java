package com.company;
import java.util.*;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args){
        Stack<Character> charStack = new Stack<>();
        for(int i=0;i<3;i++)
            charStack.push(Input.nextLine().charAt(0));
        while (charStack.size()>0)
            System.out.print(charStack.pop());
        System.out.println();
    }
}