using System;
using System.Collections.Generic;

namespace word_chain
{
    public class ChainCreator
    {
        public List<string> createChain(List<string> list)
        {
            if (list.Count == 2)
            {
                if (list[0].Length != list[1].Length)
                {
                    return new List<string>();
                }
                
                return list;
            }
            
            return list.Count == 1 ? list : new List<string>();
        }
    }
}