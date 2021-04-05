using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

/*
A non-empty array A consisting of N integers is given. The consecutive elements of array A represent consecutive cars on a road.

Array A contains only 0s and/or 1s:

        0 represents a car traveling east,
        1 represents a car traveling west.

The goal is to count passing cars. We say that a pair of cars (P, Q), where 0 ≤ P < Q < N, is passing when P is traveling to the east and Q is traveling to the west.

For example, consider array A such that:
  A[0] = 0
  A[1] = 1
  A[2] = 0
  A[3] = 1
  A[4] = 1

We have five pairs of passing cars: (0, 1), (0, 3), (0, 4), (2, 3), (2, 4).

Write a function:

    class Solution { public int solution(int[] A); }

that, given a non-empty array A of N integers, returns the number of pairs of passing cars.

The function should return −1 if the number of pairs of passing cars exceeds 1,000,000,000.

For example, given:
  A[0] = 0
  A[1] = 1
  A[2] = 0
  A[3] = 1
  A[4] = 1

the function should return 5, as explained above.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [1..100,000];
        each element of array A is an integer that can have one of the following values: 0, 1.
 */
namespace Codility.PrefixSums
{
    public class PassingCars
    {
        public int solution(int[] A)
        {
            if (A.Length == 0 || A.Length == 1) {
                return 0;
            }

            var prefixSum = Enumerable.Range(0, A.Length+1).ToArray();
            var westBoundCards = new List<int>();
            var crossCount = 0;

            for (int i = 0; i < A.Length; i++)
            {
                prefixSum[i + 1] = A[i] + prefixSum[i];

                if (A[i] == 0) {
                    westBoundCards.Add(i);
                }
            }

            var numberOfWestBoundCars = westBoundCards.Count();

            if (numberOfWestBoundCars == 0 || numberOfWestBoundCars == A.Length) {
                return 0;
            }

            foreach(var westBoundCarIndex in westBoundCards) {
                crossCount += prefixSum[prefixSum.Length-1] - prefixSum[westBoundCarIndex];
            }
            return crossCount;
        }
    }

    public class TestPassingCars
    {
        private PassingCars _instance;

        public static IEnumerable<TestCaseData> TestCases
        {

            get
            {
                yield return new TestCaseData(Array.Empty<int>()).Returns(0);
                yield return new TestCaseData(new[] {0, 1, 0, 1, 1}).Returns(5);
                yield return new TestCaseData(new[] {1}).Returns(0);
                yield return new TestCaseData(new[] {0}).Returns(0);
                yield return new TestCaseData(new[] {0, 1}).Returns(1);
                yield return new TestCaseData(new[] {1, 0}).Returns(0);
                yield return new TestCaseData(new[] {0, 0, 1}).Returns(2);
                yield return new TestCaseData(new[] {1,1,1,0}).Returns(0);
            }
        }

        [SetUp]
        public void Setup()
        {
            _instance = new PassingCars();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public int Test1(int[] s)
        {
            return _instance.solution(s);
        }
    }
}