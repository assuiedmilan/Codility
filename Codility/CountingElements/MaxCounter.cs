using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codility.CountingElements
{
    public class MaxCounter
    {
        public int[] solution(int n, int[] a)
        {
            var currentMax = 0;
            var counter = new int [n];
            var previousMoveWasAMaxCounter = false;

            foreach (var counterToIncrease in a)
            {
                var counterToIncreaseIndex = counterToIncrease - 1;

                if (counterToIncrease > counter.Length)
                {
                    if (previousMoveWasAMaxCounter) continue;

                    currentMax = counter.Max();
                    previousMoveWasAMaxCounter = true;
                }
                else
                {
                    var counterToIncreaseValue = counter[counterToIncreaseIndex];

                    if (counterToIncreaseValue < currentMax)
                    {
                        counter[counterToIncreaseIndex] = currentMax + 1;
                    }
                    else
                    {
                        counter[counterToIncreaseIndex] += 1;
                    }

                    previousMoveWasAMaxCounter = false;
                }
            }

            for (var i = 0; i < counter.Length; i++)
            {
                if (counter[i] < currentMax)
                {
                    counter[i] = currentMax;
                }
            }

            return counter;
        }
    }

    public class TestMaxCounter
    {
        private MaxCounter _instance;

        public static IEnumerable<TestCaseData> TestCases
        {

            get
            {
                yield return new TestCaseData(5, new [] {3,4,4,6,1,4,4}).Returns(new [] {3,2,2,4,2});
                yield return new TestCaseData(5, new [] {3,4,4,6,6,6,1,4,4}).Returns(new [] {3,2,2,4,2});
                yield return new TestCaseData(8, new [] {3,4,4,9,1,4,4}).Returns(new [] {3,2,2,4,2, 2, 2, 2});
                yield return new TestCaseData(1, new [] {1,4,4,6,1,4,4}).Returns(new [] {2});
            }
        }

        [SetUp]
        public void Setup()
        {
            _instance = new MaxCounter();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public int[] Test1(int n, int[] a)
        {
            return _instance.solution(n, a);
        }
    }
}