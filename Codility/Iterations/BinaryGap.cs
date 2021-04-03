using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Codility.Iterations
{

    /*
    A binary gap within a positive integer N is any maximal sequence of consecutive zeros that is surrounded by ones at both ends in the binary representation of N.

    For example, number 9 has binary representation 1001 and contains a binary gap of length 2. The number 529 has binary representation 1000010001 and contains two binary gaps: one of length 4 and one of length 3. The number 20 has binary representation 10100 and contains one binary gap of length 1. The number 15 has binary representation 1111 and has no binary gaps. The number 32 has binary representation 100000 and has no binary gaps.

    Write a function:

    class Solution { public int solution(int N); }

    that, given a positive integer N, returns the length of its longest binary gap. The function should return 0 if N doesn't contain a binary gap.

    For example, given N = 1041 the function should return 5, because N has binary representation 10000010001 and so its longest binary gap is of length 5. Given N = 32 the function should return 0, because N has binary representation '100000' and thus no binary gaps.

    Write an efficient algorithm for the following assumptions:

    N is an integer within the range [1..2,147,483,647].

    Copyright 2009–2021 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited.
    */

    public class BinaryGap
    {
        public int solution(int number)
        {
            int maxGap = 0;
            int gapCounter = 0;
            string binary = Convert.ToString(number, 2).TrimStart(new[] { '0' } ).TrimEnd(new[] { '0' } );

            foreach (var c in binary)
            {
                if (c.Equals('0'))
                {
                    gapCounter++;
                }
                else
                {
                    maxGap = Math.Max(maxGap, gapCounter);
                    gapCounter = 0;
                }
            }

            return maxGap;
        }
    }

    public class TestBinaryGap
    {
        private BinaryGap _instance;

        public static IEnumerable<TestCaseData> TestCases
        {

            get
            {
                yield return new TestCaseData(1041).Returns(5);
                yield return new TestCaseData(32).Returns(0);
                yield return new TestCaseData(0).Returns(0);
                yield return new TestCaseData(1).Returns(0);
                yield return new TestCaseData(2).Returns(0);
                yield return new TestCaseData(3).Returns(0);
                yield return new TestCaseData(4).Returns(0);
                yield return new TestCaseData(5).Returns(1);
                yield return new TestCaseData(6).Returns(0);
                yield return new TestCaseData(328).Returns(2);
            }
        }

        [SetUp]
        public void Setup()
        {
            _instance = new BinaryGap();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public int Test1(int testCase)
        {
            return _instance.solution(testCase);
        }
    }
}