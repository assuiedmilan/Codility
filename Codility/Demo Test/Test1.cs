using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Codility.Demo_Test
{
    class Solution {
        public int solution(int[] A)
        {
            Array.Sort(A);

            var firstPositiveIndex = Array.FindIndex(A, IsPositive);

            var arrayHasNoPositiveValue = firstPositiveIndex == -1;
            var arrayHasASinglePositiveValue = firstPositiveIndex == A.Length - 1;
            var arrayHasOnlyPositiveValuesAboveOne = firstPositiveIndex!= -1 && A[firstPositiveIndex] > 1;

            if (arrayHasNoPositiveValue)
            {
                return 1;
            }

            if (arrayHasOnlyPositiveValuesAboveOne ||arrayHasASinglePositiveValue)
            {
                return A[firstPositiveIndex] == 1 ? 2:1;
            }

            var previousValue = A[firstPositiveIndex];
            var currentValue = A[firstPositiveIndex+1];
            var index = firstPositiveIndex+2;

            while (IntegersAreConsecutive(previousValue, currentValue) && index < A.Length)
            {
                previousValue = currentValue;
                currentValue = A[index];
                index++;
            }

            if (currentValue - previousValue < 2)
            {
                return currentValue + 1;
            }

            return previousValue + 1;
        }

        private static bool IntegersAreConsecutive(int first, int second)
        {
            return second - first < 2;
        }
        private static bool IsPositive(int i)
        {
            return i >= 0;
        }
    }

    public class Tests
    {
        private Solution s;

        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(new [] {-1000000, 1000000}).Returns(1);
                yield return new TestCaseData(new [] {1}).Returns(2);
                yield return new TestCaseData(new [] {2}).Returns(1);
                yield return new TestCaseData(new [] {50, 54, 46, 34, 102, 199, 299}).Returns(1);
                yield return new TestCaseData(new [] {1, 2, 3}).Returns(4);
                yield return new TestCaseData(new [] {-2, -3, -1}).Returns(1);
                yield return new TestCaseData(new [] {-100000, 100000}).Returns(1);
            }
        }

        [SetUp]
        public void Setup()
        {
            s = new Solution();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public int Test1(int[] testCase)
        {
            return s.solution(testCase);
        }
    }
}