import java.util.*;
import java.util.stream.Collectors;

public class Trainlands {
    private static Scanner scanner = new Scanner(System.in);
    private static LinkedHashMap<String,LinkedHashMap<String,Long>> trains = new LinkedHashMap<>();

    public static void main(String[] args) {
        String input;
        while (!(input=scanner.nextLine()).equals("It's Training Men!")){
            String[] trainData = Arrays.stream(input.split("[\\->:=\\s]+")).filter(w->!w.equals("")).toArray(String[]::new);

            if(input.contains(":"))
                addOrUpdateTrain(trainData);
            else if(input.contains("="))
                copyWagons(trainData);
            else
                moveWagonsToOtherTrain(trainData);
        }

        sortTrains();
        printTrains();
    }

    private static void addOrUpdateTrain(String[] trainData) {
        String trainName = trainData[0];
        String wagonName = trainData[1];
        Long wagonPower = Long.parseLong(trainData[2]);

        LinkedHashMap<String, Long> wagons;
        if(trains.containsKey(trainName)){
            wagons = trains.get(trainName);
            wagons.put(wagonName, wagonPower);
        }
        else{
            wagons = new LinkedHashMap<>();
            wagons.put(wagonName,wagonPower);
            trains.put(trainName,wagons);
        }
    }

    private static void moveWagonsToOtherTrain(String[] trainData) {
        String firstTrain = trainData[0];
        String secondTrain = trainData[1];

        if(!trains.containsKey(firstTrain))
            trains.putIfAbsent(firstTrain,new LinkedHashMap<>());

        trains.get(firstTrain).putAll(trains.get(secondTrain));
        trains.remove(secondTrain);
    }

    private static void copyWagons(String[] trainData) {
        String firstTrain = trainData[0];
        String secondTrain = trainData[1];

        if(!trains.containsKey(firstTrain)) {
            trains.put(firstTrain, new LinkedHashMap<>(trains.get(secondTrain)));
            return;
        }

        LinkedHashMap<String, Long> wagonsCopy = new LinkedHashMap<>(trains.get(secondTrain));
        trains.put(firstTrain, wagonsCopy);
    }

    private static void sortTrains(){

        //Order wagons by wagon power
        for(Map.Entry<String, LinkedHashMap<String, Long>> train: trains.entrySet())
            trains.put(train.getKey(),orderWagons(train.getValue()));

        Comparator<Map.Entry<String,LinkedHashMap<String,Long>>> comparationConditions =
                Comparator.comparing(t->getTotalWagonPower(t.getValue()),Comparator.reverseOrder());
        comparationConditions = comparationConditions.thenComparing(t->t.getValue().size());

        trains = new LinkedHashMap<>((Map<? extends String, ? extends LinkedHashMap<String, Long>>) trains.entrySet().stream().sorted(comparationConditions).collect(
                Collectors.toMap(Map.Entry::getKey,Map.Entry::getValue,
                        (oldValue, newValue)->oldValue,
                        LinkedHashMap::new)));
    }

    private static LinkedHashMap<String,Long> orderWagons(Map<String, Long> wagons) {
        Map train = wagons.entrySet().stream()
                .sorted(Map.Entry.comparingByValue(Comparator.reverseOrder()))
                        .collect(Collectors.toMap(Map.Entry::getKey,Map.Entry::getValue,
                                (oldValue,newValue)->oldValue, LinkedHashMap::new));

        return new LinkedHashMap<>(train);
    }

    private static long getTotalWagonPower(LinkedHashMap<String, Long> wagons){
        long totalWagonPower = 0l;

        for(Map.Entry<String, Long> wagon:wagons.entrySet())
            totalWagonPower+=wagon.getValue();
        return totalWagonPower;
    }

    private static void printTrains(){
        trains.forEach((trainName, wagons) -> {
            System.out.printf("Train: %s\n", trainName);
            wagons.forEach((wagon, power) -> System.out.printf("###%s - %d\n", wagon, power));
        });
    }
}

