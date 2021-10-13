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

class MaximumPalindromesResult
{
    private static string str;
    private const int modulo = 1000000007;

    public static void initialize(string s)
    {
        str = s;
    }

    public static int answerQuery(int l, int r)
    {
        long result = 1;
        string curStr = str.Substring(l-1, r-l+1);
    
        var aggr = curStr.ToCharArray().GroupBy(a => a).ToDictionary(s => s.Key, s => s.Count());

        var parElm = aggr.Where(a => a.Value > 1)
        .ToDictionary(a => a.Key, a => (a.Value / 2) * 2);
        
        var oddElm = aggr
        .ToDictionary(s => s.Key, s => s.Value % 2)
        .Where(a => a.Value > 0);
        int maxLength = parElm.Sum(a => a.Value) + oddElm.Count() > 0 ? 1 : 0;

        result = Fact(parElm.Sum(a=>a.Value)/2);
        foreach(int i in parElm.Values.Where(a => a > 2))
        {
            result = result / Fact(i/2);
        }

        if(oddElm.Count() > 0)
        {
            result *= oddElm.Count();
        }
        

    // Return the answer for this query modulo 1000000007.
        return (int)(result % modulo);
    }

    private static long Fact(int i)
    {
        long result = 1;
        for(int j=1;j <= i;j++)
        {
            result *= j;

            if(result > modulo)
            result = result % modulo;
        }
        return result;    
    }

}

class MaximumPalindromes
{
    public static void MainMaximumPalindromes(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        MaximumPalindromesResult.initialize(s);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int l = Convert.ToInt32(firstMultipleInput[0]);

            int r = Convert.ToInt32(firstMultipleInput[1]);

            int result = MaximumPalindromesResult.answerQuery(l, r);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
