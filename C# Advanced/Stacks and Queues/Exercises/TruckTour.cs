using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

class TruckTour
{
    static void Main(string[] args)
    {
        var numberOfPumps = long.Parse(ReadLine());
        var trucks = new Queue<Truck>();
        var pumps = new Queue<Pump>();

        var truckMadeFullCircle = false;

        //Get the data for all of the pumps
        for (long i = 0; i < numberOfPumps; i++)
        {
            long[] pumpData = ParseArray();
            var pump = new Pump(i, pumpData[0], pumpData[1]);

            //Each trcuk in the queue has to pass through the pump point
            MoveTrucks(trucks, pump, out truckMadeFullCircle);

            //If a truck has made a full circle announce it and skip the program
            if (truckMadeFullCircle)
            {
                WriteLine(trucks.Dequeue().StartingPoint);
                return;
            }
            
            //Otherwise add a new pump and truck to the queues
            pumps.Enqueue(pump);

            var truck = new Truck(i, pump.Petrol - pump.DistanceToNextPump);

            //If the truck's fuel is enouh to get to the next pump, it will be added to the queue
            if (truck.Fuel >= 0)
                trucks.Enqueue(truck);
        }

        //If there are still no truckes which made full circle a continuous flip will start
        while (!truckMadeFullCircle && trucks.Count > 0) 
        {
            //Each pump will be dequeued
            var pump = pumps.Dequeue();

            //And each truck will pass through it
            MoveTrucks(trucks, pump, out truckMadeFullCircle);
            pumps.Enqueue(pump);

            //Untill a truch has made a full circle
            if (truckMadeFullCircle)
            {
                WriteLine(trucks.Dequeue().StartingPoint);
                return;
            }
        }
    }

    /// <summary>
    /// Trucks can't move on their own. This method is designed to help them out
    /// </summary>
    /// <param name="trucks"></param>
    /// <param name="pump"></param>
    /// <param name="truckMadeFullCircle"></param>
    private static void MoveTrucks(Queue<Truck> trucks, Pump pump, out bool truckMadeFullCircle)
    {
        long numberOfTrucks = trucks.Count;
        for(long i = 0; i < numberOfTrucks; i++)
        {
            Truck truck = trucks.Peek();

            if (truck.Fuel < 0)
            {
                trucks.Dequeue();
                continue;
            }
            else
            {
                truck.Fuel += pump.Petrol - pump.DistanceToNextPump;
                truck.CurrentPoint = pump.Index;
            }

            if(truck.StartingPoint==truck.CurrentPoint)
            {
                truckMadeFullCircle = true;
                return;
            }
            trucks.Enqueue(trucks.Dequeue());
        }

        truckMadeFullCircle = false;
    }

    /// <summary>
    /// Parse an array out of a string without empty entries which can lead to SystemFormatExceptions
    /// </summary>
    /// <returns></returns>
    private static long[] ParseArray() => ReadLine()
        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(long.Parse).ToArray();
}

//Classes for the truck and pumps are used to keep everything neat and easy to understand
class Truck
{
    internal long StartingPoint { get; set; }
    internal long CurrentPoint { get; set; }
    internal long Fuel { get; set; }
    
    internal Truck(long startingPint, long fuel)
    {
        StartingPoint = startingPint;
        CurrentPoint = startingPint;
        Fuel = fuel;
    }
}

class Pump
{
    internal long Index { get; set; }
    internal long Petrol { get; set; }
    internal long DistanceToNextPump { get; set; }

    internal Pump(long index,long petrol, long distanceToNext)
    {
        Index = index;
        Petrol = petrol;
        DistanceToNextPump = distanceToNext;
    }
}