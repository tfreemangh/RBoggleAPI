using System;

using RBoggleAPI.Dictionaries;
using RBoggleAPI.Utilities;

namespace RBoggleAPI.Boards
{
    public class BoardFactory
    {
        public static IBoard CreateBoard(BoardProperties.BoardStyle style, BoardProperties.DictionaryType dictionary, BoardProperties.BoardType board, string letters)
        {
            IBoggleDictionary boardDictionary = GetBoggleDictionary(dictionary);
            return GetBoard(board, boardDictionary, style , letters);            
        }

        private static IBoard GetBoard(BoardProperties.BoardType board, IBoggleDictionary dictionary, BoardProperties.BoardStyle style, string letters)
        {
            string boardName = Enum.GetName(typeof(BoardProperties.BoardType), board);
            letters = letters.ToLower();

            switch(boardName.ToLower())
            {
                case Constants.LAME_BOARDTYPE:
                    return new LameBoard(style, dictionary, letters);
                case Constants.TRIE_BOARDTYPE:
                    return new TrieBoard(style, dictionary, letters);
                default:
                    return new LameBoard(style, dictionary, letters); //default to lame board for testing
            }
        }

        private static IBoggleDictionary GetBoggleDictionary(BoardProperties.DictionaryType name)
        {
            string dictionaryName = Enum.GetName(typeof(BoardProperties.DictionaryType), name);

            switch (dictionaryName.ToLower())
            {
                case Constants.ENGLISHLITE_DICTIONARY:
                    return new EnglishLite();
                case Constants.SPANISH_DICTIONARY:
                    return new Spanish();
                case Constants.ENGLISH_DICTIONARY:
                    return new EnglishLite(); //not implemented return default
                default:
                    return new EnglishLite(); //return default

            }
        }
    }
}