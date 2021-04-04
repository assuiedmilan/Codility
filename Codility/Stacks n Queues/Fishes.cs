using System.Collections.Generic;
using System;
using System.Collections;
using NUnit.Framework;

namespace Codility.Stacks_n_Queues
{
    class Fishes {

        /*
        Testing:
            - Regular case
            - Edge cases:
                + No fish
                + Single fish
                + All fish are moving in opposite directions
                + All fishs are moving in converging directions
                + Mix upstream/downstream orders, repeat same cases while changing weights only

        Data prep:
            - Use the classe properties to pack together and easy access the fish properties. Via a method returning a tuple for instance: (Direction, Weight, Alive)
            - Use a counter for alive, to avoid parsing the tables more than necessary. This is error prone but more efficient. Initialize it at the tables size

        Process:
            - Chose a direction to process. The direction impact the way the array must be parsed. If we consider the fish moving upstream, we start from index 0 and move on, if we take downstream, we have to start from end of the table, otherwise the encounters are not correctly represented. Let's say downard stream, it's easier.
            - Start parsing the stream of fish:
                - If the fish moves downstream, put it in a queue, it will at some point encounter a upstream moving fish. The first fish in the queue will first encounter a downard fish, so this need to be a FIFO, so a Queue.
                - If the fish moves upstream, it will soon encounter a downstream fish and all the following fish, so this need combat resolution:
                    + If the upstream fish wins, and they are still fish in the downstream queue, continue to move it. Once there no more fish in the queue, the current upstream fish will never encounter another downstream fish (because of the way we process the input table).
                    + If the downstream fish wins, resume parsing the fish table
                    + Each time a combat is resolved, decrease the alive counter

        */

        private int[] _fishDirections;
        private int[] _fishWeights;

        private readonly Queue<int> _downstreamFishQueue = new Queue<int>();

        private int _aliveFish;

        private bool IsFishMovingDownstream(int index)
        {
            return _fishDirections[index] == 1;
        }

        private int GetFishWeight(int index)
        {
            return _fishWeights[index];
        }

        private void ResolveCombats(int encounteredFishWeight) {
            bool upstreamFishWins = true;

            while (_downstreamFishQueue.Count != 0 && upstreamFishWins)
            {
                upstreamFishWins = ResolveCombat(encounteredFishWeight, GetFishWeight((int) _downstreamFishQueue.Peek()));
            }
        }

        private bool ResolveCombat(int encounteredFishWeight, int downstreamFishWeight) {
            bool upstreamFishWins;

            if (encounteredFishWeight > downstreamFishWeight) {
                _downstreamFishQueue.Dequeue();
                upstreamFishWins = true;
            }
            else {
                upstreamFishWins = false;
            }

            _aliveFish--;
            return upstreamFishWins;
        }

        public int solution(int[] A, int[] B) {
            _fishWeights = A;
            _fishDirections = B;

            _aliveFish = A.Length;

            for(int i=0; i<A.Length; i++) {

                if(IsFishMovingDownstream(i)) {
                    _downstreamFishQueue.Enqueue(i);
                }
                else {
                    ResolveCombats(GetFishWeight(i));
                }
            }

            return _aliveFish;
        }
    }

    public class TestFish
    {
        private Fishes _instance;

        public static IEnumerable<TestCaseData> TestCases
        {

            get
            {
                yield return new TestCaseData(new int[] {4, 3, 2, 1, 5}, new int[] {0, 1, 0, 0, 0}).Returns(2);
            }
        }

        [SetUp]
        public void Setup()
        {
            _instance = new Fishes();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public int Test1(int[] A, int[] B)
        {
            return _instance.solution(A, B);
        }
    }
}