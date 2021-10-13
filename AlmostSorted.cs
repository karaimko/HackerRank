using System.Collections.Generic;
using System.Linq;
using System;

class almostSortedResult
{

    public static void almostSorted(List<int> list)
    {
        int[] arr = list.ToArray();
        // check sorted
        if (CheckSorted(arr))
        {
            Console.WriteLine("yes");
            return;
        }
        // check swap
        if (!CheckSwap(arr))
        {
            // check reverse
            if (!CheckReverse(arr))
            {
                Console.WriteLine("no");
            }
        }
 
    }

    public static bool CheckSortedWithSwap(int[] arr, int l, int r)
    {
        // swap
        var swp = arr[l];
        arr[l] = arr[r];
        arr[r] = swp;

        bool result = CheckSorted(arr);

        // unswap
        swp = arr[l];
        arr[l] = arr[r];
        arr[r] = swp;

        return result;
    }

    public static bool CheckSorted(int[] arr)
    {
        int cur = arr[0];
        for (int i = 0; i < arr.Length; i++)
        {
            if (cur > arr[i])
            {
                return false;
            }
            cur = arr[i];
        }
        return true;
    }
    public static bool CheckSwap(int[] arr)
    {
        int prev = arr[0];
        int start = 0;
        int end = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (start > 0 && prev > arr[i])
            {
                if (i - start == 1)
                {
                    if (CheckSortedWithSwap(arr, start, i))
                    {
                        Console.WriteLine("yes");
                        Console.WriteLine($"swap {start + 1} {i + 1}");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    end = i - 1;
                    if (CheckSortedWithSwap(arr, start, end))
                    {
                        Console.WriteLine("yes");
                        Console.WriteLine($"swap {start + 1} {end + 1}");
                        return true;
                    }
                    else if (CheckSortedWithSwap(arr, start-1, end))
                    {
                        Console.WriteLine("yes");
                        Console.WriteLine($"swap {start} {end + 1}");
                        return true;
                    }
                    else if (CheckSortedWithSwap(arr, start, end+1))
                    {
                        Console.WriteLine("yes");
                        Console.WriteLine($"swap {start+1} {end + 2}");
                        return true;
                    }
                    else if (CheckSortedWithSwap(arr, start-1, end + 1))
                    {
                        Console.WriteLine("yes");
                        Console.WriteLine($"swap {start} {end + 2}");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (prev > arr[i] && start == 0)
            {
                start = i;
            }
            prev = arr[i];
        }
        if(start > 0 && start == arr.Length-1 && CheckSortedWithSwap(arr,start-1, start))
        {
            Console.WriteLine("yes");
            Console.WriteLine($"swap {start} {start + 1}");
            return true;
        }
        return false;
    }

    public static bool CheckReverse(int[] arr)
    {
        int prev = arr[0];
        int start = 0;
        int end = 0;
        bool ssIsSet = false;

        for (int i = 0; i < arr.Length; i++)
        {
            if (start > 0 && prev < arr[i] && !ssIsSet)
            {
                if (start - 1 > 1 && arr[start - 2] > arr[i - 1])
                {
                    return false;
                }
                else if (arr[i] < arr[start - 1])
                {
                    return false;
                }
                else if(start-1 > 1 && arr[start-2] > arr[i])
                {
                    return false;
                }
                end = i - 1;
                ssIsSet = true;
            }
            if (prev > arr[i] && start == 0 && !ssIsSet)
            {
                start = i;
            }

            if (prev > arr[i] && ssIsSet)
            {
                return false;
            }
            prev = arr[i];
        }

        if (ssIsSet)
        {
            Console.WriteLine("yes");
            Console.WriteLine((start == end ? "swap" : "reverse") + $" {start} {end+1}");
            return true;
        }
        else if(start > 0)
        {
            Console.WriteLine("yes");
            Console.WriteLine($"reverse {start} {arr.Length}");
            return true;
        }
        else
        {
            return false;
        }
    }

}

class almostSorted
{
    public static void MainAlmostSorted(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        almostSortedResult.almostSorted(arr);
    }
}
