package com.company;
import java.util.*;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args){
        int[] array = Arrays.stream(Input.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        ArrayList<Integer> numbers = new ArrayList<>();

        ArrayList<Integer> currentNumbers = new ArrayList<>();
        currentNumbers.add(array[0]);
        for(int i=1;i<array.length;i++){
            if(array[i]>array[i-1])
                currentNumbers.add(array[i]);
            else if(currentNumbers.size()>numbers.size() && array[i]<=array[i-1]){
                numbers = currentNumbers;
                currentNumbers = new ArrayList<>();
                currentNumbers.add(array[i]);
            }
            else{
                currentNumbers = new ArrayList<>();
                currentNumbers.add(array[i]);
            }
        }
        if (currentNumbers.size()>numbers.size()){
            numbers = currentNumbers;
        }

        System.out.println(String.join(" ",numbers.stream().map(Object::toString).toArray(String[]::new)));
    }
}