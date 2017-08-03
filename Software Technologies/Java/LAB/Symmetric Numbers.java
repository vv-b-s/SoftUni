package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args) {
        int endNumber = Input.nextInt();
        for(Integer i=1;i<=endNumber;i++){
            String number = i.toString();

            if(numberIsSymmetric(number))
                System.out.print(number+" ");
        }
    }

    private static boolean numberIsSymmetric(String number) {
        for(int i=0;i<number.length();i++)
            if(number.charAt(i)!=number.charAt(number.length()-i-1))
                return false;
        return true;
    }
}