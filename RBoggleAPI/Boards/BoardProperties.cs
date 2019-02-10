namespace RBoggleAPI.Boards
{
    public class BoardProperties
    {
        public BoardType Board { get; set; }
        public DictionaryType Dictionary { get; set; }
        public BoardStyle Style { get; set; }
        public string Letters { get; set; }

        public BoardProperties() {}

        public BoardProperties(BoardType board, DictionaryType dictionary, BoardStyle style, string letters)
        {                        
            Style = style;
            Board = board;
            Dictionary = dictionary;
            Letters = letters;
        }
        
        public enum BoardType
        {
            Trie,
            Lame
        }

        public enum DictionaryType
        {
            EnglishLite,
            English,
            Spanish            
        }

        public enum BoardStyle
        {
            FourByFour = 16,
            FiveByFive = 25,
            SixBySix = 36
        }             
    }
}
