using System;
using System.Collections.Generic;
using Codility.CountingElements;
using NUnit.Framework;

namespace Codility.Euclidian
{
    public class ChocolateNumbers
    {

        public int solution(int N, int M) {
            return N / gcd(N, M);
        }

        public int lcm(int a, int b)
        {
            return a * b / (gcd(a, b));
        }

        public int gcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }

            return gcd(b, a%b);
        }

    }

    public class TestChocolateNumbers
    {
        private ChocolateNumbers _instance;

        public static IEnumerable<TestCaseData> TestCases
        {

            get
            {
                yield return new TestCaseData(100, 3).Returns(100);
                yield return new TestCaseData(10, 4).Returns(5);
            }
        }

        [SetUp]
        public void Setup()
        {
            _instance = new ChocolateNumbers();
        }

        [Test]
        [TestCase(10,4, 2)]
        [TestCase(10,10, 10)]
        [TestCase(0,0, 0)]
        [TestCase(434,378, 14)]
        [TestCase(434,377, 1)]
        [TestCase(340238272,92983800, 8)]
        [TestCase(-340238272,92983800, -8)]
        [TestCase(340238272,-92983800, 8)]
        [TestCase(-340238272,-92983800, -8)]
        public void TestGcd(int a, int b, int expectedResult)
        {
            Assert.AreEqual(expectedResult,_instance.gcd(a,b));
        }
        [Test]
        [TestCaseSource(nameof(TestCases))]
        public int Test1(int N, int M)
        {
            return _instance.solution(N, M);
        }
    }
}