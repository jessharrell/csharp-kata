using System;
using System.Collections.Generic;
using System.Linq;

namespace bowling_kata
{
    public class BowlingScoreCalculator
    {
        public int calculateTotalScore(List<int> rolls)
        {
            return rolls.Sum();
        }
    }
}