using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codility.Time_Complexity
{
    /*
    An array A consisting of N different integers is given. The array contains integers in the range [1..(N + 1)], which means that exactly one element is missing.

    Your goal is to find that missing element.

    Write a function:

        class Solution { public int solution(int[] A); }

    that, given an array A, returns the value of the missing element.

    For example, given array A such that:
      A[0] = 2
      A[1] = 3
      A[2] = 1
      A[3] = 5

    the function should return 4, as it is the missing element.

    Write an efficient algorithm for the following assumptions:

            N is an integer within the range [0..100,000];
            the elements of A are all distinct;
            each element of array A is an integer within the range [1..(N + 1)].
     */
    public class PermMissingProblem
    {
        public int solution(int[] A)
        {
            int sum = 0;
            foreach (int i in A)
            {
                sum += i;
            }

            int expectedSum = (A.Length + 1) * (A.Length + 2) / 2;

            return (expectedSum - sum);
        }
    }

    public class TestsPermMissingProblem
    {
        private PermMissingProblem _instance;

        public static IEnumerable<TestCaseData> TestCases
        {

            get
            {
                yield return new TestCaseData(new [] {2,3,1,5}).Returns(4);
                yield return new TestCaseData(Array.Empty<int>()).Returns(1);
                yield return new TestCaseData(new [] {1}).Returns(2);
                yield return new TestCaseData(new [] {2}).Returns(1);
                yield return new TestCaseData(new [] {1,2,3,4}).Returns(5);
                yield return new TestCaseData(new [] {2,3,5,4}).Returns(1);
            }
        }

        [SetUp]
        public void Setup()
        {
            _instance = new PermMissingProblem();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public int Test1(int[] testCase)
        {
            return _instance.solution(testCase);
        }

        [Test]
        public void Test2()
        {
            List<int> testEnum = Enumerable.Range(1, 100000+1).ToList();
            testEnum.Remove(98444);


            Assert.AreEqual(98444, _instance.solution(testEnum.ToArray()));
        }

        [Test]
        public void Test3()
        {
            List<int> testEnum = Enumerable.Range(1, 10000+1).ToList();
            testEnum.Remove(9998);


            Assert.AreEqual(9998, _instance.solution(testEnum.ToArray()));
        }
    }
}