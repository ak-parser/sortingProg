using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class Sorter
    {
        public static void QuickSort<T>(T[] array, Comparison<T> comparer, int length, Predicate<T>? predicate, bool descending = false) where T : notnull
        {
            if (comparer == null)
                throw new ArgumentNullException("Comparer cannot be null");

            if (predicate != null)
            {
                T[] result = array.Where(elem => !predicate(elem)).ToArray();
                T[] other = array.Where(elem => predicate(elem)).ToArray();

                QuickSort<T>(result, 0, result.Length - 1, comparer, descending);

                for (int i = 0; i < result.Length; i++)
                    array[i] = result[i];
                for (int i = 0; i < other.Length; i++)
                    array[i + result.Length] = other[i];
            }
            else
                QuickSort<T>(array, 0, length - 1, comparer, descending);
        }

        private static void QuickSort<T>(T[] array, int left, int right, Comparison<T> comparer, bool descending) where T : notnull
        {
            T temp = array[left + ((right - left) / 2)];
            int i = left, j = right;

            while (i <= j)
            {
                if (!descending)
                {
                    while (comparer(array[i], temp) < 0)
                        i++;
                    while (comparer(array[j], temp) > 0)
                        j--;
                }
                else
                {
                    while (comparer(array[i], temp) > 0)
                        i++;
                    while (comparer(array[j], temp) < 0)
                        j--;
                }

                if (i <= j)
                {
                    (array[i], array[j]) = (array[j], array[i]);
                    i++;
                    j--;
                }
            }

            if (j > left)
                QuickSort<T>(array, left, j, comparer, descending);
            if (i < right)
                QuickSort<T>(array, i, right, comparer, descending);
        }

        public static void HeapSort<T>(T[] array, Comparison<T> comparer, int length, Predicate<T> predicate, bool descending = false) where T : notnull
        {
            if (comparer == null)
                throw new ArgumentNullException("Comparer cannot be null");

            if (predicate != null)
            {
                T[] result = array.Where(elem => !predicate(elem)).ToArray();
                T[] other = array.Where(elem => predicate(elem)).ToArray();

                for (int i = result.Length / 2 - 1; i >= 0; i--)
                    Heapify(result, i, result.Length, comparer, descending);

                for (int i = result.Length - 1; i > 0; i--)
                {
                    (result[0], result[i]) = (result[i], result[0]);
                    Heapify(result, 0, i, comparer, descending);
                }

                for (int i = 0; i < result.Length; i++)
                    array[i] = result[i];
                for (int i = 0; i < other.Length; i++)
                    array[i + result.Length] = other[i];
            }
            else
            {
                for (int i = length / 2 - 1; i >= 0; i--)
                    Heapify(array, i, length, comparer, descending);

                for (int i = length - 1; i > 0; i--)
                {
                    (array[0], array[i]) = (array[i], array[0]);
                    Heapify(array, 0, i, comparer, descending);
                }
            }
        }

        private static void Heapify<T>(T[] array, int index, int length, Comparison<T> comparer, bool descending = false) where T: notnull
        {
            int largest = index;
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            if (!descending)
            {
                if (left < length && comparer(array[left], array[largest]) > 0)
                    largest = left;

                if (right < length && comparer(array[right], array[largest]) > 0)
                    largest = right;
            }
            else
            {
                if (left < length && comparer(array[left], array[largest]) < 0)
                    largest = left;

                if (right < length && comparer(array[right], array[largest]) < 0)
                    largest = right;
            }

            if (largest != index)
            {
                (array[index], array[largest]) = (array[largest], array[index]);
                Heapify(array, largest, length, comparer, descending);
            }
        }
    }
}
