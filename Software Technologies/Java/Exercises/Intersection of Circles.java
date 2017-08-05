package com.company;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

 public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args) {
        double[] circleData = Arrays.stream(Input.nextLine().split(" ")).mapToDouble(Double::parseDouble).toArray();
        Circle circle1 = new Circle(circleData[0], circleData[1], circleData[2]);
        circleData = Arrays.stream(Input.nextLine().split(" ")).mapToDouble(Double::parseDouble).toArray();
        Circle circle2 = new Circle(circleData[0], circleData[1], circleData[2]);

        System.out.println(circle1.Intersects(circle2) ? "Yes" : "No");
    }
}

class Circle{
    private static final int x = 0, y=1;

    private double[] center = new double[2];
    private double radius;

    public Circle(double centerX, double centerY, double radius){
        center[x] = centerX;
        center[y] = centerY;
        this.radius = radius;
    }

    public boolean Intersects(Circle circle){
        double distance = GetDistance(center, circle.center);
        return distance <= radius + circle.radius;
    }

    static double GetDistance(double[] pointOne, double[] pointTwo){
        double x0 = Math.max(pointOne[x], pointTwo[x]) - Math.min(pointOne[x], pointTwo[x]);
        double y0 = Math.max(pointOne[y], pointTwo[y]) - Math.min(pointOne[y], pointTwo[y]);

        x0 = Math.pow(x0, 2);
        y0 = Math.pow(y0, 2);

        return Math.sqrt(x0 + y0);
    }

}