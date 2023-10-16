using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class SelectionSort : ISortingAlgorithm
    {
        public void Sort(int[] A)
        {
            //TODO #1: Implement SelectionSort

            int length = A.Length;

            for (int i = 0; i < length - 1; i++)
            {

                int min_in = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (A[j] < A[min_in])
                        min_in = j;
                }

                Utils.Swap(A, min_in, i);
            }


        }
        public bool CheckIsCorrect()
        {
            int n = 10;
            int[] A = Utils.CreateIntArray(n);

            Console.WriteLine("1.1 Checking Sort()");
            Sort(A);
            if (!Utils.IsOrdered(A))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            Console.WriteLine("PASSED");
            return true;
        }
    }
}
