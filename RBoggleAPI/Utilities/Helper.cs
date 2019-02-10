using System.Collections.Generic;

namespace RBoggleAPI.Utilities
{
    public class Helper
    {       
        public static List<string> TestWordList()
        {
            var wordList = new List<string>();
            wordList.Add("This");
            wordList.Add("Is");
            wordList.Add("A");
            wordList.Add("Test");
            return wordList;
        }
    }
}