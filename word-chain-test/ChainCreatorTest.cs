using System;
using System.Collections.Generic;
using word_chain;
using Xunit;

namespace word_chain_test
{
    public class ChainCreatorTest
    {
        [Fact]
        public void shouldReturnEmptyListWhenGivenEmptyList()
        {
            var chainCreator = new ChainCreator();
            var actualChain = chainCreator.createChain(new List<string>());
            Assert.Equal(new List<string>(), actualChain);
        }

        [Fact]
        public void shouldReturnGivenListWhenItContainsOnlyOneWord()
        {
            var chainCreator = new ChainCreator();
            var givenList = new List<string>{"food"};
            var actualChain = chainCreator.createChain(givenList);
            Assert.Equal(givenList, actualChain);
        }

        [Fact]
        public void givenTwoWordsWithOneLetterDifferenceShouldReturnGivenList()
        {
            var chainCreator = new ChainCreator();
            var givenList = new List<string>{"food", "good"};
            var actualChain = chainCreator.createChain(givenList);
            Assert.Equal(givenList, actualChain);
        }

        [Fact]
        public void givenListOfMoreThanTwoWordsThenReturnEmptyList()
        {
            var chainCreator = new ChainCreator();
            var givenList = new List<string>{"food", "good", "fork"};
            var actualChain = chainCreator.createChain(givenList);
            Assert.Equal(new List<string>(), actualChain);
        }

        [Fact]
        public void givenListWithTwoWordsOfDifferentLengthsThenReturnEmptyList()
        {
            var chainCreator = new ChainCreator();
            var givenList = new List<string>{"food", "yum"};
            var actualChain = chainCreator.createChain(givenList);
            Assert.Equal(new List<string>(), actualChain);
        }
    }
}