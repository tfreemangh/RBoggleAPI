using System.Collections.Generic;

using RBoggleAPI.Dictionaries;


namespace RBoggleAPI.Boards
{
    public class TrieBoard : BaseBoard
    {
        private const int MAX = 26;     
        private List<string> _wordsFound = new List<string>();
        private int _boardLength = 4;

        public TrieBoard(BoardProperties.BoardStyle style, IBoggleDictionary dictionary, string letters) : base(style, dictionary, letters)
        {            
        }
      
        public override List<string> Solve()
        {
            TrieNode root = new TrieNode();
            LoadStructure(root, base.Dictionary);
            char[][] boggle = GetBoggleCharArray();
            FindWords(root, boggle);
            return _wordsFound;
        }


        private char[][] GetBoggleCharArray()
        {
            switch (Style)
            {
                case BoardProperties.BoardStyle.FourByFour:
                    _boardLength = 4;
                    return new char[][] { Letters.Substring(0, _boardLength).ToCharArray(), Letters.Substring(4, _boardLength).ToCharArray(), Letters.Substring(8, _boardLength).ToCharArray(), Letters.Substring(12, _boardLength).ToCharArray() };
                case BoardProperties.BoardStyle.FiveByFive:
                    _boardLength = 5;
                    return new char[][] { Letters.Substring(0, _boardLength).ToCharArray(), Letters.Substring(5, _boardLength).ToCharArray(), Letters.Substring(10, _boardLength).ToCharArray(), Letters.Substring(15, _boardLength).ToCharArray(), Letters.Substring(20, _boardLength).ToCharArray() };
                case BoardProperties.BoardStyle.SixBySix:
                    _boardLength = 6;
                    return new char[][] { Letters.Substring(0, _boardLength).ToCharArray(), Letters.Substring(6, _boardLength).ToCharArray(), Letters.Substring(12, _boardLength).ToCharArray(), Letters.Substring(18, _boardLength).ToCharArray(), Letters.Substring(24, _boardLength).ToCharArray(), Letters.Substring(30, _boardLength).ToCharArray() };
                default:
                    return new char[][] { Letters.Substring(0, _boardLength).ToCharArray(), Letters.Substring(4, _boardLength).ToCharArray(), Letters.Substring(8, _boardLength).ToCharArray(), Letters.Substring(12, _boardLength).ToCharArray() };
            }
        }

        private void LoadStructure(TrieNode root, IBoggleDictionary dictionary)
        {            
            foreach (string word in dictionary.Words)
            {
                AddWords(root, word.ToLower());
            }
        }
        private  void AddWords(TrieNode root, string key)
        {
            int n = key.Length;
            TrieNode current = root;

            for (int i = 0; i < n; i++)
            {
                int index = key[i] - 'a';

                if (current.Child[index] == null)
                    current.Child[index] = new TrieNode();

                current = current.Child[index];
            }                      
            current.IsWord = true;
        }

        private  void SearchWord(TrieNode root, char[][] boggle, int i, int j, bool[,] visited, string wordBuilder)
        {
            if (root.IsWord)
            {
                _wordsFound.Add(wordBuilder);
                return;
            }

            if (IsSafe(i, j, visited))
            {
                visited[i, j] = true;

                for (int row = 0; row < MAX; row++)
                {
                    if (root.Child[row] != null)
                    {
                        char ch = (char)(row + 'a');
                        if (IsSafe(i + 1, j + 1, visited) && boggle[i + 1][j + 1] == ch)
                            SearchWord(root.Child[row], boggle, i +1, j+1, visited, wordBuilder +ch);

                        if (IsSafe(i, j + 1, visited) && boggle[i][j + 1]
                                                          == ch)
                            SearchWord(root.Child[row], boggle, i, j + 1,
                                                      visited, wordBuilder + ch);

                        if (IsSafe(i - 1, j + 1, visited) && boggle[i - 1][j + 1]
                                                               == ch)
                            SearchWord(root.Child[row], boggle, i - 1, j + 1,
                                                      visited, wordBuilder + ch);

                        if (IsSafe(i + 1, j, visited) && boggle[i + 1][j]
                                                              == ch)
                            SearchWord(root.Child[row], boggle, i + 1, j,
                                                     visited, wordBuilder + ch);

                        if (IsSafe(i + 1, j - 1, visited) && boggle[i + 1][j - 1]
                                                              == ch)
                            SearchWord(root.Child[row], boggle, i + 1, j - 1,
                                                      visited, wordBuilder + ch);

                        if (IsSafe(i, j - 1, visited) && boggle[i][j - 1]
                                                             == ch)
                            SearchWord(root.Child[row], boggle, i, j - 1,
                                                     visited, wordBuilder + ch);

                        if (IsSafe(i - 1, j - 1, visited) && boggle[i - 1][j - 1]
                                                             == ch)
                            SearchWord(root.Child[row], boggle, i - 1, j - 1,
                                                    visited, wordBuilder + ch);

                        if (IsSafe(i - 1, j, visited) && boggle[i - 1][j]
                                                            == ch)
                            SearchWord(root.Child[row], boggle, i - 1, j,
                                                  visited, wordBuilder + ch);
                    }                    
                }
                visited[i, j] = false;
            }
        }

        private  bool IsSafe(int row, int col, bool[,] visited)
        {
            return (row >= 0 && row < _boardLength && col >= 0 &&
                    col < _boardLength && !visited[row, col]);
        }

        private void FindWords(TrieNode root, char[][] boggle)
        {
            TrieNode child = root;
            bool[,] visited = new bool[_boardLength, _boardLength];
            string wordBuilder = "";

            for (int i = 0; i < _boardLength; i++)
            {
                for (int j = 0; j < _boardLength; j++)
                {
                    if (child.Child[(boggle[i][j]) - 'a'] != null)
                    {
                        wordBuilder = wordBuilder + boggle[i][j];
                        SearchWord(child.Child[(boggle[i][j]) - 'a'], boggle, i, j, visited, wordBuilder);
                        wordBuilder = string.Empty;
                    }
                }
            }
        }

        public class TrieNode
        {
            public TrieNode[] Child = new TrieNode[MAX];
            public bool IsWord;

            public TrieNode()
            {
                for (int i = 0; i < MAX; i++)
                    Child[i] = null;
                IsWord = false;
            }
        }

    }
}