using System;
using System.Collections.Generic;
using bowling_kata_test;

namespace bowling_kata
{
    public class BowlingRollValidator
    {
        public string validate(List<int> rolls, Func<string> successFunc, Action<ErrorCode> errorFunc)
        {
            if (rolls.Count < 20)
            {
                errorFunc(ErrorCode.NotEnoughRolls);
                return "Failure";
            } 
            else if (rolls.Count > 21)
            {
                errorFunc(ErrorCode.TooManyRolls);
                return "Failure";
            }
            return successFunc();
        }
    }
}