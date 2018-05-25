using System.Collections.Generic;
using bowling_kata;
using Moq;
using Xunit;

namespace bowling_kata_test
{
    public interface CallbackInterface
    {
        string SuccessCallback();
        void FailureCallback(ErrorCode errorCode);
    }
    
    public class BowlingRollValidatorTest
    {
        [Fact]
        public void shouldCallSuccessFunctionWhenGivenListOfTwentyZeros()
        {
            var mockWithCallbacks = new Mock<CallbackInterface>();
            var rolls = new List<int>(new int[20]);
            var validator = new BowlingRollValidator();
            validator.validate(rolls, mockWithCallbacks.Object.SuccessCallback,
                mockWithCallbacks.Object.FailureCallback);
            mockWithCallbacks.Verify(m => m.SuccessCallback());
        }

        [Fact]
        public void shouldReturnStringFromSuccessFunctionWhenSuccessful()
        {
            var mockWithCallbacks = new Mock<CallbackInterface>();
            var successResult = "I was Successful";
            mockWithCallbacks.Setup(m => m.SuccessCallback()).Returns(successResult);
            var rolls = new List<int>(new int[20]);
            var validator = new BowlingRollValidator();
            Assert.Equal(successResult, validator.validate(rolls, mockWithCallbacks.Object.SuccessCallback,
                mockWithCallbacks.Object.FailureCallback));
        }
        
        [Fact]
        public void shouldCallFailureFunctionWithNotEnoughRollsErrorCodeWhenGivenListOf19Zeros()
        {
            var mockWithCallbacks = new Mock<CallbackInterface>();
            var rolls = new List<int>(new int[19]);
            var validator = new BowlingRollValidator();
            
            validator.validate(rolls, mockWithCallbacks.Object.SuccessCallback,
                mockWithCallbacks.Object.FailureCallback);
            
            mockWithCallbacks.Verify(m => m.FailureCallback(ErrorCode.NotEnoughRolls));
        }
        
        [Fact]
        public void shouldCallFailureFunctionWithTooManyRollsErrorCodeWhenGivenListOf22Zeros()
        {
            var mockWithCallbacks = new Mock<CallbackInterface>();
            var rolls = new List<int>(new int[22]);
            var validator = new BowlingRollValidator();
            
            validator.validate(rolls, mockWithCallbacks.Object.SuccessCallback,
                mockWithCallbacks.Object.FailureCallback);
            
            mockWithCallbacks.Verify(m => m.FailureCallback(ErrorCode.TooManyRolls));
        }
    }
}