using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codility.CountingElements
{
    public class MaxCounter
    {
        public int[] solution(int n, int[] a)
        {
            var max = 0;
            var maxLoopIndex = a.Length;
            var i = 0;

            while(i<maxLoopIndex)
            {
                if (a[i] <= n)
                {
                    i++;
                    continue;
                }

                var take = a.Take(i).ToArray();

                if (take.Length != 0)
                {
                    max += take.GroupBy(x => x).Select(x => new {num = x, cnt = x.Count()}).OrderByDescending(g => g.cnt).Select(g => g).First().cnt;
                }

                a = a.Skip(i + 1).ToArray();
                maxLoopIndex = a.Length;

                i = 0;

            }

            var counter = Enumerable.Repeat(max, n).ToArray();

            foreach (int j in a)
            {
                counter[j - 1]++;
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