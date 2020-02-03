using System;

namespace Labs
{
    class Program
    {
        static void Main(string[] args)
        {
            IdenticalArrays();
        }

        static void IdenticalArrays()
        {
            bool error = false;
            string str = " ";
            int n = 0, sum = 0, add = 0;
            str = Console.ReadLine();
            var split = str.Split(" ");
            n = split.Length;
            int[] arr1 = new int[n];

            for (int i = 0; i < split.Length; i++)
            {
                add = int.Parse(split[i]);
                arr1[i] = add;
            }

            str = " ";
            str = Console.ReadLine();
            split = str.Split(" ");
            n = split.Length;
            int[] arr2 = new int[n];

            for (int i = 0; i < split.Length; i++)
            {
                arr2[i] = int.Parse(split[i]);
            }

            str = " ";
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    error = true;
                    str = ($"Arrays are not identical. Found difference at {i} index");
                    break;
                }
                sum += arr1[i];
            }

            if (!error)
                str = ($"Arrays are identical. Sum: {sum}");

            Console.WriteLine(str);
        }
    }
}