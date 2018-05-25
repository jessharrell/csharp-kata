using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using bowling_kata_test;

namespace bowling_kata
{
    public class BowlingRollValidator
    {
        public string validate(List<int> rolls, Func<string> successFunc, Action<ErrorCode> errorFunc)
        {
            if (!HasEnoughRolls(rolls, errorFunc) || !HasEarnedBonusRoll(rolls, errorFunc) ||
                HasTooManyRolls(rolls, errorFunc))
            {
                return "Failure";
            }

            return successFunc();
        }

        private bool HasEnoughRolls(List<int> rolls, Action<ErrorCode> errorFunc)
        {
            return ValidateRolls(rolls.Count < 20, errorFunc, ErrorCode.NotEnoughRolls);
        }
        
        private bool HasEarnedBonusRoll(List<int> rolls, Action<ErrorCode> errorFunc)
        {
            return ValidateRolls(rolls.Count == 21 && rolls[19] + rolls[20] < 10, errorFunc, ErrorCode.UnEarnedBonusInTenth);
        }
        
        private bool HasTooManyRolls(List<int> rolls, Action<ErrorCode> errorFunc)
        {
            return !ValidateRolls(rolls.Count > 21, errorFunc, ErrorCode.TooManyRolls);
        }

        private bool ValidateRolls(bool isInvalid, Action<ErrorCode> errorFunc, ErrorCode code)
        {
            if (!isInvalid) return true;
            
            errorFunc(code);
            return false;
        }
    }
}