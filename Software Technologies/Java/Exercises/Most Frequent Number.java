package com.company;
import java.util.*;
import java.util.stream.Collectors;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args){
      Map<Integer, Integer> numberOccurances = new LinkedHashMap<>();
      int[] array = Arrays
              .stream(Input.nextLine().split(" "))
              .mapToInt(Integer::parseInt)
              .toArray();
      for(int item:array){
          if(numberOccurances.containsKey(item))
              numberOccurances.put(item, numberOccurances.get(item)+1);
          else
              numberOccurances.put(item, 1);
      }

      int maxElement = getMaxEelement(numberOccurances.values());
        Integer[] keys = numberOccurances.keySet().toArray(new Integer[0]);
        for(int key : keys)
            if(numberOccurances.get(key)==maxElement){
                System.out.println(key);
                return;
            }
    }

    private static int getMaxEelement(Collection<Integer> values) {
        Integer[] intVals = values.toArray(new Integer[0]);
        int maxNumber = intVals[0];
        for(int n : intVals)
            maxNumber = n>maxNumber ? n : maxNumber;
        return maxNumber;
    }
}