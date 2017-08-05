package com.company;

import java.util.*;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args) {
        String hexNum = Input.next();
        System.out.println(baseConverter(hexNum,16));
    }

    static int baseConverter(String number, int nBase){
        String digits = "0123456789ABCDEF";
        Character[] numbersCharList = number.chars().mapToObj(c -> (char)c).toArray(Character[]::new);
        ArrayList<Character> numbers = new ArrayList<>();
        numbers.addAll(Arrays.asList(numbersCharList));

        Stack<Integer> remstack = new Stack<>();

        while(numbers.size()>0){
            int index = digits.indexOf(numbers.get(0));
            remstack.push(index);
            numbers.remove(0);
        }

        int num = 0;
        int remStackCount = remstack.size();
        for(int i=0;i<remStackCount;i++)
            num+=(remstack.pop() * Math.pow(nBase,i));

        return num;
    }
}