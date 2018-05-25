using System;
using System.Collections.Generic;
using System.Linq;

namespace bowling_kata
{
    public class BowlingScoreCalculator
    {
        public int calculateTotalScore(List<int> rolls)
        {
            var total = 0;

            for (var i = 0; i < 18; i++)
            {
                if (i % 2 == 0)
                {
                    if (rolls[i] == 10)
                    {
                        total = total + rolls[i + 2] + rolls[i + 3];
                    }
                }
                else
                {
                    if (rolls[i - 1] != 10 && rolls[i - 1] + rolls[i] == 10)
                    {
                        total = total + rolls[i + 1];
                    }
                }
            }

            return total + rolls.Sum();
        }
    }
}