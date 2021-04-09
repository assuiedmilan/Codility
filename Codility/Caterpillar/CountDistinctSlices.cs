using System;
using System.Collections.Generic;
using NUnit.Framework;

/*


An integer M and a non-empty array A consisting of N non-negative integers are given. All integers in array A are less than or equal to M.

A pair of integers (P, Q), such that 0 ≤ P ≤ Q < N, is called a slice of array A. The slice consists of the elements A[P], A[P + 1], ..., A[Q]. A distinct slice is a slice consisting of only unique numbers. That is, no individual number occurs more than once in the slice.

For example, consider integer M = 6 and array A such that:
    A[0] = 3
    A[1] = 4
    A[2] = 5
    A[3] = 5
    A[4] = 2

There are exactly nine distinct slices: (0, 0), (0, 1), (0, 2), (1, 1), (1, 2), (2, 2), (3, 3), (3, 4) and (4, 4).

The goal is to calculate the number of distinct slices.

Write a function:

    class Solution { public int solution(int M, int[] A); }

that, given an integer M and a non-empty array A consisting of N integers, returns the number of distinct slices.

If the number of distinct slices is greater than 1,000,000,000, the function should return 1,000,000,000.

For example, given integer M = 6 and array A such that:
    A[0] = 3
    A[1] = 4
    A[2] = 5
    A[3] = 5
    A[4] = 2

the function should return 9, as explained above.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [1..100,000];
        M is an integer within the range [0..100,000];
        each element of array A is an integer within the range [0..M].


*/

namespace Codility.Caterpillar
{
    class CountDistinctSlices {

        private readonly int billion = 1000000000;

        public int solution(int M, int[] A) {

            var result = 0;
            var currentSliceState = new int[M+1];
            var startOfSlice = 0;

            for(int i=0; i<A.Length; i++) {

                var currentValue = A[i];

                Console.WriteLine($"Checking slice between {startOfSlice} and {i}");
                if(currentSliceState[currentValue] == 1) {
                    currentSliceState[A[startOfSlice]] = 0;
                    startOfSlice++;
                    i--;
                }
                else {
                    currentSliceState[currentValue] = 1;
                    result += i - startOfSlice +1;
                }

                if (result >= billion) {
                    result = billion;
                    break;
                }
            }

            return result;
        }


    }

    public class TestCountDistinctSlices
    {
        private CountDistinctSlices _instance;

        public static IEnumerable<TestCaseData> TestCases
        {

            get
            {
                yield return new TestCaseData(0, new []{0, 1}).Returns(2);
            }
        }

        [SetUp]
        public void Setup()
        {
            _instance = new CountDistinctSlices();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public int Test1(int M, int[] A)
        {
            return _instance.solution(M, A);
        }
    }
}