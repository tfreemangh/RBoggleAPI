using System.Collections.Generic;

using RBoggleAPI.Dictionaries;


namespace RBoggleAPI.Boards
{
    public abstract class BaseBoard : IBoard
    {
        public BoardProperties.BoardStyle Style { get;}
        public IBoggleDictionary Dictionary { get; }
        public string Letters { get; }

        public BaseBoard(BoardProperties.BoardStyle style, IBoggleDictionary dictionary, string letters)
        {
            Style = style;
            Dictionary = dictionary;
            Letters = letters;            
        }
        public abstract List<string> Solve();
    }
}