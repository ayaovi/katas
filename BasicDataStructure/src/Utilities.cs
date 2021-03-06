using System;

namespace src
{
  public static class Utilities
  {
    public static LinkedList RemoveDuplicates(LinkedList list)
    {
      var pointer1 = list.Head;
      var pointer2 = list.Head.Next;

      while (pointer2 != null)
      {
        if (pointer1.Data != pointer2.Data)
        {
          pointer1.Next = pointer2;
          pointer1 = pointer2;
        }
        pointer2 = pointer2.Next;
      }

      return list;
    }

    public static int[] RangeCopy(this int[] arr, int start, int end)
    {
      var x = new int[end - start + 1];
      for (var i = start; i <= end; i++)
      {
        x[i - start] = arr[i];
      }
      return x;
    }

    public static int[] Merge(int[] arr1, int[] arr2)
    {
      var x = new int[arr1.Length + arr2.Length];
      var i = 0;
      var j = 0;
      while (i < arr1.Length || j < arr2.Length)
      {
        if (i == arr1.Length)
        {
          x[i + j] = arr2[j];
          j++;
        }
        else if (j == arr2.Length)
        {
          x[i + j] = arr1[i];
          i++;
        }
        else if (arr1[i] < arr2[j])
        {
          x[i + j] = arr1[i];
          i++;
        }
        else
        {
          x[i + j] = arr2[j];
          j++;
        }
      }
      return x;
    }

    public static int[] MergeSort(this int[] arr, int left, int right)
    {
      if (right <= left) return arr;
      var middle = (left + right) / 2;
      var sortedFirstHalf = MergeSort(arr.RangeCopy(0, middle - left), 0, middle - left);
      var sortedSecondHalf = MergeSort(arr.RangeCopy(middle - left + 1, right - left), middle - left + 1, right - left);
      return Merge(sortedFirstHalf, sortedSecondHalf);
    }

    public static void Swap(this int[] arr, int index1, int index2)
    {
      var x = arr[index1];
      arr[index1] = arr[index2];
      arr[index2] = x;
    }

    public static int Partition(this int[] arr, int start, int end)
    {
      var i = start - 1;
      var pivot = arr[end];
      for (var j = start; j < end; j++)
      {
        if (arr[j] <= pivot)
        {
          i++;
          arr.Swap(i, j);
        }
      }
      arr.Swap(i + 1, end);
      return i + 1;
    }

    public static void QuickSort(this int[] arr, int start, int end)
    {
      if (start >= end) return;
      var pi = arr.Partition(start, end);
      arr.QuickSort(start, pi - 1);
      arr.QuickSort(pi + 1, end);
    }
  }
}