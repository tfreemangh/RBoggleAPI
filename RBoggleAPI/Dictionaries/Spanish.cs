using System.Collections.Generic;

using RBoggleAPI.Boards;

namespace RBoggleAPI.Dictionaries
{
    public class Spanish : IBoggleDictionary
    {
        public List<string> Words { get; set; }

        public BoardProperties.DictionaryType Type
        {
            get
            {
              return BoardProperties.DictionaryType.Spanish;
            }
        }

        public Spanish()
        {
            Words = new List<string>();
            Words.Add("Si");
            Words.Add("Habla");
            Words.Add("Espanol");            
        }
    }
}