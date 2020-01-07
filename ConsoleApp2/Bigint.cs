using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Bigint
    {
       public String items_string="";
        public Bigint()
        {
            String s = Console.ReadLine();
            items_string = s;
        }

        public Bigint(String s)
        {
            items_string = s;
        }

        public String add_in_String(String X, String Y)
        {
            
            MakeEqualstring(ref X, ref Y);
            String Res = "";
            int carry = 0;
            for (int i = X.Length - 1; i >= 0; i--)
            {
                long num1 = Convert.ToInt64(X[i].ToString());
                long num2 = Convert.ToInt64(Y[i].ToString());
                long result = num1 + num2 + carry;
                if (result > 9)
                {
                    Res = Res.Insert(0, (result % 10).ToString());
                    carry = 1;
                }
                else
                {
                    Res = Res.Insert(0, (result).ToString());
                    carry = 0;
                }
                
            }
            if (carry == 1)
            {
                Res = Res.PadLeft(X.Length + 1, '1');
            }
            
            return Res;
        }

        public void add_in_String_in_bigint(Bigint Y)
        {

            MakeEqualstring(ref items_string, ref Y.items_string);
            String Res = "";
            int carry = 0;
            for (int i = items_string.Length - 1; i >= 0; i--)
            {
                long num1 = Convert.ToInt64(items_string[i].ToString());
                long num2 = Convert.ToInt64(Y.items_string[i].ToString());
                long result = num1 + num2 + carry;
                if (result > 9)
                {
                    Res = Res.Insert(0, (result % 10).ToString());
                    carry = 1;
                }
                else
                {
                    Res = Res.Insert(0, (result).ToString());
                    carry = 0;
                }

            }
            if (carry == 1)
            {
                Res = Res.PadLeft(items_string.Length + 1, '1');
            }
            items_string = Res;
            
        }

        public String subtract_in_strings(String X,String Y)
        {
            MakeEqualstring(ref X, ref Y);
            int borrow = 0;
            String RES = "";
            for (int i = X.Length - 1; i >= 0; i--)
            {
                long num1 = Convert.ToInt64(X[i].ToString());
                long num2 = Convert.ToInt64(Y[i].ToString());

                if (num1-borrow < num2)
                {
                    num1 += 10;
                    num1 -= num2;
                    num1 -= borrow;
                    borrow = 1;
                }
                else
                {
                    num1 -= num2;
                    num1 -= borrow;
                    borrow = 0;
                }
                RES = RES.Insert(0, num1.ToString());
            }
            RES = RES.TrimStart('0');
            if (RES == "")
            {
                RES += "0";
            }
            return RES;
        }

        public void subtract_in_strings_in_bigint(Bigint Y)
        {
            MakeEqualstring(ref items_string, ref Y.items_string);
            int borrow = 0;
            String RES = "";
            for (int i = items_string.Length - 1; i >= 0; i--)
            {
                long num1 = Convert.ToInt64(items_string[i].ToString());
                long num2 = Convert.ToInt64(Y.items_string[i].ToString());

                if (num1 - borrow < num2)
                {
                    num1 += 10;
                    num1 -= num2;
                    num1 -= borrow;
                    borrow = 1;
                }
                else
                {
                    num1 -= num2;
                    num1 -= borrow;
                    borrow = 0;
                }
                RES = RES.Insert(0, num1.ToString());
            }
            RES = RES.TrimStart('0');
            if (RES == "")
            {
                RES += "0";
            }
            items_string = RES;
            
        }

        public String Karatsuba(string x, string y)
        {
            int n = MakeEqualstring(ref x, ref y);
           
            if (n == 1)
            {
                long X_Result = Convert.ToInt64(x);
                long Y_Result = Convert.ToInt64(y);
                long result = X_Result * Y_Result;
                return result.ToString();
            }
                if (n % 2 != 0)
                {
                    x = "0" + x;
                    y = "0" + y;
                    n++;
                }
                int half = n / 2;
                string A = x.Substring(0, half);
                string B = x.Substring(half, half);
                string C = y.Substring(0, half);
                string D = y.Substring(half, half);
                String  AC = Karatsuba(A, C);
                String BD = Karatsuba(B, D);
                String aplusb = add_in_String(A, B);
                String cplusd = add_in_String(C, D);
                String Res1 = Karatsuba(aplusb, cplusd);
                String Z1 = subtract_in_strings(Res1, AC);
                String Z = subtract_in_strings(Z1, BD);

                Z = Z.TrimStart(new char[] { '0' });
                AC = AC.PadRight(AC.Length+(B.Length+D.Length), '0');
                Z = Z.PadRight(Z.Length + (B.Length + D.Length)/2, '0');

                String r = add_in_String( add_in_String(Z, AC),BD);
                r = r.TrimStart(new char[] { '0' });

                return r;
          
        }

        public String Karatsuba_in_bigint(Bigint y)
        {
            int n = MakeEqualstring(ref items_string, ref y.items_string);

            if (n == 1)
            {
                long X_Result = Convert.ToInt64(items_string);
                long Y_Result = Convert.ToInt64(y.items_string);
                long result = X_Result * Y_Result;
                return result.ToString();
            }
            if (n % 2 != 0)
            {
                items_string = "0" + items_string;
                y.items_string = "0" + y.items_string;
                n++;
            }
            int half = n / 2;
            string A = items_string.Substring(0, half);
            string B = items_string.Substring(half, half);
            string C = y.items_string.Substring(0, half);
            string D = y.items_string.Substring(half, half);
            String AC = Karatsuba(A, C);
            String BD = Karatsuba(B, D);
            String aplusb = add_in_String(A, B);
            String cplusd = add_in_String(C, D);
            String Res1 = Karatsuba(aplusb, cplusd);
            String Z1 = subtract_in_strings(Res1, AC);
            String Z = subtract_in_strings(Z1, BD);

            Z = Z.TrimStart(new char[] { '0' });
            AC = AC.PadRight(AC.Length + (B.Length + D.Length), '0');
            Z = Z.PadRight(Z.Length + (B.Length + D.Length) / 2, '0');

            String r = add_in_String(add_in_String(Z, AC), BD);
            r = r.TrimStart(new char[] { '0' });

            items_string = r;
            return r;

        }

        public Tuple<string, string> division(string a, string b)
            {
                bool flag = false;
                Tuple<string, string> iTuple1 = new Tuple<string, string>("0", a);
                if (a.Length<b.Length)
                {
                    return iTuple1;
                }
                else if (a.Length == b.Length)
                {
                    int num1, num2;
                    for (int i = 0; i < a.Length; i++)
                    {
                        num1 = a[i] - 48;
                        num2 = b[i] - 48;
                        if (num1 < num2)
                        {
                            flag = true;
                            break;
                        }
                        else if (num1 > num2)
                    {
                        break;
                    }
                    
                    }
                    if (flag)
                    {
                        return iTuple1;
                    }
                }
                string q , r;
                iTuple1 = division(a,add_in_String(b,b));
                q = add_in_String(iTuple1.Item1, iTuple1.Item1);
                r = iTuple1.Item2;
                flag = false;
                if (r.Length < b.Length)
                {
                    flag = true;
                }
                else if(r.Length == b.Length)
                {
                    int num1;
                    int num2;
                    for (int i = 0; i < r.Length; i++)
                    {
                        num1 = r[i] - 48;
                        num2 = b[i] - 48;
                        if (num1 < num2)
                        {
                            flag = true;
                            break;
                        }
                        else if(num1 > num2)
                    {
                        break;
                    }
                        continue;
                    }

                }

                if (flag)
                {
                    iTuple1 = new Tuple<string, string>(q, r);
                    return iTuple1;
                }
                else {
                    iTuple1 = new Tuple<string, string>(add_in_String(q, "1"), subtract_in_strings(r, b));
                    return iTuple1;
                }
                
            
            }
     
        public String Mode_of_Power(String b,String p,String m) {
            if (b == "0")
            {
                return "0";
            }
            if(p == "0")
            {
                return "1";
            }
            string l = division(p,"2").Item2;
            String y;
            if (l == "0")
            {
                 p = division(p, "2").Item1;
                y = Mode_of_Power(b, p, m);

                y = Karatsuba(y, y);
                y = division(y, m).Item2;
            }
            else
            {
                y = division(b, m).Item2;
                p = subtract_in_strings(p, "1");
                y = Karatsuba(y, Mode_of_Power(b, p, m));
                y = division(y, m).Item2;

                //y = division(b, m).Item2;
                //l= subtract_in_strings(p, "1");
                //String MM = Mode_of_Power(b, l, m);
                //MM = division(MM, m).Item2;
                //y = Karatsuba(y, MM);
                //y = division(y, m).Item2;
            }


            return division(add_in_String(y,m),m).Item2;
        }

        public String Encrypt (String n,String e,String M)
        {
            return Mode_of_Power(M, e, n);
        }
        public String Decrypt(String n, String e, String M)
        {
            return Mode_of_Power(M, e, n);
        }

        public int MakeEqualstring(ref string x, ref string y)
        {
            int len1 = x.Length;
            int len2 = y.Length;
            if (len1 < len2)
            {
                x=x.PadLeft(len2, '0');
                return len2;
            }
            else
            {
                
                y=y.PadLeft(len1, '0');
                
            }
            return len1;
        }

    }
}
 
