using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Codility.AfterAcademy
{

    public class RomanToInteger
    {
        private static readonly Dictionary<char, int> ConversionTable = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000},
        };

        private static readonly Dictionary<string, int> SubtractionTable = new()
        {
            {"IV", 1},
            {"IX", 1},
            {"XL", 10},
            {"XC", 10},
            {"CD", 100},
            {"CM", 100},
        };

        public int solution(string romanNumber)
        {
            var currentValue = 0;
            var previousCharacter = ' ';
            var previousWasSubstraction = false;

            for (int i = 0; i < romanNumber.Length; i++)
            {
                var currentCharacter = romanNumber[i];
                var currentTwoCharacters = previousCharacter + currentCharacter.ToString();

                if (SubtractionTable.ContainsKey(currentTwoCharacters))
                {
                    currentValue -= ConversionTable[previousCharacter];
                    currentValue += - SubtractionTable[currentTwoCharacters] + ConversionTable[currentCharacter];
                    previousWasSubstraction = true;
                }
                else {
                    if (previousCharacter != ' ' && ConversionTable[previousCharacter] == ConversionTable[currentCharacter] && previousWasSubstraction)
                    {
                        throw new ArithmeticException("Number is invalid, " + previousCharacter +" cannot be followed by " + currentCharacter + " when the character before that caused a subtraction.");
                    }

                    currentValue += ConversionTable[currentCharacter];
                    previousWasSubstraction = false;
                }

                previousCharacter = currentCharacter;

            }

            return currentValue;
        }


    }

    public class TestsRomanToInteger
    {
        private RomanToInteger _instance;

        public static IEnumerable<TestCaseData> TestCases
        {

            get
            {
                //Simple cases
                yield return new TestCaseData("I").Returns(1);
                yield return new TestCaseData("V").Returns(5);
                yield return new TestCaseData("VI").Returns(6);
                yield return new TestCaseData("XVI").Returns(16);
                yield return new TestCaseData("III").Returns(3);

                //Simple subtract cases
                yield return new TestCaseData("IV").Returns(4);
                yield return new TestCaseData("IX").Returns(9);
                yield return new TestCaseData("XL").Returns(40);
                yield return new TestCaseData("XC").Returns(90);
                yield return new TestCaseData("CD").Returns(400);
                yield return new TestCaseData("CM").Returns(900);

                //Simple subtract cases but inverted (no subtraction)
                yield return new TestCaseData("VI").Returns(6);
                yield return new TestCaseData("XI").Returns(11);
                yield return new TestCaseData("LX").Returns(60);
                yield return new TestCaseData("CX").Returns(110);
                yield return new TestCaseData("DC").Returns(600);
                yield return new TestCaseData("MC").Returns(1100);

                //Complex case
                yield return new TestCaseData("MCDXXIV").Returns(1424);
            }
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public int Test1(string romanNumber)
        {
            _instance = new RomanToInteger();
            return _instance.solution(romanNumber);

        }

        [Test]
        public void TestException1()
        {
            _instance = new RomanToInteger();
            Assert.Throws<ArithmeticException>(
                () => { _instance.solution("MCDDXXIV"); }
            );
        }
    }
}