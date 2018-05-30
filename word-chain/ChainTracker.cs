using System;
using System.Collections.Generic;
using System.Linq;

namespace word_chain
{
    public class ChainTracker
    {
        private readonly string start;
        private readonly string destination;

        private List<List<string>> tree;
        private int currentLevel;

        public ChainTracker(string start, string destination)
        {
            this.start = start;
            this.destination = destination;
            tree = new List<List<string>>();
        }

        public List<string> validateChainWithNewLevel(params string[] level)
        {
            tree[currentLevel] = new List<string>();
            foreach (var word in level)
            {
                if (word.Equals(destination))
                {
                    return getShortestPath(word);
                }
                tree[currentLevel].Append(word);
            }
            
            return new List<string>();
        }

        private List<string> getShortestPath(string word)
        {
            
            return new List<string> {start, word};
        }
    }
}