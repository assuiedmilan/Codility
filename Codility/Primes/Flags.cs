using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Codility.Primes
{
    public class Flags
    {
            /*
    Preprocess:
        - Fill an array with position of the next pic in the main array. Each index in this array contains the index of the next pic to occurs in the main array.
            Condition for a pic is V i €[1, n-1], A[i-1] < A[i] && A[i] > A[i+1]
            Since we cannot predict the position of the next pic, and do not want to backtrack our array, we need to start by the end. Because of the problems hyp, the last index cannot be a pic so we simply set it's index to n+1

    Process:
        - Starting at index 1, go to the first pic, increase the flags counter, then add the number of flags, check if this index is a pic, else, go to next pic.
        - Continue until we are out of bounds or above the max number of flags:
            However, to place x flags, we need x(x-1) pics, this cause sqrt(n) + 2 > np
            Hence, once the number of flags is reached, we can break.

    Tests:
        - No Peaks
        - Alternance of peaks
        - Length is odd
        - Length is even
        - General case
    */
        public int solution(int[] A) {

            var peaksArray = new int[A.Length];
            var maximumFlags = (int) Math.Floor(Math.Sqrt(A.Length)) + 2;
            var flagsCounter = 0;

            if (A.Length == 0) {
                return flagsCounter;
            }

            peaksArray[A.Length-1] = A.Length + 1;
            for (int i=A.Length-2; i>=1; i--) {

                var isAPeak = A[i-1] < A[i] && A[i] > A[i+1];

                if (isAPeak) {
                    peaksArray[i] = i;
                }
                else {
                    peaksArray[i] = peaksArray[i+1];
                }
            }
            peaksArray[0] = peaksArray[1];

            if (peaksArray[0] > A.Length) {
                return flagsCounter;
            }

            //Try first the max value then decrease
            for(int numberOfFlags=maximumFlags; numberOfFlags>1; numberOfFlags--) {

                flagsCounter = 1;
                var currentPoint = peaksArray[0] + numberOfFlags;

                while(currentPoint<A.Length) {

                    //Simpler algo is simply to move from peak to peak and check if the conditions are met to set a flag.

                    var locatedAtAPeak = peaksArray[currentPoint] == currentPoint;
                    Console.WriteLine($"I have {numberOfFlags} flags. I am located at {currentPoint}. This is a peak: {locatedAtAPeak}");

                    if (locatedAtAPeak) {
                        flagsCounter++;
                        currentPoint += numberOfFlags;
                    }
                    else  {
                        currentPoint = peaksArray[currentPoint];
                    }

                    if (flagsCounter > numberOfFlags) {
                        flagsCounter = numberOfFlags;
                        break;
                    }
                }

                //If flagsCounter < numberOfFlags, we could not place all flags, try with one less.
                Console.WriteLine($"I have {numberOfFlags} flags. I foud I could place {flagsCounter} of them");
                if (flagsCounter == numberOfFlags) {
                    break;
                }

            }

            return flagsCounter;
        }
    }

    public class TestFlags
    {
        private Flags _instance;

        public static IEnumerable<TestCaseData> TestCases
        {

            get
            {
                yield return new TestCaseData(new[] {1,5,3,4,3,4,1,2,3,4,6,2}).Returns(3);
                yield return new TestCaseData(new[] {1,3,2,4,3,5,3,6,3}).Returns(2);
            }
        }

        [SetUp]
        public void Setup()
        {
            _instance = new Flags();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public int Test1(int[] a)
        {
            return _instance.solution(a);
        }
    }
}