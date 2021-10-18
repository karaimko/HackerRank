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

class MatrixRotationResult
{

    public static void matrixRotation(List<List<int>> matrix, int r)
    {
        var rolled = RollUp(matrix);

        var rotated = new List<List<int>>();

        foreach (var l in rolled)
        {
            rotated.Add(RotateList(l, r));
        }

        var result = RollBack(rotated, matrix[0].Count, matrix.Count);

        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < matrix[i].Count; j++)

                Console.Write($"{result[i,j]} ");

            Console.Write(Environment.NewLine);
        }
 
    }

    public static List<int> RotateList(List<int> list, int r)
    {
        int len = list.Count;
        r = r % len;
        var result = new List<int>();

        for (int i = 0; i < len; i++)
        {
            result.Add(list[(r+i)%len]);
        }
        return result;
    }

    public static List<List<int>> RollUp(List<List<int>> matrix)
    {
        var result = new List<List<int>>();
        int len = matrix[0].Count;
        int high = matrix.Count;
        int n = Math.Min(len, high) / 2;
        for (int i = 0; i < n; i++)
        {
            var row = new List<int>();
            for (int j = i; j < len - i; j++)
                row.Add(matrix[i][j]);

            for (int j = i + 1; j < high - i - 1; j++)
                row.Add(matrix[j][len - i - 1]);

            for (int j = len - i - 1; j >= i; j--)
                row.Add(matrix[high-1-i][j]);

            for (int j = high - i - 2;j >= i + 1 ; j--)
                row.Add(matrix[j][i]);

            result.Add(row);
        }

        return result;
    }
    public static int[,] RollBack(List<List<int>> matrix, int len, int high)
    {
        var result = new List<List<int>>();
        int n = Math.Min(len, high) / 2;

        int[,] mtr = new int[high, len];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < matrix[i].Count; j++)
            {
                if (j < len - 2 * i)
                {
                    mtr[i, j + i] = matrix[i][j];
                }
                else if (j < matrix[i].Count / 2)
                {
                    mtr[i + j - len + 2 * i + 1, len - i - 1] = matrix[i][j];
                }
                else if (j < matrix[i].Count - high + 2*i + 2)
                {
                    mtr[high - i - 1, len - i - j + matrix[i].Count / 2 - 1] = matrix[i][j];
                }
                else
                {
                    mtr[matrix[i].Count - j + i, i] = matrix[i][j];
                }
            }
        }

        return mtr;
    }

}

class MatrixRotation
{
    public static void MatrixRotationMain(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(firstMultipleInput[0]);

        int n = Convert.ToInt32(firstMultipleInput[1]);

        int r = Convert.ToInt32(firstMultipleInput[2]);

        List<List<int>> matrix = new List<List<int>>();

        for (int i = 0; i < m; i++)
        {
            matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
        }

        MatrixRotationResult.matrixRotation(matrix, r);
    }
}
