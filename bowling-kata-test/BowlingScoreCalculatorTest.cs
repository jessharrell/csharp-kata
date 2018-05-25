using System;
using System.Collections.Generic;
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
    }
}