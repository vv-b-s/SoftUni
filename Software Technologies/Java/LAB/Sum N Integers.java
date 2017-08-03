package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args) {
        int loopLen = Input.nextInt();
        int sum = 0;
        for(int i=0;i<loopLen;i++)
            sum+=Input.nextInt();
        System.out.println("Sum = "+sum);
    }
}