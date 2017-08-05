package com.company;
import java.util.*;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args){

        List<Integer> rawList = getListItems(Input.nextLine());

        int[] bomb = Arrays
                .stream(Input.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        int bombNumber = bomb[0];
        int power = bomb[1];

        if(power==0)
            rawList.removeIf(b->b==bombNumber);
        else
            for(int i=0;i<rawList.size();i++)
                if(rawList.get(i)==bombNumber){
                    ArrayList<Integer> tempList = new ArrayList<>();
                    for(int j=0;j<i-power;j++)
                        tempList.add(rawList.get(j));
                    for(int j = i+power+1;j<rawList.size();j++)
                        tempList.add(rawList.get(j));
                    rawList = tempList;
                }

        int sum = 0;
        for(int item:rawList)
            sum+=item;
        System.out.println(sum);

    }

    private static List<Integer> getListItems(String input) {
        String[] items = input.split(" ");
        ArrayList<Integer> outList = new ArrayList<>();
        for(String item:items)
            outList.add(Integer.parseInt(item));
        return outList;
    }
}