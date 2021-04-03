using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;


namespace Codility.CountingElements
{

    /*
    A small frog wants to get to the other side of a river. The frog is initially located on one bank of the river (position 0) and wants to get to the opposite bank (position X+1). Leaves fall from a tree onto the surface of the river.

    You are given an array A consisting of N integers representing the falling leaves. A[K] represents the position where one leaf falls at time K, measured in seconds.

    The goal is to find the earliest time when the frog can jump to the other side of the river. The frog can cross only when leaves appear at every position across the river from 1 to X (that is, we want to find the earliest moment when all the positions from 1 to X are covered by leaves). You may assume that the speed of the current in the river is negligibly small, i.e. the leaves do not change their positions once they fall in the river.

    For example, you are given integer X = 5 and array A such that:
    A[0] = 1
    A[1] = 3
    A[2] = 1
    A[3] = 4
    A[4] = 2
    A[5] = 3
    A[6] = 5
    A[7] = 4

    In second 6, a leaf falls into position 5. This is the earliest time when leaves appear in every position across the river.

    Write a function:

    class Solution { public int solution(int X, int[] A); }

    that, given a non-empty array A consisting of N integers and integer X, returns the earliest time when the frog can jump to the other side of the river.

    If the frog is never able to jump to the other side of the river, the function should return −1.

    For example, given X = 5 and array A such that:
    A[0] = 1
    A[1] = 3
    A[2] = 1
    A[3] = 4
    A[4] = 2
    A[5] = 3
    A[6] = 5
    A[7] = 4

    the function should return 6, as explained above.

    Write an efficient algorithm for the following assumptions:

    N and X are integers within the range [1..100,000];
    each element of array A is an integer within the range [1..X].
    */

    public class CrossingRiver
    {
        public int solution(int x, int[] a)
        {
            const int cannotCrossResult = -1;
            var mayCross = false;
            int leafCounter;

            if (x == 0)
            {
                return x;
            }

            if (a.Length < x)
            {
                return cannotCrossResult;
            }

            var emptySpaces = x;
            var hasLeafFallAtIndex = new int[x];

            for(leafCounter = 0; leafCounter<a.Length; leafCounter++)
            {
                var leafCase = a[leafCounter] - 1;

                if (hasLeafFallAtIndex[leafCase] == 0)
                {
                    emptySpaces -= 1;
                    hasLeafFallAtIndex[leafCase] = 1;
                }


                if (emptySpaces == 0)
                {
                    mayCross = true;
                    break;
                }
            }

            return mayCross ? leafCounter:cannotCrossResult;
        }
    }

    public class TestCrossingRiver
    {
        private CrossingRiver _instance;

        public static IEnumerable<TestCaseData> TestCases
        {

            get
            {
                yield return new TestCaseData(5, new [] {1,3,1,4,2,3,5,4}).Returns(6);
                yield return new TestCaseData(5, new [] {1,2,3,4}).Returns(-1);
                yield return new TestCaseData(0, new [] {1,2,3,4}).Returns(0);
                yield return new TestCaseData(0, new [] {1,2,3,4}).Returns(0);
                yield return new TestCaseData(1, new [] {1,2,3,4}).Returns(0);
                yield return new TestCaseData(1, Array.Empty<int>()).Returns(-1);
                yield return new TestCaseData(0, Array.Empty<int>()).Returns(0);
            }
        }

        [SetUp]
        public void Setup()
        {
            _instance = new CrossingRiver();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public int Test1(int x, int[] a)
        {
            return _instance.solution(x, a);
        }
    }
}