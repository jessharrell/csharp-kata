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
        
    }
}