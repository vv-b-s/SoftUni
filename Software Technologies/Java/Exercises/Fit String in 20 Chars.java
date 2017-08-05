package com.company;
import java.util.*;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args){
        String input = Input.nextLine();
        for(int i=0;i<20;i++){
            System.out.print(
                    i<input.length()?
                            input.charAt(i):
                            '*'
            );
        }
    }
}