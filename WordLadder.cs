using System.Collections.Generic;
using System.Linq;

namespace Hackerrank
{
    public class WordLadder
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var WordList = new HashSet<string>(wordList);

            int wordlength = 0;
            if (!wordList.Contains(endWord) || beginWord == endWord)
                return wordlength;

            if (WordList.Contains(beginWord))
                WordList.Remove(beginWord);

            var reached = new HashSet<string>();
            reached.Add(beginWord);
            wordlength = 1;

            while (reached.Count != 0)
            {
                var addToReached = new HashSet<string>();

                foreach (var word in reached)
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            var verifyword = stringReplaceAt(word, i, c); ;
                            if (verifyword == endWord)
                                return wordlength + 1;

                            if (WordList.Contains(verifyword))
                            {
                                addToReached.Add(verifyword);
                                WordList.Remove(verifyword);
                            }
                        }
                    }
                }

                reached = addToReached;
                wordlength++;
            }



            return 0;
        }

        private static string stringReplaceAt(string s, int index, char c)
        {
            var array = s.ToCharArray();
            array[index] = c;

            return new string(array);
        }
    }
}