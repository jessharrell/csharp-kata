using System;
using System.Collections.Generic;
using Moq;
using word_chain;
using Xunit;

namespace word_chain_test
{
    public class ChainCreatorTest
    {
        private Mock<IDictionaryService> mockDictionaryService;
        private readonly ChainCreator chainCreator;

        public ChainCreatorTest()
        {
            mockDictionaryService = new Mock<IDictionaryService>();
            chainCreator = new ChainCreator(mockDictionaryService.Object);
        }
        
        [Fact]
        public void shouldReturnEmptyListWhenGivenEmptyList()
        {
            var actualChain = chainCreator.createChain(new List<string>());
            Assert.Equal(new List<string>(), actualChain);
        }

        [Fact]
        public void shouldReturnChainOfGivenWordWhenItContainsOnlyOneWord()
        {
            var givenList = new List<string>{"food"};
            var actualChain = chainCreator.createChain(givenList);
            Assert.Equal(new List<string>{"food", "food"}, actualChain);
        }

        [Fact]
        public void givenTwoWordsWithOneLetterDifferenceShouldReturnGivenList()
        {
            var givenList = new List<string>{"food", "good"};
            var actualChain = chainCreator.createChain(givenList);
            Assert.Equal(givenList, actualChain);
        }

        [Fact]
        public void givenListOfMoreThanTwoWordsThenReturnEmptyList()
        {
            var givenList = new List<string>{"food", "good", "fork"};
            var actualChain = chainCreator.createChain(givenList);
            Assert.Equal(new List<string>(), actualChain);
        }

        [Fact]
        public void givenListWithTwoWordsOfDifferentLengthsThenReturnEmptyList()
        {
            var givenList = new List<string>{"food", "yum"};
            var actualChain = chainCreator.createChain(givenList);
            Assert.Equal(new List<string>(), actualChain);
        }

        [Fact]
        public void givenTwoWordsWithTwoLettersDifferentWhereChangingTheVowelSolvesTheProblem()
        {
            var givenList = new List<string>{"cat", "con"};
            mockDictionaryService.Setup(dict => dict.IsWord("cot")).Returns(true);
            var actualChain = chainCreator.createChain(givenList);
            Assert.Equal(new List<string>{"cat", "cot", "con"}, actualChain);
        }
    }
}