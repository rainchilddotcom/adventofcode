using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "input.txt"));
            var readings = lines.Select(x => Convert.ToInt32(x)).ToList();

            Part1(readings);
            Part2(readings);
        }

        /* Part 1
        
        As the submarine drops below the surface of the ocean, it automatically performs a sonar sweep of the nearby sea floor. On a small screen, the sonar sweep report (your puzzle input) appears: each line is a measurement of the sea floor depth as the sweep looks further and further away from the submarine.

        For example, suppose you had the following report:

        199
        200
        208
        210
        200
        207
        240
        269
        260
        263
        This report indicates that, scanning outward from the submarine, the sonar sweep found depths of 199, 200, 208, 210, and so on.

        The first order of business is to figure out how quickly the depth increases, just so you know what you're dealing with - you never know if the keys will get carried into deeper water by an ocean current or a fish or something.

        To do this, count the number of times a depth measurement increases from the previous measurement. (There is no measurement before the first measurement.) In the example above, the changes are as follows:

        199 (N/A - no previous measurement)
        200 (increased)
        208 (increased)
        210 (increased)
        200 (decreased)
        207 (increased)
        240 (increased)
        269 (increased)
        260 (decreased)
        263 (increased)
        In this example, there are 7 measurements that are larger than the previous measurement.

        How many measurements are larger than the previous measurement?
        */
        static void Part1(List<int> readings)
        { 
            int previous = readings[0];
            int equals = -1; // because the first one will always equal... hacky ho
            int increases = 0;
            int decreases = 0;

            foreach (int reading in readings)
            {
                if (reading > previous)
                {
                    Console.WriteLine($"Reading {reading} greater than previous.");
                    increases++;
                }
                else if (reading < previous)
                {
                    Console.WriteLine($"Reading {reading} less than previous.");
                    decreases++;
                }
                else
                {
                    Console.WriteLine($"Reading {reading} equals previous.");
                    equals++;
                }

                previous = reading;
            }

            Console.WriteLine();
            Console.WriteLine($"Increases: {increases}, Decreases: {decreases}, Equals: {equals}" );
            Console.WriteLine("Press the any key...");
            Console.ReadKey();
        }

        /* Part 2
        Considering every single measurement isn't as useful as you expected: there's just too much noise in the data.

        Instead, consider sums of a three-measurement sliding window. Again considering the above example:

        199  A      
        200  A B    
        208  A B C  
        210    B C D
        200  E   C D
        207  E F   D
        240  E F G  
        269    F G H
        260      G H
        263        H
        Start by comparing the first and second three-measurement windows. The measurements in the first window are marked A (199, 200, 208); their sum is 199 + 200 + 208 = 607. The second window is marked B (200, 208, 210); its sum is 618. The sum of measurements in the second window is larger than the sum of the first, so this first comparison increased.

        Your goal now is to count the number of times the sum of measurements in this sliding window increases from the previous sum. So, compare A with B, then compare B with C, then C with D, and so on. Stop when there aren't enough measurements left to create a new three-measurement sum.

        In the above example, the sum of each three-measurement window is as follows:

        A: 607 (N/A - no previous sum)
        B: 618 (increased)
        C: 618 (no change)
        D: 617 (decreased)
        E: 647 (increased)
        F: 716 (increased)
        G: 769 (increased)
        H: 792 (increased)
        In this example, there are 5 sums that are larger than the previous sum.

        Consider sums of a three-measurement sliding window. How many sums are larger than the previous sum?
        */
        static void Part2(List<int> readings)
        {
            const int windowSize = 3;

            int previous = GetSlidingWindowResult(readings, 0, windowSize);
            int equals = -1; // because the first one will always equal... hacky ho
            int increases = 0;
            int decreases = 0;

            for (int offset = 0; offset <= readings.Count - windowSize; offset++)
            {
                int reading = GetSlidingWindowResult(readings, offset, windowSize);

                if (reading > previous)
                {
                    Console.WriteLine($"Reading {reading} greater than previous.");
                    increases++;
                }
                else if (reading < previous)
                {
                    Console.WriteLine($"Reading {reading} less than previous.");
                    decreases++;
                }
                else
                {
                    Console.WriteLine($"Reading {reading} equals previous.");
                    equals++;
                }

                previous = reading;
            }

            Console.WriteLine();
            Console.WriteLine($"Increases: {increases}, Decreases: {decreases}, Equals: {equals}");
            Console.WriteLine("Press the any key...");
            Console.ReadKey();
        }

        static int GetSlidingWindowResult(List<int> readings, int offset, int length)
        {
            int sum = 0;
            for (int i = offset; i < offset + length; i++)
            {
                sum += readings[i];
            }
            return sum;
        }
    }
}
