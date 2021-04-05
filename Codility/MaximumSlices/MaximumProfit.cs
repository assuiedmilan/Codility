using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Codility.MaximumSlices
{
    public class MaximumProfit
    {
        public int solution(int[] A)
        {
            int myMaxProfit = 0;

            MaximumSlice computer = new MaximumSlice();

            if (A.Length != 0 && A.Length != 1)
            {
                var tableOfProfits = new int[A.Length - 1];

                for (int i = 0; i < A.Length - 1; i++)
                {
                    tableOfProfits[i] = A[i + 1] - A[i];
                }

                myMaxProfit = computer.solution(tableOfProfits);
            }

            return myMaxProfit;
        }
    }

    public class TestsMaximumProfit
    {
        private MaximumProfit _instance;

        public static IEnumerable<TestCaseData> TestCases
        {

            get
            {
                yield return new TestCaseData(new[] {100, 200, 300, 400, 500}, 400);
                yield return new TestCaseData(new[] {-100, -200, -300, -400, -500}, 0);
                yield return new TestCaseData(new [] {23171, 21011, 21123, 21366, 21013, 21367}, 356);
                yield return new TestCaseData(Array.Empty<int>(), 0);
                yield return new TestCaseData(new [] {1}, 0);
            }
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void Test1(int[] testArray, int expectedValue)
        {
            _instance = new MaximumProfit();
            Assert.AreEqual(expectedValue,  _instance.solution(testArray));

        }
    }
}