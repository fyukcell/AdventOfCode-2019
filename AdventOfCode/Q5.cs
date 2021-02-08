using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    class Q5
    {
        public static int [] Q5A()
        {
            string input = Console.ReadLine();
            string[] values = input.Split(',');
            int[] intValues = new int[values.Length];

            for (int k = 0; k < values.Length; k++)
            {
                intValues[k] = Int32.Parse(values[k]);
            }

            int i = 0;
            do
            {
                int temp = intValues[i];

                int opcode = temp % 10;
                if (opcode == 9) opcode = temp % 100;
                temp /= 100;
                int modeOne = temp % 10;
                temp /= 10;
                int modeTwo = temp % 10;

                if (opcode == 1 || opcode == 2)
                {
                    int firstParameter = -1;
                    int secondParameter = -1;

                    switch (modeOne)
                    {
                        case 0:
                            firstParameter = intValues[intValues[i + 1]];
                            break;
                        case 1:
                            firstParameter = intValues[i + 1];
                            break;
                    }

                    switch (modeTwo)
                    {
                        case 0:
                            secondParameter = intValues[intValues[i + 2]];
                            break;
                        case 1:
                            secondParameter = intValues[i + 2];
                            break;
                    }

                    switch (opcode)
                    {
                        case 1:
                            intValues[intValues[i + 3]] = firstParameter + secondParameter;
                            break;
                        case 2:
                            intValues[intValues[i + 3]] = firstParameter * secondParameter;
                            break;
                    }

                    i += 4;
                }
                else if (opcode == 3)
                {
                    switch (modeOne)
                    {
                        case 0:
                            intValues[intValues[i + 1]] = Int32.Parse(Console.ReadLine());
                            break;
                        case 1:
                            intValues[i + 1] = Int32.Parse(Console.ReadLine());
                            break;
                    }
                    i += 2;
                }
                else if (opcode == 4)
                {
                    switch (modeTwo) 
                    {
                        case 0:
                            Console.WriteLine(intValues[intValues[i + 1]]);
                            break;
                        case 1:
                            Console.WriteLine(intValues[i + 1]);
                            break;
                    }
                    i += 2;
                }
                else if (opcode == 5)
                {
                    switch (modeOne)
                    {
                        case 0:
                            if (intValues[intValues[i + 1]] != 0)
                            {
                                switch (modeTwo)
                                {
                                    case 0:
                                        i = intValues[intValues[i + 2]];
                                        break;
                                    case 1:
                                        i = intValues[i + 2];
                                        break;
                                }
                            }
                            else
                            {
                                i += 3;
                            }
                            break;
                        case 1:
                            if (intValues[i + 1] != 0)
                            {
                                switch (modeTwo)
                                {
                                    case 0:
                                        i = intValues[intValues[i + 2]];
                                        break;
                                    case 1: 
                                        i = intValues[i + 2]; 
                                        break;
                                }
                            }
                            else
                            {
                                i += 3;
                            }
                            break;
                    }
                }
                else if (opcode == 6)
                {
                    switch (modeOne)
                    {
                        case 0:
                            if (intValues[intValues[i + 1]] == 0)
                            {
                                switch (modeTwo)
                                {
                                    case 0:
                                        i = intValues[intValues[i + 2]];
                                        break;
                                    case 1:
                                        i = intValues[i + 2];
                                        break;
                                }
                            }
                            else
                            {
                                i += 3;
                            }
                            break;
                        case 1:
                            if (intValues[i + 1] == 0)
                            {
                                switch (modeTwo)
                                { 
                                    case 0: 
                                        i = intValues[intValues[i + 2]]; 
                                        break; 
                                    case 1:
                                        i = intValues[i + 2]; 
                                         break;
                                }
                            }
                            else
                            {
                                i += 3;
                            }
                            break;
                    }
                }
                else if (opcode == 7 || opcode == 8)
                {
                    int firstVal = -1;
                    int secondVal = -1;
                    switch (modeOne)
                    { 
                        case 0:
                            firstVal = intValues[intValues[i + 1]];
                            break;
                        case 1: 
                            firstVal = intValues[i + 1];
                            break;
                    }
                    switch (modeTwo)
                    {
                        case 0:
                            secondVal = intValues[intValues[i + 2]];
                            break;
                        case 1:
                            secondVal = intValues[i + 2];
                            break;
                    }

                    switch (opcode)
                    {
                        case 7:
                            if (firstVal < secondVal) intValues[intValues[i + 3]] = 1;
                            else intValues[intValues[i + 3]] = 0;
                            break;
                        case 8:
                            if (firstVal == secondVal) intValues[intValues[i + 3]] = 1;
                            else intValues[intValues[i + 3]] = 0;
                            break;
                    }

                    i += 4;
                }
                else if (opcode == 99)
                {
                    return intValues;
                }
                else
                {
                    throw new ArgumentException();
                }
            } while (i < intValues.Length);

            return intValues;

        }
    }
}
