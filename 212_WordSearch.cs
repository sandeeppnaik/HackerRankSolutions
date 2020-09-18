using System.Collections.Generic;

public class WordSerchII {
    public IList<string> FindWords(char[][] board, string[] words) 
    {
        var result = new List<string>();
        var trie = BuildTrie(words);

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                DFS(i, j, trie,board, result);
            }
            
        }
        return result;        
    }

    private void DFS(int row, int column, TrieNode trie, char[][] board, List<string> result)
    {
        if(row < 0 || row >= board.Length 
            || column < 0 || column >= board[0].Length
            || board[row][column] == '#')
            return;

        if( trie.next[board[row][column] - 'a'] == null)
            return;

        
        if(trie.next[board[row][column] - 'a'].word != null)
        {
            result.Add(trie.next[board[row][column] - 'a'].word);
            trie.next[board[row][column] - 'a'].word = null;
        }


        trie = trie.next[board[row][column] - 'a'];
        var temp = board[row][column] ;
        board[row][column] = '#';
        DFS(row, column + 1, trie, board, result);
        DFS(row + 1, column , trie, board, result);
        DFS(row, column - 1, trie, board, result);
        DFS(row - 1, column, trie, board, result);
        board[row][column] = temp;
    }

    private TrieNode BuildTrie(string[] words)
    {
        var root = new TrieNode();
        foreach (var word in words)
        {
            var p = root;
            for (int i = 0; i < word.Length; i++)
            {
                var pos = word[i] - 'a';
                if(p.next[pos] == null)
                    p.next[pos] = new TrieNode();
                
                p = p.next[pos];
            }
            p.word = word;
        }

        return root;
    }

}

public class TrieNode {
    public TrieNode[] next = new TrieNode[26];
    public string word { get; set; }
}