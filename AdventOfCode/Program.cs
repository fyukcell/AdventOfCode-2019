using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "1") Console.WriteLine(Q1());
            else if (args[0] == "2a") Console.WriteLine(String.Join(",",Q21()));
            else if (args[0] == "2b") Console.WriteLine(String.Join(",", Q22()));
            else if (args[0] == "3a") Console.WriteLine(Q3.Q3A());
            else if (args[0] == "4") Console.WriteLine(Q4.Q4A());
            else if (args[0] == "5") Console.WriteLine(String.Join(",", Q5.Q5A()));
            else if (args[0] == "6") Console.WriteLine(Q6.Q6A());

        }


        public static float Q1()
        {
            float totalFuel = 0;
            String input;
            do
            {
                input = Console.ReadLine();
                if (input != "")
                {
                    float mass = Int32.Parse(input);
                    float fuelMass = (float)(Math.Floor(mass / 3) - 2);
                    while (fuelMass > 0)
                    {
                        totalFuel += fuelMass;
                        fuelMass = (float)(Math.Floor(fuelMass / 3) - 2);
                    }
                    
                }
              
            } while (input != "");

            return totalFuel;
        }

        public static int [] Q21()
        {
            string input = Console.ReadLine();
            string [] values = input.Split(',');
            int[] intValues = new int[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                intValues[i] = Int32.Parse(values[i]);
            }

            for (int i = 0; i < intValues.Length; i += 4)
            { 
                
                if (intValues[i] == 1)
                {
                    int first = intValues[intValues[i + 1]];
                    int second = intValues[intValues[i + 2]];
                    intValues[intValues[i + 3]] = first + second;
                }
                else if (intValues[i] == 2)
                {
                    int first = intValues[intValues[i + 1]];
                    int second = intValues[intValues[i + 2]];
                    intValues[intValues[i + 3]] = first * second;
                }
                else if (intValues[i] == 99)
                {
                    return intValues;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            return intValues;


        }
        public static int[] Q22()
        {                      

            string input = Console.ReadLine();
            string[] values = input.Split(',');
            int[] intValues = new int[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                intValues[i] = Int32.Parse(values[i]);
            }

            int[] baseCase = intValues;

            for (int noun = 0; noun <= 99; noun++) 
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        intValues[i] = Int32.Parse(values[i]);
                    }

                    if (intValues[0] == 19690720)
                    {
                        return intValues;
                    }
                    else
                    {
                        intValues[1] = noun;
                        intValues[2] = verb;
                        

                        for (int i = 0; i < intValues.Length; i += 4)
                        {

                            if (intValues[i] == 1)
                            {
                                int first = intValues[intValues[i + 1]];
                                int second = intValues[intValues[i + 2]];
                                intValues[intValues[i + 3]] = first + second;
                            }
                            else if (intValues[i] == 2)
                            {
                                int first = intValues[intValues[i + 1]];
                                int second = intValues[intValues[i + 2]];
                                intValues[intValues[i + 3]] = first * second;
                            }
                            else if (intValues[i] == 99)
                            {
                                if (intValues[0] == 19690720) return intValues;
                                else break;
                            }
                            else
                            {
                                if (intValues[0] == 19690720) return intValues;
                                else break;
                            }
                        }
                    }
                }
                
            }
            

            return intValues;


        }
    }


}
