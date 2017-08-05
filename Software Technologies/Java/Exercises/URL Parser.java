package com.company;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args) {
        String url = Input.nextLine();
        String protocol = "";
        String server   = "";
        String resource = "";

        int protocolEndIndex = url.indexOf("://");
        if(protocolEndIndex>-1){
            protocol = url.substring(0,protocolEndIndex);
            url = skip(url,protocolEndIndex+3);
        }

        int serverEndIndex = url.indexOf('/');
        if(serverEndIndex>-1){
            server = url.substring(0,serverEndIndex);
            url = skip(url,serverEndIndex+1);
            resource = url;
        }
        else
            server = url;

        System.out.printf(
                "[protocol] = \"%s\"\n[server] = \"%s\"\n[resource] = \"%s\"",
                protocol == null ? "" : protocol,
                server   == null ? "" : server,
                resource == null ? "" : resource
        );
    }

    private static String skip(String line,int startIndex) {
        StringBuffer sB = new StringBuffer();
        for(int i=startIndex;i<line.length();i++)
            sB.append(line.charAt(i));
        return  sB.toString();
    }
}