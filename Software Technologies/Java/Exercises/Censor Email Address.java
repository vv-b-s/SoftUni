package com.company;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args){
        String wantedEmail = Input.nextLine();
        Pattern regex = Pattern.compile("(.+)@(.+)");
        String[] lines = Input.nextLine().split(" ");

        for(int i=0;i<lines.length;i++){
            if(lines[i].compareTo(wantedEmail)==0){
                Matcher matches = regex.matcher(lines[i]);
                matches.matches();                                  // https://stackoverflow.com/questions/5674268/no-match-found-when-using-matchers-group-method
                lines[i] = createString('*',matches.group(1).length())+"@"+matches.group(2);
            }
        }
        System.out.println(String.join(" ",lines));
    }

    private static String createString(char repeatCh, int length) {
        StringBuffer sB = new StringBuffer();
        for(int i=0;i<length;i++)
            sB.append(repeatCh);
        return sB.toString();
    }
}