using System;
using System.Collections.Generic;
using System.Linq;

namespace word_chain
{
    public class ChainCreator
    {
        public List<string> createChain(List<string> list)
        {
            return convertToValidInput(list);
        }

        public List<string> convertToValidInput(List<string> list)
        {
            switch (list.Count)
            {
                case 1:
                    return new List<string> {list[0], list[0]};
                case 2 when list[0].Length == list[1].Length:
                    return list;
                default:
                    return new List<string>();
            }
        }
    }
}