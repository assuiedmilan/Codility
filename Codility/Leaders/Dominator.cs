using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Codility.Leaders
{
    public class Dominator
    {
        public int solution(int[] A) {

            if (A.Length == 0) {
                return -1;
            }

            if (A.Length == 1) {
                return 0;
            }

            var originalArray = (int[])A.Clone();


            Array.Sort(A);
            var startingIndex = A.Length/2;
            var leaderCount = 1;
            var leaderThreshold = startingIndex;
            var leaderCandidate = A[startingIndex];

            var runningIndex = startingIndex + 1;
            while(runningIndex < A.Length) {
                if (A[runningIndex] == leaderCandidate) {
                    leaderCount++;
                    runningIndex++;
                    continue;
                }
                break;
            }

            runningIndex = startingIndex - 1;
            while(runningIndex >= 0) {
                if (A[runningIndex] == leaderCandidate) {
                    leaderCount++;
                    runningIndex--;
                    continue;
                }
                break;
            }

            return leaderCount > leaderThreshold ? Array.IndexOf(originalArray, leaderCandidate):-1;
        }

        public class TestDominator
        {
            private Dominator _instance;

            public static IEnumerable<TestCaseData> TestCases
            {

                get
                {
                    yield return new TestCaseData(new []{3, 2, 3, 4, 3, 3 ,3, -1}).Returns(0);
                    yield return new TestCaseData(new []{4,2,5,2,2,6,2}).Returns(1);
                    yield return new TestCaseData(new []{4,2,5,2,2,6,2,7}).Returns(-1);
                    yield return new TestCaseData(Array.Empty<int>()).Returns(-1);
                    yield return new TestCaseData(new []{4}).Returns(0);
                }
            }

            [SetUp]
            public void Setup()
            {
                _instance = new Dominator();
            }

            [Test]
            [TestCaseSource(nameof(TestCases))]
            public int Test1(int[] a)
            {
                return _instance.solution(a);
            }
        }
    }
}