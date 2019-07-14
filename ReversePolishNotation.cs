using System.Collections.Generic;

namespace Hackerrank
{
    public class ReversePolishNotation
    {
        public int EvalRPN(string[] tokens) 
        {
            var stk = new Stack<int>();

            for(int i = 0; i < tokens.Length; i++)
            {
                if(tokens[i] == "+")
                {
                    var v1 = stk.Pop() ;
                    var v2 = stk.Pop();
                    stk.Push(v1 + v2);
                }
                else if(tokens[i] == "-")
                {
                    var v1 = stk.Pop() ;
                    var v2 = stk.Pop();
                    stk.Push(v1 - v2);
                }
                else if(tokens[i] == "*")
                {
                    var v1 = stk.Pop() ;
                    var v2 = stk.Pop();
                    stk.Push(v1 * v2);
                }
                else if(tokens[i] == "/")
                {
                    var v1 = stk.Pop() ;
                    var v2 = stk.Pop();
                    stk.Push(v1 / v2);
                }
                else
                {
                    stk.Push(int.Parse(tokens[i]));
                }

            }
            return stk.Peek();
        }
    }
}