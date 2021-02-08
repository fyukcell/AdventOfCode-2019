using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    class Q3
    {
        public static int Q3A()
        {
            string firstWire = Console.ReadLine();
            string secondWire = Console.ReadLine();

            string[] firstCommands = firstWire.Split(',');
            string[] secondCommands = secondWire.Split(',');
            IList<int[]> firstPoints = new List<int[]>();
            IList<int[]> secondPoints = new List<int[]>();

            firstPoints.Add(new int[] { 0,0, 0 });
            secondPoints.Add(new int[] { 0, 0 , 0});

            for (int i = 0; i < firstCommands.Length; i++)
            {
                if (firstCommands[i].Substring(0,1) == "U")
                {
                    int y = Int32.Parse(firstCommands[i].Substring(1, firstCommands[i].Length - 1));
                    firstPoints.Add(new int[] { firstPoints[firstPoints.Count - 1][0], firstPoints[firstPoints.Count - 1][1] + y, firstPoints[firstPoints.Count - 1][2] + y });
                }

                else if (firstCommands[i].Substring(0, 1) == "D")
                {
                    int y = Int32.Parse(firstCommands[i].Substring(1, firstCommands[i].Length - 1));
                    firstPoints.Add(new int[] { firstPoints[firstPoints.Count - 1][0], firstPoints[firstPoints.Count - 1][1] - y, firstPoints[firstPoints.Count - 1][2] + y });

                }
                else if (firstCommands[i].Substring(0, 1) == "R")
                {
                    int x = Int32.Parse(firstCommands[i].Substring(1, firstCommands[i].Length - 1));
                    firstPoints.Add(new int[] { firstPoints[firstPoints.Count - 1][0] + x, firstPoints[firstPoints.Count - 1][1] , firstPoints[firstPoints.Count - 1][2] + x });

                }
                else if (firstCommands[i].Substring(0, 1) == "L")
                {
                    int x = Int32.Parse(firstCommands[i].Substring(1, firstCommands[i].Length - 1));
                    firstPoints.Add(new int[] { firstPoints[firstPoints.Count - 1][0] - x, firstPoints[firstPoints.Count - 1][1], firstPoints[firstPoints.Count - 1][2] + x });
                }
            
            }

            for (int i = 0; i < secondCommands.Length; i++)
            {
                if (secondCommands[i].Substring(0, 1) == "U")
                {
                    int y = Int32.Parse(secondCommands[i].Substring(1, secondCommands[i].Length - 1));
                    secondPoints.Add(new int[] { secondPoints[secondPoints.Count - 1][0], secondPoints[secondPoints.Count - 1][1] + y, secondPoints[secondPoints.Count - 1][2] + y });
                }

                else if (secondCommands[i].Substring(0, 1) == "D")
                {
                    int y = Int32.Parse(secondCommands[i].Substring(1, secondCommands[i].Length - 1));
                    secondPoints.Add(new int[] { secondPoints[secondPoints.Count - 1][0], secondPoints[secondPoints.Count - 1][1] - y, secondPoints[secondPoints.Count - 1][2] + y });

                }
                else if (secondCommands[i].Substring(0, 1) == "R")
                {
                    int x = Int32.Parse(secondCommands[i].Substring(1, secondCommands[i].Length - 1));
                    secondPoints.Add(new int[] { secondPoints[secondPoints.Count - 1][0] + x, secondPoints[secondPoints.Count - 1][1], secondPoints[secondPoints.Count - 1][2] + x });

                }
                else if (secondCommands[i].Substring(0, 1) == "L")
                {
                    int x = Int32.Parse(secondCommands[i].Substring(1, secondCommands[i].Length - 1));
                    secondPoints.Add(new int[] { secondPoints[secondPoints.Count - 1][0] - x, secondPoints[secondPoints.Count - 1][1], secondPoints[secondPoints.Count - 1][2] + x });
                }

            }

            IList<int[]> intersectionPoints = new List<int[]>();

            for (int i = 0; i < firstPoints.Count - 1; i++)
            {
                for (int j = 0; j < secondPoints.Count - 1; j++)
                {
                    // horizontal intersection
                    if ((firstPoints[i][0] < secondPoints[j][0] && firstPoints[i + 1][0] > secondPoints[j][0])  ||
                        (firstPoints[i][0] > secondPoints[j][0] && firstPoints[i + 1][0] < secondPoints[j][0]))
                    {
                        if ((secondPoints[j][1] < firstPoints[i][1] && secondPoints[j + 1][1] > firstPoints[i][1]) ||
                            (secondPoints[j][1] > firstPoints[i][1] && secondPoints[j + 1][1] < firstPoints[i][1]))
                        {
                            //add to intersection
                            Console.WriteLine("HORIZONTAL INTERSECTION");
                            int horizontalSteps = Math.Abs(secondPoints[j][0] - firstPoints[i][0]);
                            int verticalSteps = Math.Abs(firstPoints[i][1] - secondPoints[j][1]);
                            int total = horizontalSteps + verticalSteps + firstPoints[i][2] + secondPoints[j][2];
                            intersectionPoints.Add(new int[] {secondPoints[j][0]  ,firstPoints[i][1],  total});
                        }

                    }
                    // vertical intersection
                    // horizontal intersection
                    if ((firstPoints[i][1] < secondPoints[j][1] && firstPoints[i + 1][1] > secondPoints[j][1]) ||
                        (firstPoints[i][1] > secondPoints[j][1] && firstPoints[i + 1][1] < secondPoints[j][1]))
                    {
                        if ((secondPoints[j][0] < firstPoints[i][0] && secondPoints[j + 1][0] > firstPoints[i][0]) ||
                            (secondPoints[j][0] > firstPoints[i][0] && secondPoints[j + 1][0] < firstPoints[i][0]))
                        {
                            //add to intersection
                            Console.WriteLine("VERTICAL INTERSECTION");
                            int horizontalSteps = Math.Abs(secondPoints[j][0] - firstPoints[i][0]);
                            int verticalSteps = Math.Abs(firstPoints[i][1] - secondPoints[j][1]);
                            int total = horizontalSteps + verticalSteps + firstPoints[i][2] + secondPoints[j][2];

                            intersectionPoints.Add(new int[] { firstPoints[i][0], secondPoints[j][1], total  });

                        }

                    }
                }
 
            }
            int max = 9999999;
            int minsteps = 999999;
            foreach (int[] point in intersectionPoints)
            {
                if (minsteps > point[2]) minsteps = point[2];
                int temp = Math.Abs(point[0]) + Math.Abs(point[1]);
                if (temp < max)
                {
                    Console.WriteLine(point[0]);
                    Console.WriteLine(point[1]);

                    max = temp;
                }
            }
            Console.WriteLine(minsteps);
            return max;
        }
    }
}
