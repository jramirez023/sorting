using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class MergeSort : ISortingAlgorithm
    {
        public int[] Partition(int[] A, int startIndex, int endIndex)
        {
            //TODO #1: return a new array with all elements in A from index startIndex to endIndex (both included): A[startIndex..endIndex]

            int[] particion = new int[endIndex - startIndex + 1];
            int j = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                particion[j] = A[i];
                j++;
            }
            return particion;
        }

        public void MergePartitions(int[] A, int[] leftPartition, int[] rightPartition)
        {
            //TODO #2: Merge in A the two partitions sorting them
            int iL = 0;
            int iR = 0;
            int iM = 0;

            int left = leftPartition.Length;
            int right = rightPartition.Length;

            while (iL < left && iR < right)
            {
                if (leftPartition[iL] <= rightPartition[iR])
                {
                    A[iM] = leftPartition[iL];
                    iL++;
                }
                else
                {
                    A[iM] = rightPartition[iR];
                    iR++;
                }
                iM++;
            }

            while (iL < leftPartition.Length)
            {
                A[iM] = leftPartition[iL];
                iL++;
                iM++;
            }

            while (iR < rightPartition.Length)
            {
                A[iM] = rightPartition[iR];
                iR++;
                iM++;
            }

        }

        public void Sort(int[] A)
        {
            //TODO #3: Implement MergeSort using the methods above
            int left = 0;
            int right = A.Length - 1;
            if (left < right)
            {
                int medio = left + (right - left) / 2;

                int[] parLeft = Partition(A, left, medio);
                Sort(parLeft);
                int[] parRight = Partition(A, medio + 1, right);
                Sort(parRight);

                MergePartitions(A, parLeft, parRight);
            }
        }


        public bool CheckIsCorrect()
        {
            int n = 10;
            int[] A = Utils.CreateIntArray(n);

            Console.WriteLine("1.1 Checking Partition()");
            if (!Utils.IsPartitionCorrect(A, Partition(A, 0, 3), 0, 3))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            if (!Utils.IsPartitionCorrect(A, Partition(A, 1, 1), 1, 1))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            Console.WriteLine("PASSED");
            Console.WriteLine("1.2. Checking MergePartitions()");
            int[] leftPartition = new int[3] { 1, 4, 6 };
            int[] rightPartition = new int[3] { 2, 3, 7 };
            int[] merged = new int[6] { 1, 4, 6, 2, 3, 7 };
            MergePartitions(merged, leftPartition, rightPartition);
            if (!Utils.IsOrdered(merged))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            Console.WriteLine("PASSED");
            return true;
        }
    }
}
