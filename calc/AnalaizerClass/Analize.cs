using System;
using System.Collections.Generic;
using CalcClass;

namespace AnalaizerClass
{

    public class Analize
    {
        private const int m = 30;
        private static bool error = false;
        private static int k = 0;
        private static string ss;

//some comment 
        private const double MAXINT = 214783648;
        private const double MININT = -214783648;

        public static void Errors(char[] ex, char[] ex_symb, List<char> symb, List<char> symb1, int length, int k,
            int k_symb)
        {
            Error7(length);
            Error2(ex, length, symb);
            Error5(ex, length, symb);
            Error3(ex_symb, k_symb);
            Error4(ex, length, symb, symb1);
            Error1(ex, length, symb);


        }

        public static bool Error8(int k)
        {
            if (k > 30)
            {
                ss = "Error08";
                error = true;
                return true;
            }
            return false;

        }

        public static bool Error6(string c) //v Poland Inverse string not char
        {
            if (Convert.ToDouble(c) > MAXINT)
            {
                ss = "Error06";
                error = true;
                return true;
            }
            if (Convert.ToDouble(c) < MININT)
            {
                ss = "Error06";
                error = true;
                return true;
            }
            return false;
        }

        public static void Error7(int length)
        {
            if (length > 65535)
            {
                ss = "Error07";
                error = true;
            }
        }

        public static bool IsNumeric(String str)
        {
            try
            {
                Double.Parse(str.ToString());
                return true;
            }
            catch
            {
            }
            return false;
        }

        private static void Error2(char[] ex, int length, List<char> symb)
        {

            for (int i = 0; i < length; i++)
            {
                if (!IsNumeric(Convert.ToString(ex[i])))
                    if (!symb.Contains(ex[i]))
                    {
                        ss = ("Error02 " + (i + 1));
                        error = true;
                        break;
                    }
            }

        }

        private static void Error5(char[] ex, int length, List<char> symb)
        {
            if (symb.Contains(ex[length - 1]) && (ex[length - 1] != ')' && ex[length - 1] != 'm'))
            {
                ss = "Error05";
                error = true;
            }
        }

        private static void Error3(char[] ex_symb, int k_symb)
        {
            int count = 0, count1 = 0;
            for (int i = 0; i < k_symb; i++)
            {
                if (ex_symb[i] == '(')
                {
                    count++;
                }
                if (ex_symb[i] == ')')
                {
                    count1++;
                }
            }
            if (count > 3)
            {
                ss = "Error03";
                error = true;
            }
            if (count != count1)
            {
                ss = "Error03";
                error = true;
            }
        }

        private static void Error4(char[] ex, int length, List<char> symb, List<char> symb1)
        {
            int i;
            for (i = 0; i < length; i++)
            {
                if (i == 0)
                {
                    if (symb.Contains(ex[i]))
                        if (ex[i] != '(' && ex[i] != '-')
                        {
                            error = true;
                            i++;
                            ss = "Error04  " + (i + 1);
                            break;
                        }
                }
                else
                {
                    if (ex[i - 1] == 'm') continue;


                    if (symb1.Contains(ex[i - 1]) && symb1.Contains(ex[i]))
                    {
                        if (ex[i] == 'p') continue;
                        if (ex[i] != '-')
                        {
                            error = true;
                            ss = "Error04  " + (i + 1);
                            break;
                        }

                        else
                        {
                            if ((i + 1) <= length)
                                if (!symb.Contains(ex[i + 1]))
                                {
                                    continue;
                                }
                                else
                                {
                                    error = true;
                                    ss = "Error04  " + (i + 1);
                                    break;
                                }


                        }
                    }
                }
            }
        }

        private static void Error1(char[] ex, int length, List<char> symb)
        {

            for (int i = 1; i < length; i++)
            {
                if (ex[i - 1] == '(' && symb.Contains(ex[i]) && ex[i] != '-')
                {
                    if (ex[i] != '(')
                    {
                        error = true;
                        ss = "Error01  " + (i);
                        break;
                    }
                }
                if (ex[i] == ')' && symb.Contains(ex[i - 1]))
                    if (ex[i - 1] != ')')
                    {
                        error = true;
                        ss = "Error01  " + (i);
                        break;
                    }

            }
        }

