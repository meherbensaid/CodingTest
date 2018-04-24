using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGame
{
    class Check
    {
        static bool check(string str) // vérification d'une chaine constituée de ()[] 
        {
            if (str == null || !str.Any())
            {
                return true;
            }
            if (str.Contains("(]") || str.Contains("[)")) return false;
            Stack<char> stack = new Stack<char>();

            char c;
            for (int i = 0; i < str.Length; i++)
            {
                c = str.ElementAt(i);

                if (c == '(')
                    stack.Push(c);
                else if (c == '[')
                    stack.Push(c);
                else if (c == ')')
                    if (!stack.Any())
                        return false;
                    else if (stack.Peek() == '(')
                        stack.Pop();
                    else
                        return false;
                else if (c == ']')
                    if (!stack.Any())
                        return false;
                    else if (stack.Peek() == '[')
                        stack.Pop();
                    else
                        return false;
            }
            return !stack.Any();
        }


    }
}
