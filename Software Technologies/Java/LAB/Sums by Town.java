package com.company;

import javax.xml.crypto.dsig.keyinfo.KeyValue;
import java.util.*;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args) {
           Map<String, Double> townIncome = new TreeMap<String,Double>();
           int arrCap = Integer.parseInt(Input.nextLine());
           String[] rawData =  new String[arrCap];
           for(int i=0;i<rawData.length;i++)
               rawData[i] = Input.nextLine();

           for(String raw : rawData){
               String[] data = Arrays
                       .stream(raw.split("\\|"))
                       .map(String::trim)
                       .filter(item->item.compareTo("")!=0)
                       .toArray(String[]::new);    // https://stackoverflow.com/questions/23079003/how-to-convert-a-java-8-stream-to-an-array

               String town = data[0];
               Double income = Double.parseDouble(data[1]);

               if(townIncome.containsKey(town))
                   townIncome.put(town, townIncome.get(town)+income);
               else
                   townIncome.put(town, income);
           }
           for(String key:townIncome.keySet())
               System.out.println(key + " -> "+townIncome.get(key));
       }
    }