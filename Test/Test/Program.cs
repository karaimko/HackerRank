using System;

namespace Test
{
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Collections;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Text.RegularExpressions;
    using System.Text;
    using System;

    class Solution {

        // Complete the missingNumbers function below.
        static int[] missingNumbers(int[] arr, int[] brr) {
            var list = new List<int>();
            Array.Sort(arr);
            Array.Sort(brr);
            if(arr.Length == 0)
            {
                return brr.Distinct().ToArray();
            }
            int n = brr.Length;
            int cnt1 = 1;
            int cnt2 = 1;
            for(int i=0,j=0;j<n;i++,j++)
            {
                if(arr[i] != brr[j] || cnt1 != cnt2)
                {
                    if (i > 0)
                    {
                        if (arr[i] == arr[i - 1])
                        {
                            cnt1++;
                        }
                        else
                        {
                            cnt1 = 1;
                        }
                    }

                    if (j > 0)
                    {
                        if (brr[j] == brr[j - 1])
                        {
                            cnt2++;
                        }
                        else
                        {
                            cnt2 = 1;
                        }
                    }

                    list.Add(brr[j]);
                    i--;
                }
            }

            var a = list.Distinct().ToArray();
            Array.Sort(a);
            return a;
        }

        static void Main(string[] args)
        {
            int n = 100000;//Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(File.ReadAllText("file1.txt").Split(' '), arrTemp => Convert.ToInt32(arrTemp))
                ;
            int m = 100018;//Convert.ToInt32(Console.ReadLine());

            int[] brr = Array.ConvertAll(File.ReadAllText("file2.txt").Split(' '), brrTemp => Convert.ToInt32(brrTemp))
                ;
            int[] result = missingNumbers(arr, brr);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}