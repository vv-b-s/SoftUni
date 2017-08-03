package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args) {
        String[] inputs = Input.nextLine().split("\\s+");
        ArrayList<Integer> numbers = new ArrayList<Integer>();

        for(String item : inputs)
            numbers.add(Integer.parseInt(item));

        int numListSize = numbers.size();
        for(int i=0;i<numListSize;i++)
            for(int j=i+1;j<numListSize;j++){
                int sumOfNumbers = numbers.get(i)+numbers.get(j);
                if((numbers.contains(sumOfNumbers)&&sumOfNumbers!=numbers.get(i)&&sumOfNumbers!=numbers.get(j)||
                allNumbersAreZeroes(numbers))){
                    int lowestN = Math.min(numbers.get(i),numbers.get(j));
                    int highestN = Math.max(numbers.get(i),numbers.get(j));

                    System.out.printf("%d + %d = %d",lowestN,highestN,lowestN+highestN);
                    return;
                }
            }
            System.out.println("No");
    }

    private static boolean allNumbersAreZeroes(ArrayList<Integer> numbers) {
        for(int n:numbers)
            if(n!=0)
                return false;
        return true;
    }
}