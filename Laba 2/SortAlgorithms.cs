using System;

namespace Laba_2
{
  public class SortResult
  {
    public string AlgorithmName { get; set; }
    public double[] SortedArray { get; set; }
    public long ElapsedMilliseconds { get; set; }
    public long Iterations { get; set; }

    public SortResult(string algorithmName, double[] sortedArray, long elapsedMilliseconds, long iterations)
    {
      AlgorithmName = algorithmName;
      SortedArray = sortedArray;
      ElapsedMilliseconds = elapsedMilliseconds;
      Iterations = iterations;
    }
  }

  public static class SortAlgorithms
  {
    public static long LastIterations { get; private set; }

    // ========== 1. Пузырьковая ==========
    public static double[] BubbleSort(double[] array, bool ascending)
    {
      double[] result = (double[])array.Clone();
      int n = result.Length;
      long iterations = 0;

      for (int i = 0; i < n - 1; i++)
      {
        for (int j = 0; j < n - i - 1; j++)
        {
          iterations++;
          bool needSwap = ascending ? result[j] > result[j + 1] : result[j] < result[j + 1];

          if (needSwap)
          {
            double temp = result[j];
            result[j] = result[j + 1];
            result[j + 1] = temp;
          }
        }
      }

      LastIterations = iterations;
      return result;
    }

    // ========== 2. Вставками ==========
    public static double[] InsertionSort(double[] array, bool ascending)
    {
      double[] result = (double[])array.Clone();
      int n = result.Length;
      long iterations = 0;

      for (int i = 1; i < n; i++)
      {
        double key = result[i];
        int j = i - 1;

        while (j >= 0)
        {
          iterations++;
          bool needSwap = ascending ? result[j] > key : result[j] < key;

          if (!needSwap) break;

          result[j + 1] = result[j];
          j--;
        }

        result[j + 1] = key;
      }

      LastIterations = iterations;
      return result;
    }

    // ========== 3. Шейкерная ==========
    public static double[] ShakerSort(double[] array, bool ascending)
    {
      double[] result = (double[])array.Clone();
      int left = 0;
      int right = result.Length - 1;
      long iterations = 0;

      while (left < right)
      {
        for (int i = left; i < right; i++)
        {
          iterations++;
          bool needSwap = ascending ? result[i] > result[i + 1] : result[i] < result[i + 1];

          if (needSwap)
          {
            double temp = result[i];
            result[i] = result[i + 1];
            result[i + 1] = temp;
          }
        }
        right--;

        for (int i = right; i > left; i--)
        {
          iterations++;
          bool needSwap = ascending ? result[i - 1] > result[i] : result[i - 1] < result[i];

          if (needSwap)
          {
            double temp = result[i];
            result[i] = result[i - 1];
            result[i - 1] = temp;
          }
        }
        left++;
      }

      LastIterations = iterations;
      return result;
    }

    // ========== 4. Быстрая ==========
    public static double[] QuickSort(double[] array, bool ascending)
    {
      double[] result = (double[])array.Clone();
      long iterations = 0;
      QuickSortRecursive(result, 0, result.Length - 1, ascending, ref iterations);
      LastIterations = iterations;
      return result;
    }

    private static void QuickSortRecursive(double[] array, int low, int high, bool ascending, ref long iterations)
    {
      if (low < high)
      {
        int pivotIndex = Partition(array, low, high, ascending, ref iterations);
        QuickSortRecursive(array, low, pivotIndex - 1, ascending, ref iterations);
        QuickSortRecursive(array, pivotIndex + 1, high, ascending, ref iterations);
      }
    }

    private static int Partition(double[] array, int low, int high, bool ascending, ref long iterations)
    {
      double pivot = array[high];
      int i = low - 1;

      for (int j = low; j < high; j++)
      {
        iterations++;
        bool needSwap = ascending ? array[j] <= pivot : array[j] >= pivot;

        if (needSwap)
        {
          i++;
          double temp = array[i];
          array[i] = array[j];
          array[j] = temp;
        }
      }

      double tempSwap = array[i + 1];
      array[i + 1] = array[high];
      array[high] = tempSwap;

      return i + 1;
    }

    // ========== 5. BOGO (с лимитом итераций) ==========
    public static double[] BogoSort(double[] array, bool ascending, long maxIterations)
    {
      double[] result = (double[])array.Clone();
      Random random = new Random();
      long iterations = 0;

      while (!IsSorted(result, ascending))
      {
        Shuffle(result, random);
        iterations++;

        if (iterations >= maxIterations)
        {
          break;
        }
      }

      LastIterations = iterations;
      return result;
    }

    private static bool IsSorted(double[] array, bool ascending)
    {
      for (int i = 0; i < array.Length - 1; i++)
      {
        if (ascending && array[i] > array[i + 1]) return false;
        if (!ascending && array[i] < array[i + 1]) return false;
      }
      return true;
    }

    private static void Shuffle(double[] array, Random random)
    {
      for (int i = 0; i < array.Length - 1; i++)
      {
        int j = random.Next(i, array.Length);
        double temp = array[i];
        array[i] = array[j];
        array[j] = temp;
      }
    }
  }
}