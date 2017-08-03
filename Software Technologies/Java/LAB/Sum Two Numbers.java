package com.company;

import java.util.ArrayList;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        double numberOne = Double.parseDouble(input.next());
        double numberTwo = Double.parseDouble(input.next());

        System.out.println(numberOne+numberTwo);
    }
}