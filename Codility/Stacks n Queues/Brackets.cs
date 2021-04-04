using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Codility.Stacks_n_Queues
{
    public class Brackets
    {
        private const string OpeningChars = "{[(";
        private const string ClosingChars = "}])";

        public int solution(string s) {

            var expectedClosingOperands = new Stack();

            foreach (var operand in s)
            {
                var openingCharIndex = OpeningChars.IndexOf(operand, StringComparison.Ordinal);
                var isOpeningChar = openingCharIndex != -1;

                if (isOpeningChar)
                {
                    var closingOperand = ClosingChars[openingCharIndex];
                    expectedClosingOperands.Push(closingOperand);
                }
                else
                {
                    if (!StackHasItem(expectedClosingOperands)) return 0;

                    var expectedClosingOperand = expectedClosingOperands.Pop();

                    if (!operand.Equals(expectedClosingOperand)) return 0;
                }
            }

            return StackHasItem(expectedClosingOperands) ? 0:1;
        }

        private bool StackHasItem(Stack stack)
        {
            return stack.Count != 0;
        }
    }

    public class TestBrackets
    {
        private Brackets _instance;

        public static IEnumerable<TestCaseData> TestCases
        {

            get
            {
                yield return new TestCaseData("(").Returns(0);
                yield return new TestCaseData("}").Returns(0);
                yield return new TestCaseData("").Returns(1);
                yield return new TestCaseData("{[()()]}").Returns(1);
                yield return new TestCaseData("([)()]").Returns(0);
                yield return new TestCaseData("[(){[()]}]").Returns(1);
                yield return new TestCaseData("[(){[()}]]").Returns(0);
            }
        }

        [SetUp]
        public void Setup()
        {
            _instance = new Brackets();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public int Test1(string s)
        {
            return _instance.solution(s);
        }
    }
}