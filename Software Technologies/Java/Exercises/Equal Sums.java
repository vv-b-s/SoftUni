package com.company;
import java.util.*;
import java.util.stream.Collectors;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args){
      int[] array = Arrays.stream(Input.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();

      for(int i=0;i<array.length;i++){
          List<Integer> leftSide = take(array,0,i);
          List<Integer> rightSide = skip(array, i);

          int leftSum = sum(leftSide);
          int rightSum = sum(rightSide);

          if(leftSum==rightSum){
              System.out.println(i);
              return;
          }
      }

      System.out.println("no");
    }

    private static int sum(List<Integer> intList) {
        int sum = 0;
        for(int i : intList)
            sum+=i;
        return sum;
    }

    private static ArrayList<Integer> skip(int[] array, int endIndex) {
        ArrayList<Integer> outList = new ArrayList<>();
        for(int i=endIndex+1;i<array.length;i++)
            outList.add(array[i]);
    return outList;
    }

    private static ArrayList<Integer> take(int[] array, int startIndex, int length) {
        ArrayList<Integer> outList = new ArrayList<>();
        for(int i=startIndex;i<length;i++)
            outList.add(array[i]);
        return  outList;
    }
}