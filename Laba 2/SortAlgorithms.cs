using System;

namespace Laba_2
{
  public class SortResult
  {
    public string AlgorithmName { get; set; }
    public int[] SortedArray { get; set; }
    public long ElapsedMilliseconds { get; set; }

    public SortResult(string algorithmName, int[] sortedArray, long elapsedMilliseconds)
    {
      AlgorithmName = algorithmName;
      SortedArray = sortedArray;
      ElapsedMilliseconds = elapsedMilliseconds;
    }
  }

  public static class SortAlgorithms
  {
    public static int[] BubbleSort(int[] array, bool ascending)
    {
      int[] result = (int[])array.Clone();
      int n = result.Length;

      for (int i = 0; i < n - 1; i++)
      {
        for (int j = 0; j < n - i - 1; j++)
        {
          bool needSwap = ascending ? result[j] > result[j + 1] : result[j] < result[j + 1];
          if (needSwap)
          {
            int temp = result[j];
            result[j] = result[j + 1];
            result[j + 1] = temp;
          }
        }
      }

      return result;
    }

    public static int[] InsertionSort(int[] array, bool ascending)
    {
      int[] result = (int[])array.Clone();
      int n = result.Length;

      for (int i = 1; i < n; i++)
      {
        int key = result[i];
        int j = i - 1;

        while (j >= 0 && (ascending ? result[j] > key : result[j] < key))
        {
          result[j + 1] = result[j];
          j--;
        }

        result[j + 1] = key;
      }

      return result;
    }

    public static int[] ShakerSort(int[] array, bool ascending)
    {
      int[] result = (int[])array.Clone();
      int left = 0;
      int right = result.Length - 1;

      while (left < right)
      {
        for (int i = left; i < right; i++)
        {
          bool needSwap = ascending ? result[i] > result[i + 1] : result[i] < result[i + 1];
          if (needSwap)
          {
            int temp = result[i];
            result[i] = result[i + 1];
            result[i + 1] = temp;
          }
        }
        right--;

        for (int i = right; i > left; i--)
        {
          bool needSwap = ascending ? result[i - 1] > result[i] : result[i - 1] < result[i];
          if (needSwap)
          {
            int temp = result[i];
            result[i] = result[i - 1];
            result[i - 1] = temp;
          }
        }
        left++;
      }

      return result;
    }

    public static int[] QuickSort(int[] array, bool ascending)
    {
      int[] result = (int[])array.Clone();
      QuickSortRecursive(result, 0, result.Length - 1, ascending);
      return result;
    }

    private static void QuickSortRecursive(int[] array, int low, int high, bool ascending)
    {
      if (low < high)
      {
        int pivotIndex = Partition(array, low, high, ascending);
        QuickSortRecursive(array, low, pivotIndex - 1, ascending);
        QuickSortRecursive(array, pivotIndex + 1, high, ascending);
      }
    }

    private static int Partition(int[] array, int low, int high, bool ascending)
    {
      int pivot = array[high];
      int i = low - 1;

      for (int j = low; j < high; j++)
      {
        bool needSwap = ascending ? array[j] <= pivot : array[j] >= pivot;
        if (needSwap)
        {
          i++;
          int temp = array[i];
          array[i] = array[j];
          array[j] = temp;
        }
      }

      int tempSwap = array[i + 1];
      array[i + 1] = array[high];
      array[high] = tempSwap;

      return i + 1;
    }

    public static int[] BogoSort(int[] array, bool ascending)
    {
      int[] result = (int[])array.Clone();
      Random random = new Random();

      int maxLength = Math.Min(result.Length, 8);

      while (!IsSorted(result, ascending, maxLength))
      {
        Shuffle(result, maxLength, random);
      }

      return result;
    }

    private static bool IsSorted(int[] array, bool ascending, int length)
    {
      for (int i = 0; i < length - 1; i++)
      {
        if (ascending && array[i] > array[i + 1]) return false;
        if (!ascending && array[i] < array[i + 1]) return false;
      }
      return true;
    }

    private static void Shuffle(int[] array, int length, Random random)
    {
      for (int i = 0; i < length - 1; i++)
      {
        int j = random.Next(i, length);
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
      }
    }
  }
}