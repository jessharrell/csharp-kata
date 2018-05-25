using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using bowling_kata;
using Xunit;

namespace bowling_kata_test
{
    public class BowlingScoreCalculatorTest
    {
        [Fact]
        public void shouldReturnZeroWhenAllGutterBalls()
        {
            var rolls = new List<int>(new int[20]);
            var scoreCalculator = new BowlingScoreCalculator();
            Assert.Equal(0, scoreCalculator.calculateTotalScore(rolls));
        }
        
        [Fact]
        public void shouldReturn10WhenEachFrameIsOnePinAndOneGutter()
        {
            var gutterRolls = new List<int>(new int[10]);
            var onePinRolls = Enumerable.Repeat(1, 10).ToList();
            var rolls = new List<int>();
            for(var i = 0; i < 10; i++)
            {
                rolls.Add(onePinRolls[i]);
                rolls.Add(gutterRolls[i]);
            }
            var scoreCalculator = new BowlingScoreCalculator();
            Assert.Equal(10, scoreCalculator.calculateTotalScore(rolls));
        }

        [Fact]
        public void shouldGetTwoBallBonusForStrikeInFirstFrame()
        {
            var firstTwoFrames = new List<int> {10, 0, 1, 1};
            var lastEightFrames = new List<int>(new int[16]);
            var rolls = firstTwoFrames.Concat(lastEightFrames).ToList();
            
            var scoreCalculator = new BowlingScoreCalculator();
            Assert.Equal(14, scoreCalculator.calculateTotalScore(rolls));
        }

        [Fact]
        public void shouldGetTwoBallBonusForStrikeInAnyFrame()
        {
            var firstEightFrames = new List<int>(new int[16]);
            var lastTwoFrames = new List<int> {10, 0, 1, 1};
            var rolls = firstEightFrames.Concat(lastTwoFrames).ToList();
            
            var scoreCalculator = new BowlingScoreCalculator();
            Assert.Equal(14, scoreCalculator.calculateTotalScore(rolls));
        }

        [Fact]
        public void shouldGiveSpecialBonusWhenTurkeyIsRolledInTenthFrame()
        {
            var firstNineFrames = new List<int>(new int[18]);
            var tenthFrameTurkey = new List<int> {10, 10, 10};
            var rolls = firstNineFrames.Concat(tenthFrameTurkey).ToList();
            
            var scoreCalculator = new BowlingScoreCalculator();
            Assert.Equal(30, scoreCalculator.calculateTotalScore(rolls));
        }

        [Fact]
        public void shouldGiveOneBallBonusForSpare()
        {
            var firstTwoFrames = new List<int> {3, 7, 1, 1};
            var lastEightFrames = new List<int>(new int[16]);
            var rolls = firstTwoFrames.Concat(lastEightFrames).ToList();
            
            var scoreCalculator = new BowlingScoreCalculator();
            Assert.Equal(13, scoreCalculator.calculateTotalScore(rolls));
        }
    }
}