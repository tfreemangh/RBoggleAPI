﻿using System;
using System.Collections.Generic;

using RBoggleAPI.Boards;

namespace RBoggleAPI.Dictionaries
{
    public class EnglishLite : IBoggleDictionary
    {

        private string[] _commonWords = {   "the", "of","to","and","a","in","is","it","you","that","he","was","for","on","are","with","as","I","his","they","be","at","one","have","this","from","or","had","by","hot","word","but","what","some","we",
                                            "can","out","other","were","all","there","when","up","use","your","how","said","an","each","she","which","do","their","time","if","will","way","about","many","then","them","write","would","like",
                                            "so","these","her","long","make","thing","see","him","two","has","look","more","day","could","go","come","id","number","sound","no","most","people","my","over","know","water","than","call","first",
                                             "who","may","down","side","been","now","find" };

        public List<string> Words { get; set; }

        public BoardProperties.DictionaryType Type
        {
            get
            {
                return BoardProperties.DictionaryType.EnglishLite;
            }
        }

        public EnglishLite()
        {
            Words = new List<string>(_commonWords);
        }
      
    }
}