        private static bool Error9(string s)
        {
            if (Convert.ToDouble(s) == 0)
            {
                ss = "Error09";
                error = true;
                return true;
            }
            return false;

        }

        public static string Start(string sss)
        {
            if (string.IsNullOrWhiteSpace(sss)) return "";
            error = false;
            char[] ex;
            List<char> symb1 = new List<char>(new char[] {'+', '-', '*', '/', '%', 'p', 'm'});
            List<char> symb = new List<char>(new char[] {'+', '-', '*', '/', ')', '(', '%', 'p', 'm'});
            char[] ex_symb;
            int length = 0;
            int k_symb = 0;
            k = 0;
            length = sss.Length;
            ex_symb = new char[length];
            ex = new char[length];
            string[] b = new string[length];
            string rez;
            string s = Convert.ToString(sss);


            var arr = sss.ToCharArray();
            
            if (arr[0].CompareTo('0') == 0 && !symb1.Contains(arr[1])) return "error500";
            
            for (int i = 0; i < length; i++)
            {
                
                ex[i] = arr[i];
            }
            for (int i = 0; i < length; i++)
            {
                if (i + 1 < length && symb.Contains(ex[i]) && ex[i + 1].CompareTo('0') == 0)
                {
                    if (arr[length - 1].CompareTo('0') == 0 && symb1.Contains(arr[length - 2]))
                    {
                        continue;
                    }
                    if (arr[length - 1].CompareTo(')') == 0 && arr[length - 2].CompareTo('0') == 0)
                    {
                        continue;
                    }
                        return "error500";
                }
                

                if (symb.Contains(ex[i]))
                {
                    ex_symb[k_symb] = ex[i];
                    k_symb++;
                }
                else k++;

            }
            Errors(ex, ex_symb, symb, symb1, length, k, k_symb);
            if (!error)
            {
                P(ex, s, out b);
                if (!error)
                {
                    // foreach (string ch in b) { if (!String.IsNullOrEmpty(ch))vuvid.AppendText(ch + " "); }
                    rez = CALC(b);
                    return rez;
                }
                else return ss;
            }
            else return ss;


        }

        public static string P(char[] a, string s, out string[] outt)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>
            {
                {"+", 2},
                {"-", 2},
                {"*", 3},
                {"/", 3},
                {"%", 3},
                {"(", 0},
                {")", 1},
                {"m", 6},
                {"p", 2}
            };
            string[] st = new string[a.Length + 4];
            string[] inn = new string[a.Length];
            Stack<string> steck = new Stack<string>();
            List<char> operator3 = new List<char>(new char[] {'+', '-', '*', '/', '%', '(', 'm', 'p'});
            List<char> operatorr = new List<char>(new char[] {'+', '-', '*', '/', '%', '(', ')', 'm', 'p'});
            List<string> operatorss = new List<string>(new string[] {"+", "-", "*", "/", "%", "(", ")", "m", "p"});
            List<string> operators3 = new List<string>(new string[] {"+", "-", "*", "/", "%", "(", "m", "p"});
            //  List<string> operators = new List<string>(new string[] { "+", "-", "*", "/" ,"%", "m", "p" });
            outt = new string[a.Length];
            int c = 0, k = 0, x = 1, y = 1, cc = 0;
            ;
            bool bb = false;
            string ss = String.Empty;

