using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Codility.Arrays
{
    public class OddValue
    {
        public int solution(int[] A)
        {
            if (A.Length == 0)
            {
                return -1;
            }

            if (A.Length == 1)
            {
                return A[0];
            }

            Array.Sort(A);
            int i;

            for (i = 0; i < A.Length; i += 2)
            {
                if (i+1 == A.Length || A[i] != A[i + 1])
                {
                    break;
                }
            }

            return A[i];
        }
    }

    public class TestOddValue
    {
        private OddValue _instance;

        public static IEnumerable<TestCaseData> TestCases
        {

            get
            {
                yield return new TestCaseData(new int[0]).Returns(-1);
                yield return new TestCaseData(new[] {1}).Returns(1);
                yield return new TestCaseData(new[] {1, 2, 2}).Returns(1);
                yield return new TestCaseData(new[] {2, 1, 2}).Returns(1);
                yield return new TestCaseData(new[] {2, 2, 1}).Returns(1);
                yield return new TestCaseData(new[] {2, 2, 2}).Returns(2);
                yield return new TestCaseData(new[] {2, 2, 3}).Returns(3);
                yield return new TestCaseData(new[] {2, 3, 2}).Returns(3);
                yield return new TestCaseData(new[] {3, 2, 2}).Returns(3);
                yield return new TestCaseData(new[] {9,3,9,3,9,7,9}).Returns(7);
                yield return new TestCaseData(new[] {9,3,9,7,3,11,11}).Returns(7);
            }
        }

        [SetUp]
        public void Setup()
        {
            _instance = new OddValue();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public int Test1(int[] A)
        {
            return _instance.solution(A);
        }
    }
}