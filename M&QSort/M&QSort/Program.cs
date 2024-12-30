using System;
using System.Diagnostics;

class SortingAndSearching
{
    static void Main()
    {
        // Step 1: Input Array
        Console.Write("Enter the number of elements: ");
        int n = int.Parse(Console.ReadLine());

        int[] array = new int[n];
        Console.WriteLine("Enter the elements of the array:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Element {i + 1}: ");
            array[i] = int.Parse(Console.ReadLine());
        }

        // Step 2: Clone array for comparison
        int[] mergeSortArray = (int[])array.Clone();
        int[] quickSortArray = (int[])array.Clone();

        // Step 3: Perform Merge Sort and Measure Time
        Stopwatch stopwatch = Stopwatch.StartNew();
        MergeSort(mergeSortArray, 0, mergeSortArray.Length - 1);
        stopwatch.Stop();
        Console.WriteLine($"\nMerge Sort Time: {stopwatch.ElapsedMilliseconds} ms");

        // Step 4: Perform Quick Sort and Measure Time
        stopwatch.Restart();
        QuickSort(quickSortArray, 0, quickSortArray.Length - 1);
        stopwatch.Stop();
        Console.WriteLine($"Quick Sort Time: {stopwatch.ElapsedMilliseconds} ms");

        // Step 5: Output Sorted Arrays
        Console.WriteLine("\nSorted Array (Merge Sort): " + string.Join(", ", mergeSortArray));
        Console.WriteLine("Sorted Array (Quick Sort): " + string.Join(", ", quickSortArray));

        // Step 6: Binary Search
        Console.Write("\nEnter a number to search: ");
        int target = int.Parse(Console.ReadLine());

        int index = BinarySearch(mergeSortArray, target);
        if (index != -1)
        {
            Console.WriteLine($"Number found at index {index} (0-based index)");
        }
        else
        {
            Console.WriteLine("Number not found.");
        }
    }

    // Merge Sort
    static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSort(array, left, mid);
            MergeSort(array, mid + 1, right);

            Merge(array, left, mid, right);
        }
    }

    static void Merge(int[] array, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        for (int i = 0; i < n1; i++)
            leftArray[i] = array[left + i];

        for (int i = 0; i < n2; i++)
            rightArray[i] = array[mid + 1 + i];

        int iLeft = 0, iRight = 0, k = left;

        while (iLeft < n1 && iRight < n2)
        {
            if (leftArray[iLeft] <= rightArray[iRight])
            {
                array[k] = leftArray[iLeft];
                iLeft++;
            }
            else
            {
                array[k] = rightArray[iRight];
                iRight++;
            }
            k++;
        }

        while (iLeft < n1)
        {
            array[k] = leftArray[iLeft];
            iLeft++;
            k++;
        }

        while (iRight < n2)
        {
            array[k] = rightArray[iRight];
            iRight++;
            k++;
        }
    }

    // Quick Sort
    static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(array, low, high);

            QuickSort(array, low, pi - 1);
            QuickSort(array, pi + 1, high);
        }
    }

    static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = (low - 1);

        for (int j = low; j < high; j++)
        {
            if (array[j] <= pivot)
            {
                i++;
                (array[i], array[j]) = (array[j], array[i]);
            }
        }

        (array[i + 1], array[high]) = (array[high], array[i + 1]);
        return i + 1;
    }

    // Binary Search
    static int BinarySearch(int[] array, int target)
    {
        int left = 0, right = array.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (array[mid] == target)
                return mid;
            else if (array[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
}
