package com.company;
import java.util.*;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args){
        int[] array = Arrays.stream(Input.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        int maxRepeatedRecord = 1;
        int numberRecord = array[0];

        int currentMax = 1;
        int currentNumber = array[0];
        for(int i=1;i<array.length;i++){
            if(array[i]==array[i-1])
                currentMax++;
            else if(currentMax>maxRepeatedRecord&&array[i]!=array[i-1]){
                maxRepeatedRecord = currentMax;
                numberRecord = currentNumber;
                currentMax = 1;
                currentNumber = array[i];
            }
            else{
                currentMax = 1;
                currentNumber = array[i];
            }
        }
        if (currentMax>maxRepeatedRecord){
            maxRepeatedRecord = currentMax;
            numberRecord = currentNumber;
        }

        for(int i=0;i<maxRepeatedRecord;i++)
            System.out.print(numberRecord+" ");
        System.out.println();
    }
}