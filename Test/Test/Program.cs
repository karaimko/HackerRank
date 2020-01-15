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

        // Complete the maximumSum function below.
        static long maximumSum(long[] a, long m) {
            long w = m-1;
            int n = a.Length;
            long[,] arr = new long[w+1,n+1];

            for(int i = 0;i < n; i++)
            {
                a[i] = a[i] % m;
            }

            for(int i = 0;i < w+1;i++)
            {
                arr[i,0] = 0;
            }
            for(int j = 0;j < n+1;j++)
            {
                arr[0,j] = 0;
            }
            for(int i = 1; i<n+1; i++)
            {
                for(int j = 0; j < w+1; j++)
                {
                    arr[j,i] = arr[j,i-1];
                    if(a[i-1] <= j)
                    {
                        arr[j,i] = Math.Max(arr[j,i] % m, (arr[j-a[i-1], i-1] + a[i-1]) % m);
                    }
                }
            }

            return arr[w,n];

        }

        static void Main(string[] args) {

            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++) {
                string[] nm = Console.ReadLine().Split(' ');

                int n = Convert.ToInt32(nm[0]);

                long m = Convert.ToInt64(nm[1]);

                long[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt64(aTemp))
                    ;
                long result = maximumSum(a, m);

                Console.WriteLine(result);
            }
            
        }
    }

}