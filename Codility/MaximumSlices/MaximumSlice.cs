using System;

namespace Codility.MaximumSlices
{
    public class MaximumSlice
    {
        public int solution(int[] A)
        {
            int globalMaxSum = 0;
            int localMaxSum = 0;

            for (int i = 0; i < A.Length; i++)
            {
                localMaxSum = Math.Max(A[i], localMaxSum + A[i]);
                globalMaxSum = Math.Max(localMaxSum, globalMaxSum);
            }

            return globalMaxSum;
        }
    }
}