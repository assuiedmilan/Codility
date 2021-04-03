using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codility.Arrays
{
    /*
    An array A consisting of N integers is given. Rotation of the array means that each element is shifted right by one index, and the last element of the array is moved to the first place. For example, the rotation of array A = [3, 8, 9, 7, 6] is [6, 3, 8, 9, 7] (elements are shifted right by one index and 6 is moved to the first place).

    The goal is to rotate array A K times; that is, each element of A will be shifted to the right K times.

    Write a function:

        class Solution { public int[] solution(int[] A, int K); }

    that, given an array A consisting of N integers and an integer K, returns the array A rotated K times.

    For example, given
        A = [3, 8, 9, 7, 6]
        K = 3

    the function should return [9, 7, 6, 3, 8]. Three rotations were made:
        [3, 8, 9, 7, 6] -> [6, 3, 8, 9, 7]
        [6, 3, 8, 9, 7] -> [7, 6, 3, 8, 9]
        [7, 6, 3, 8, 9] -> [9, 7, 6, 3, 8]

    For another example, given
        A = [0, 0, 0]
        K = 1

    the function should return [0, 0, 0]

    Given
        A = [1, 2, 3, 4]
        K = 4

    the function should return [1, 2, 3, 4]

    Assume that:

            N and K are integers within the range [0..100];
            each element of array A is an integer within the range [−1,000..1,000].

    In your solution, focus on correctness. The performance of your solution will not be the focus of the assessment.
     */

    public class CyclicRotation
    {
        public int[] solution(int[] a, int k)
        {
            if (a.Length == 0)
            {
                return a;
            }

            var allElementsAreEquals = a.All(s => a[0] == s);
            var numberOfRotations = k%a.Length ;
            var sliceSIze = a.Length - numberOfRotations;

            return  numberOfRotations == 0 || allElementsAreEquals ? a : a.Skip(sliceSIze).Concat(a.Take(sliceSIze)).ToArray();
        }
    }

    public class TestCyclicRotation
    {
        private CyclicRotation _instance;

        public static IEnumerable<TestCaseData> TestCases
        {

            get
            {
                yield return new TestCaseData(new[] {3, 8, 9, 7, 6}, 3).Returns(new[] {9, 7, 6, 3, 8});
                yield return new TestCaseData(new[] {3, 8, 9, 7, 6}, 4).Returns(new[] {8, 9, 7, 6, 3});
                yield return new TestCaseData(new[] {3, 8, 9, 7, 6}, 5).Returns(new[] {3, 8, 9, 7, 6});
                yield return new TestCaseData(new[] {0, 0, 0}, 1).Returns(new[] {0, 0, 0});
                yield return new TestCaseData(new int[0], 0).Returns(new int [0]);
            }
        }

        [SetUp]
        public void Setup()
        {
            _instance = new CyclicRotation();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public int[] Test1(int[] a, int k)
        {
            return _instance.solution(a, k);
        }
    }
}