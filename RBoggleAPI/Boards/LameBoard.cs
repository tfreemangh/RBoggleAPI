using System.Collections.Generic;

using RBoggleAPI.Dictionaries;
using RBoggleAPI.Utilities;

namespace RBoggleAPI.Boards
{
    public class LameBoard : BaseBoard
    {        
        public LameBoard(BoardProperties.BoardStyle style, IBoggleDictionary dictionary, string letters) : base(style, dictionary, letters)  {}

        public override List<string> Solve()
        {
            return Helper.TestWordList();
        }
    }
}