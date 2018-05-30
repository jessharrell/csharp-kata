using System.Collections.Generic;
using word_chain;
using Xunit;

namespace word_chain_test
{
    public class WordTreeTest
    {
        [Fact]
        public void shouldReturnEmptyListWhenAddedLevelDoesNotMatchDestination()
        {
            var tracker = new ChainTracker("boo", "nod");
            var actual = tracker.validateChainWithNewLevel("foo", "too");
            Assert.Equal(new List<string>(), actual);
        }

        [Fact]
        public void shouldReturnWordChainWhenGivenSingleWordMatchingDestination()
        {
            var tracker = new ChainTracker("boo", "too");
            var actual = tracker.validateChainWithNewLevel("too");
            Assert.Equal(new List<string> {"boo", "too"}, actual);
        }

        [Fact]
        public void shouldReturnWordChainWhenGivenMatchingDestinationOnSecondLevelOneWordPerLevel()
        {
            var tracker = new ChainTracker("boo", "toe");
            tracker.validateChainWithNewLevel("too");
            var actual = tracker.validateChainWithNewLevel("toe");
            Assert.Equal(new List<string> {"boo", "too", "toe"}, actual);
        }
    }
}