            k = 0;
            c = 0;
            foreach (char ch in a)
            {
                if (ch == 'p')
                {
                    if (st[k - 1] == "-") st[k - 1] = "+";
                    else if (st[k - 1] == "+") st[k - 1] = "-";
                    continue;
                }
                if (ch == '-')
                {
                    if (c == 0)
                    {
                        ss += ch.ToString();
                        continue;
                    }
                    if (bb)
                    {
                        ss += ch.ToString();
                        continue;
                    }

                }
                c++;
                if (operator3.Contains(ch)) bb = true;
                else bb = false;
                if (operatorr.Contains(ch))
                {
                    st[k] = ss;
                    k++;
                    st[k] = ch.ToString();
                    ss = String.Empty;
                    k++;
                }
                else ss += ch.ToString();
            }
            bb = false;
            st[k] = ss;
            c = 0;
            k = 0;
            // foreach (string ch in st) { if (ch.Equals("p")) { st[c-1]}=MathFunctions.ABS }
            foreach (string ch in st)
                if (!String.IsNullOrEmpty(ch))
                {
                    cc++;
                    if (operatorss.Contains(ch))
                    {
                        c++;
                        if (ch.Equals(")"))
                        {
                            int z = 0;
                            do
                            {
                                inn[k] = steck.Pop();
                                k++;
                                if (steck.Count == 0)
                                {
                                    break;
                                }
                                dict.TryGetValue(steck.Peek(), out z);

                            } while (!(z == 0));
                            if (inn[k - 1].Equals("("))
                            {
                                k--;
                                inn[k] = String.Empty;
                                continue;
                            }
                            steck.Pop();
                            continue;
                        }
                        if (ch.Equals("("))
                        {
                            c = 1;
                        }
                        if (c == 1)
                        {
                            steck.Push(ch.ToString());
                        }
                        else
                        {
                            if (steck.Count == 0) y = 0;
                            else dict.TryGetValue(steck.Peek(), out y);
                            dict.TryGetValue(ch.ToString(), out x);

                            if (x > y)
                            {
                                steck.Push(ch.ToString());
                            }
                            else
                            {
                                while (x <= y)
                                {
                                    inn[k] = steck.Pop();
                                    k++;
                                    if (steck.Count == 0) break;
                                    dict.TryGetValue(steck.Peek(), out y);
                                }
                                steck.Push(ch);
                            }
                        }
                    }
                    else
                    {
                        if (Error6(ch))
                        {
                            return ss;
                        }
                        inn[k] = ch;
                        k++;
                    }
                }
            if (Error8(cc - 1))
            {
                return ss;
            }
            k = 0;
            c = 0;
            foreach (string ch in inn)
            {
                if (!String.IsNullOrEmpty(ch))
                {
                    outt[c] = ch;
                    c++;
                }
            }
            foreach (string ch in steck)
            {
                outt[c] = ch;
                c++;
            }

            c = 0;
            foreach (string ch in outt)
            {
                c++;
            }
            return ss;
        }

        public static string CALC(string[] a)
        {
            Stack<string> steck = new Stack<string>();

            List<string> operators = new List<string>(new string[] {"+", "-", "*", "/", "%", "m", "p"});

            #region foreach
            foreach (string ch in a)
            {
                if (!String.IsNullOrEmpty(ch))
                {
                    steck.Push(ch);
                    if (operators.Contains(ch))
                    {
                        switch (ch)
                        {
                            case "+":
                                steck.Pop();
                                steck.Push(
                                    Convert.ToString(MathFunctions.Add(Convert.ToInt64(steck.Pop()),
                                        Convert.ToInt64(steck.Pop()))));
                                break;
                            case "-":
                                steck.Pop();
                                steck.Push(
                                    Convert.ToString(
                                        MathFunctions.Add(MathFunctions.Sub(0, (Convert.ToInt64(steck.Pop()))),
                                            Convert.ToInt64(steck.Pop()))));
                                break;
                            case "*":
                                steck.Pop();
                                steck.Push(
                                    Convert.ToString(MathFunctions.Mult(Convert.ToInt64(steck.Pop()),
                                        Convert.ToInt64(steck.Pop()))));
                                break;
                            case "/":
                                steck.Pop();
                                if (Error9(steck.Peek()))
                                {
                                    return ss;
                                }
                                steck.Push(
                                    Convert.ToString(MathFunctions.Div(Convert.ToInt64(steck.Pop()),
                                            Convert.ToInt64(steck.Pop()))));
                                break;
                            case "%":
                                steck.Pop();
                                long y = Convert.ToInt64(steck.Pop());
                                steck.Push(Convert.ToString(MathFunctions.Mod(Convert.ToInt64(steck.Pop()), y)));
                                break;
                            case "m":
                                steck.Pop();
                                steck.Push(Convert.ToString(MathFunctions.IABS(Convert.ToInt64(steck.Pop()))));
                                break;
                            case "p":
                                steck.Pop();
                                steck.Push(Convert.ToString(MathFunctions.ABS(Convert.ToInt64(steck.Pop()))));
                                break;
                        }
                        if (Error6(steck.Peek()))
                        {
                            return ss;
                        }
                    }

                }
            }
            #endregion
            return ss = steck.Peek();

        }

    }
}

