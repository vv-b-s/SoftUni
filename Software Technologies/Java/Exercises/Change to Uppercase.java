package com.company;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args) {
        String line = Input.nextLine();
        List<String> matches = getAllMatchesFromGroup("(<upcase>)(.+?)(<\\/upcase>)",line,2);
        matches = matches.stream().map(String::toUpperCase).collect(Collectors.toList());
        line =  replaceAllMatching(line,"(<upcase>)(.+?)(<\\/upcase>)",matches);

        System.out.println(line);
    }

    private static String replaceAllMatching(String text, String regex, List<String> replaceCollection) {
        for(int i=0;i<replaceCollection.size();i++)
            text = text.replaceFirst(regex,replaceCollection.get(i));
        return text;
    }

    private static List<String> getAllMatchesFromGroup(String regex, String text, int group) {  //https://stackoverflow.com/questions/6020384/create-array-of-regex-matches
        ArrayList<String> outList = new ArrayList<>();
        Pattern rgx = Pattern.compile(regex);
        Matcher match = rgx.matcher(text);
        while (match.find()){
            outList.add(match.group(group));
        }
        return outList;
    }
}