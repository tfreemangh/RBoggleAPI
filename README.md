# RBoggleAPI

Once stood up locally, use a client (postman) to post to the following endpoint.
.../api/boggle/Solve.

*** The JSON for the HTTP post 
   {
		"Board": "Trie",
		"Dictionary": "Englishlite",
		"Style": "FourByFour",
		"Letters": "sistonesteshabla"
	}

You can substitute the "Trie" board for the "Lame" board but the "Lame" board really is lame. It will return a fix set of words
regardless of the letters you provide it. I used it for testing and to demonstrate how different boards could be substituted. "Trie"
uses a "Trie" sort to find words on the boggle board. 

You can substitute the "EnglishLite" dictionary for "Spanish" or "English". "EnglishLite" only has 100 common words in. "Spanish"
has three words in it. "English" doesn't exist. Again, the additional dictionaries are provided to demonstrate the ability to substitute
additional dictionaries. 

Board  "Style" can be "FourByFour", "FiveByFive" or "SixBySix" resulting in boards with 16, 25, and 36 letters respectively.

"Letters" can be any combo of letters you want to provide. You must supply the correct amount of letters to match the board "Style"
selected. 
