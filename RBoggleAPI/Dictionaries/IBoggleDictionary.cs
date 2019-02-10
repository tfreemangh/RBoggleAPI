using System;
using System.Collections.Generic;

using RBoggleAPI.Boards;

namespace RBoggleAPI.Dictionaries
{
    public interface IBoggleDictionary
    {
        BoardProperties.DictionaryType Type { get; }
        List<string> Words { get; set; }
    }
}