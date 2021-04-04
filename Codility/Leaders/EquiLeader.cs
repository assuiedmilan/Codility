using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codility.Leaders
{
    public class EquiLeader
    {
        public int solution(int[] A) {
            var leader = FindLeader(A);
            var counter = 0;
            var leaderIndexes = new List<int>();

            if (leader == -1) {
                return 0;
            }

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == leader)
                {
                    leaderIndexes.Add((i));
                    counter++;
                }
            }

            if(counter <= A.Length/2) {
                return 0;
            }

            counter = 0;
            foreach(int index in leaderIndexes) {
                var firstSplit = A.Take(index+1).ToArray();
                var secondSplit = A.Skip(index+1).ToArray();

                var firstLeader = FindLeader(firstSplit);
                var secondLeader = FindLeader(secondSplit);

                if(firstLeader == secondLeader && firstLeader == leader) {
                    counter++;
                }
            }

            return counter;
        }

        public int FindLeader(int[] table) {
            int counter = 0;
            int candidateLeader = -1;

            for(int i=0; i<table.Length;i++) {

                var leaderUnderTest = table[i];

                if (counter == 0) {
                    counter++;
                    candidateLeader = leaderUnderTest;
                }
                else {
                    if(candidateLeader == leaderUnderTest) {
                        counter++;
                    }
                    else {
                        counter--;
                    }
                }
            }

            if (counter == 0) {
                return -1;
            }

            return candidateLeader;
        }
    }

    public class TestLeader
    {
        private EquiLeader _instance;

        public static IEnumerable<TestCaseData> TestCases
        {

            get
            {
                yield return new TestCaseData(new []{4,3,4,4,4,2}).Returns(2);
                yield return new TestCaseData(new []{3, 2, 3, 4, 3, 3, 3, -1}).Returns(3);
                yield return new TestCaseData(new []{4, 2, 5, 2, 2, 6, 2}).Returns(0);
                yield return new TestCaseData(Array.Empty<int>()).Returns(0);
                yield return new TestCaseData(new []{4}).Returns(0);
            }
        }

        [SetUp]
        public void Setup()
        {
            _instance = new EquiLeader();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public int Test1(int[] a)
        {
            return _instance.solution(a);
        }
    }
}