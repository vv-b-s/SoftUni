package com.company;
import javax.annotation.processing.SupportedSourceVersion;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;
import java.util.stream.Stream;
import java.util.zip.DeflaterOutputStream;

public class Main {
    static Scanner Input = new Scanner(System.in);

    public static void main(String[] args) {
        List<Student> students = new ArrayList<>();

        for(int i =Integer.parseInt(Input.nextLine());i>0;i--)
        {
            String[] inputArr = Arrays.stream(Input.nextLine().split(" ")).toArray(String[]::new);
            ArrayList<String> input = getDataFromArray(inputArr);
            String name = input.get(0);
            input.remove(0);
            List<Double> grades = input.stream().map(Double::parseDouble).collect(Collectors.toList());

            students.add(new Student(name, grades));
        }

        System.out.println(Student.PrintStudentsWithHighGPA(students));
    }

    private static ArrayList<String> getDataFromArray(String[] inputArr) {
        ArrayList<String> outSet = new ArrayList<>();
        for(String item: inputArr)
            outSet.add(item);
        return outSet;
    }
}

class Student
{
    private List<Double> grades = new ArrayList<>();

    public String Name;
    public double GPA(){
        double gradesSum = 0;
        for(double grade:grades)
            gradesSum+=grade;
        return gradesSum/grades.size();
    }

    public Student(String name, List<Double> grades)
    {
        Name = name;
        this.grades = grades;
    }

    public static String PrintStudentsWithHighGPA(List<Student> students)
    {
        Comparator<Student> comparator = Comparator.comparing(student -> student.Name); // https://stackoverflow.com/questions/4805606/how-to-sort-by-two-fields-in-java
        comparator = comparator.thenComparing(Student::GPA,Comparator.reverseOrder());// https://stackoverflow.com/questions/28709769/how-to-sort-map-entries-by-values-first-then-by-key-and-put-the-ordered-keys-in

        Stream<Student> studentStream = students.stream().filter(s -> s.GPA()>= 5.00).sorted(comparator);
        students = studentStream.collect(Collectors.toList());

        StringBuffer gradesStringList = new StringBuffer();
        for (Student student : students)
        gradesStringList.append(
                String.format("%s -> %.2f\n", student.Name, student.GPA())
        );

        return gradesStringList.toString();
    }
}