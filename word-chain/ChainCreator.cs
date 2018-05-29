using System;
using System.Collections.Generic;

namespace word_chain
{
    public class ChainCreator
    {
        public List<string> createChain(List<string> list)
        {
            return list.Count == 1 ? list : new List<string>();
        }
    }
}