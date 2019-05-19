using System;
using System.Collections.Generic;

namespace Hackerrank
{
    public class QAttackV2
    {
        internal static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles) 
        {
            var lookup = new Dictionary<string, int[]>();
            var directions = new HashSet<string>()
            {
                "left",
                "right",
                "top",
                "bottom",
                "first",
                "second",
                "third",
                "forth",
            };
            for(int i = 0; i < obstacles.Length; i++)
            {
                var item = obstacles[i];
                if(item[0] == r_q && item[1] < c_q)
                {
                    if(lookup.ContainsKey("left"))
                    {
                        var shortest = lookup["left"];
                        if(item[1] > shortest[1])
                            shortest[1] = item[1];
                    }
                    else
                    {
                        lookup.Add("left", new int []{item[0], item[1]});
                    }
                }
                else if(item[0] == r_q && item[1] > c_q)
                {
                    if(lookup.ContainsKey("right"))
                    {
                        var shortest = lookup["right"];
                        if(item[1] < shortest[1])
                            shortest[1] = item[1];
                    }
                    else
                    {
                        lookup.Add("right", new int []{item[0], item[1]});
                    }
                }
                else if(item[1] == c_q && item[0] < r_q)
                {
                    if(lookup.ContainsKey("top"))
                    {
                        var shortest = lookup["top"];
                        if(item[0] > shortest[0])
                            shortest[0] = item[0];
                    }
                    else
                    {
                        lookup.Add("top", new int []{item[0], item[1]});
                    }
                }
                else if(item[1] == c_q && item[0] > r_q)
                {
                    if(lookup.ContainsKey("bottom"))
                    {
                        var shortest = lookup["bottom"];
                        if(item[0] < shortest[0])
                            shortest[0] = item[0];
                    }
                    else
                    {
                        lookup.Add("bottom", new int []{item[0], item[1]});
                    }
                }
                else if(c_q > item[1] && r_q > item[0]
                 && c_q - item[1] == r_q - item[0])
                {
                    if(lookup.ContainsKey("second"))
                    {
                        var shortest = lookup["second"];
                        if(item[0] > shortest[0])
                        {
                            shortest[0] = item[0];
                            shortest[1] = item[1];                            
                        }
                    }
                    else
                    {
                        lookup.Add("second", new int []{item[0], item[1]});
                    }
                }
                else if(c_q < item[1] && r_q > item[0] 
                && c_q - item[1] == -(r_q - item[0]))
                {
                    if(lookup.ContainsKey("first"))
                    {
                        var shortest = lookup["first"];
                        if(item[0] > shortest[0])
                        {
                            shortest[0] = item[0];
                            shortest[1] = item[1];                            
                        }
                    }
                    else
                    {
                        lookup.Add("first", new int []{item[0], item[1]});
                    }
                }
                else if(c_q > item[1] && r_q < item[0] 
                && c_q - item[1] == -(r_q - item[0]))
                {
                    if(lookup.ContainsKey("third"))
                    {
                        var shortest = lookup["third"];
                        if(item[0] < shortest[0])
                        {
                            shortest[0] = item[0];
                            shortest[1] = item[1];                            
                        }
                    }
                    else
                    {
                        lookup.Add("third", new int []{item[0], item[1]});
                    }
                }
                else if(c_q < item[1] && r_q < item[0]  
                && c_q - item[1] == r_q - item[0])
                {
                    if(lookup.ContainsKey("forth"))
                    {
                        var shortest = lookup["forth"];
                        if(item[0] < shortest[0])
                        {
                            shortest[0] = item[0];
                            shortest[1] = item[1];                            
                        }
                    }
                    else
                    {
                        lookup.Add("forth", new int []{item[0], item[1]});
                    }
                }
            }
           

            var moves = 0;
            foreach(var item in lookup)
            {
                if(item.Key == "left")
                {
                    moves += c_q - item.Value[1] - 1;
                    directions.Remove("left");
                }
                else if(item.Key == "right")
                {
                    moves +=  item.Value[1] - c_q - 1;
                    directions.Remove("right");
                }
                else if(item.Key == "top")
                {
                    directions.Remove("top");
                    moves +=  r_q - item.Value[0] - 1;
                }
                else if(item.Key == "bottom")
                {
                    directions.Remove("bottom");
                    moves +=  item.Value[0] - r_q - 1;
                }
                else if(item.Key == "first")
                {
                    directions.Remove("first");
                    moves +=  item.Value[1] -c_q - 1;
                }else if(item.Key == "second")
                {
                    directions.Remove("second");
                    moves +=  c_q - item.Value[1] - 1;
                }else if(item.Key == "third")
                {
                    directions.Remove("third");
                    moves +=  c_q - item.Value[1] - 1 ;
                }else if(item.Key == "forth")
                {
                    directions.Remove("forth");
                    moves +=  item.Value[1] -c_q - 1;
                }
            }

            foreach(var item in directions)
            {
                if(item == "left")
                {
                    moves += c_q - 1;
                }
                else if(item == "right")
                {
                    moves +=  n - c_q;
                }
                else if(item == "top")
                {
                    moves +=  r_q - 1;
                }
                else if(item == "bottom")
                {
                    moves +=  n - r_q;
                }
                else if(item == "first")
                {
                    moves +=  Math.Min(r_q - 1, n - c_q ); 
                }
                else if(item == "second")
                {
                    moves +=  Math.Min(r_q - 1, c_q - 1); 
                }
                else if(item == "third")
                {
                    moves +=  Math.Min(n - r_q , c_q - 1); 
                }
                else if(item == "forth")
                {
                    moves +=  Math.Min(n - r_q , n - c_q); 
                }

            }
            return moves;

        }
    }
}