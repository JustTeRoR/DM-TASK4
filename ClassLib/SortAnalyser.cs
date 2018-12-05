using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class SortAnalyser
    {
        public static int[] MergeSort(int[] arr, ref int n)
        {
            if (arr.Length == 1)
                return arr;
            int mid_point = arr.Length / 2;
            return Merge(MergeSort(arr.Take(mid_point).ToArray(), ref n), MergeSort(arr.Skip(mid_point).ToArray(), ref n), ref n);
        }

        private static int[] Merge(int[] arr1, int[] arr2, ref int n)
        {
            int a = 0, b = 0;
            int[] merged = new int[arr1.Length + arr2.Length];
            for (int i = 0; i < arr1.Length + arr2.Length; i++)
            {
                if (b < arr2.Length && a < arr1.Length)
                {
                    if (arr1[a] > arr2[b])
                    {
                        n++;
                        merged[i] = arr2[b++];
                    }
                    else
                    {
                        n++;
                        merged[i] = arr1[a++];
                    }
                }
                else
                {
                    if (b < arr2.Length)
                    {
                        merged[i] = arr2[b++];
                    }
                    else
                    {
                        merged[i] = arr1[a++];
                    }
                }
            }
            return merged;
        }

        public static int[] QuickSort(int[] arr, int first, int last, ref int n)
        {
            if (first < last)
            {
                int left = first, right = last, middle = arr[(left + right) / 2];
                do
                {
                    while (arr[left] < middle)
                    {
                        n++;
                        left++;
                    }
                    while (arr[right] > middle)
                    {
                        n++;
                        right--;
                    }
                    if (left <= right)
                    {
                        int tmp = arr[left];
                        arr[left] = arr[right];
                        arr[right] = tmp;
                        left++;
                        right--;
                    }
                }
                while (left <= right);
                QuickSort(arr, first, right, ref n);
                QuickSort(arr, left, last, ref n);
            }
            return arr;
        }

        public static void OutputArrToConsole(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
        }
    }
}

