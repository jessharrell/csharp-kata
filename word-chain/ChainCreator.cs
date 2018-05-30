using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace word_chain
{
    public class ChainCreator
    {
        private IDictionaryService dictionaryService;

        public ChainCreator(IDictionaryService dictionaryService)
        {
            this.dictionaryService = dictionaryService;
        }
        
        public List<string> createChain(List<string> list)
        {
            var validatedinput = convertToValidInput(list);

            if (validatedinput.Count == 0)
            {
                return validatedinput;
            }

//            var wordTree = createChainTree(validatedinput);
            return validatedinput;
        }

        private ChainTracker createChainTree(List<string> validatedinput)
        {
            throw new System.NotImplementedException();
        }

        private List<string> convertToValidInput(List<string> list)
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