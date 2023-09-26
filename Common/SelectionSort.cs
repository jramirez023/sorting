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
