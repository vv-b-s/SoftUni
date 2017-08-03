package com.company;

import java.util.*;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args) {
        String[] input = Input.nextLine().split("\\s+");
        ArrayList<Integer> numbers = new ArrayList<Integer>();
        for(int i=0;i<input.length;i++)
            numbers.add(Integer.parseInt(input[i]));
        numbers.sort(Integer::compareTo);
        Collections.reverse(numbers);

        int loopLen = numbers.size()>=3?3:numbers.size();
        for(int i=0;i<loopLen;i++)
            System.out.println(numbers.get(i));
    }
}