using System;
using System.Collections.Generic;
using System.Linq;

namespace bowling_kata
{
    public class BowlingScoreCalculator
    {
        private const int NumberOfBallsInNineFrames = 18;
        
        public int calculateTotalScore(List<int> rolls)
        {
            var total = 0;

            
            for (var ball = 0; ball < NumberOfBallsInNineFrames; ball++)
            {
                if (isFirstBallOfFrame(ball))
                {
                    if (isStrike(rolls, ball))
                    {
                        total += rolls[ball + 2] + rolls[ball + 3];
                    }
                }
                else
                {
                    if (IsSpare(rolls, ball))
                    {
                        total += rolls[ball + 1];
                    }
                }
            }

            return total + rolls.Sum();
        }

        private static bool isStrike(IReadOnlyList<int> rolls, int ball)
        {
            return rolls[ball] == 10;
        }

        private static bool IsSpare(IReadOnlyList<int> rolls, int ball)
        {
            return rolls[ball - 1] != 10 && rolls[ball - 1] + rolls[ball] == 10;
        }

        private static bool isFirstBallOfFrame(int i)
        {
            return i % 2 == 0;
        }
    }
}