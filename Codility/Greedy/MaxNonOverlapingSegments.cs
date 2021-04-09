using System;
using System.Linq;

namespace Codility.Greedy
{
    public class MaxNonOverlapingSegments
    {
        public int solution(int[] A, int[] B) {

            if (A.Length == 0 || A.Length == 1)
            {
                return A.Length;
            }

            var segments = A.Zip(B, (first, second) => new {start=first, end=second});
            segments = segments.OrderBy(couple => couple.end);
            var segmentsArray = segments.ToArray();
            var maxCount = 0;

            var currentSeg = segmentsArray[0];
            var currentCount = 1;

            for (var j=1; j<segmentsArray.Length; j++) {
                var comparerSeg = segmentsArray[j];

                if (comparerSeg.start > currentSeg.end) {
                    currentSeg = comparerSeg;
                    currentCount++;
                }
            }

            maxCount = Math.Max(maxCount, currentCount);


            return maxCount;
        }
    }
}