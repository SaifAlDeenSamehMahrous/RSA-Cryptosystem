using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        String strcount = "";
        String str = "";
        String str2 = "";
        Bigint a;
        Bigint b;
        public void add_fun()
        {
            FileStream es = new FileStream("AddTestCases.txt", FileMode.Open);
            StreamReader er = new StreamReader(es);
            FileStream sse = new FileStream("theaddoutput.txt", FileMode.OpenOrCreate);
            StreamWriter swe = new StreamWriter(sse);

            strcount = er.ReadLine();
            str = er.ReadLine();
            str2 = "0";

            while (er.Peek() != -1)
            {

                str = er.ReadLine();
                if (str == "")
                {
                    break;
                }
                str2 = er.ReadLine();
                a = new Bigint(str);
                b = new Bigint(str2);
                a.add_in_String_in_bigint(b);
                swe.WriteLine(a.items_string);
                swe.WriteLine();
                strcount = er.ReadLine();
            }
            er.Close();
            es.Close();
            swe.Close();
            sse.Close();

        }
        public void subtract_fun()
        {
            FileStream fs = new FileStream("SubtractTestCases.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            FileStream ss = new FileStream("thesuboutput.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(ss);

            strcount = sr.ReadLine();
            str = sr.ReadLine();
            str2 = "0";

            while (sr.Peek() != -1)
            {

                str = sr.ReadLine();
                if (str == "")
                {
                    break;
                }
                str2 = sr.ReadLine();
                a = new Bigint(str);
                b = new Bigint(str2);
                a.subtract_in_strings_in_bigint(b);

                sw.WriteLine(a.items_string);
                sw.WriteLine();
                strcount = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
            sw.Close();
            ss.Close();


        }
        public void multiplication_function()
        {
            FileStream mes = new FileStream("MultiplyTestCases.txt", FileMode.Open);
            StreamReader mer = new StreamReader(mes);
            FileStream msse = new FileStream("themuloutput.txt", FileMode.OpenOrCreate);
            StreamWriter mswe = new StreamWriter(msse);

            strcount = mer.ReadLine();
            str = mer.ReadLine();
            str2 = "0";

            while (mer.Peek() != -1)
            {

                str = mer.ReadLine();
                if (str == "")
                {
                    break;
                }
                str2 = mer.ReadLine();
                a = new Bigint(str);
                b = new Bigint(str2);
                a.Karatsuba_in_bigint(b);
                mswe.WriteLine(a.items_string);
                mswe.WriteLine();
                strcount = mer.ReadLine();
            }
            mer.Close();
            mes.Close();
            mswe.Close();
            msse.Close();

        }
        public void Rsafinishsample()

        {
            FileStream es = new FileStream("SampleRSA.txt", FileMode.Open);
            StreamReader er = new StreamReader(es);
            FileStream sse = new FileStream("ourProjectSampleRSA.txt", FileMode.OpenOrCreate);
            StreamWriter swe = new StreamWriter(sse);
            String e, M, n, zero_one;
            strcount = er.ReadLine();


            while (er.Peek() != -1)
            {
                a = new Bigint("");
                n = er.ReadLine();
                e = er.ReadLine();
                M = er.ReadLine();

                zero_one = er.ReadLine();
                if (zero_one == "0")
                {
                    swe.WriteLine(a.Encrypt(n, e, M));
                }
                else
                {
                    swe.WriteLine(a.Decrypt(n, e, M));
                }
            }
            er.Close();

            es.Close();
            swe.Close();
            sse.Close();



        }
        public void Rsafinishcomplete()
        {
            FileStream es = new FileStream("TestRSA2.txt", FileMode.Open);
            StreamReader er = new StreamReader(es);
            FileStream sse = new FileStream("ourProjectTestRSA.txt", FileMode.OpenOrCreate);
            StreamWriter swe = new StreamWriter(sse);
            String e, M, n, zero_one;
            strcount = er.ReadLine();


            while (er.Peek() != -1)
            {
                a = new Bigint("");
                n = er.ReadLine();
                e = er.ReadLine();
                M = er.ReadLine();

                zero_one = er.ReadLine();
                if (zero_one == "0")
                {
                    swe.WriteLine(a.Encrypt(n, e, M));
                }
                else
                {
                    swe.WriteLine(a.Decrypt(n, e, M));
                }
            }
            er.Close();
            es.Close();
            swe.Close();
            sse.Close();



        }
        static void Main(string[] args)
        {
            // long timeBefore = System.Environment.TickCount;
            Program p = new Program();
            // p.Rsafinishsample();
            //    long timeAfter = System.Environment.TickCount;
            //  Console.WriteLine(timeAfter - timeBefore);
            Console.WriteLine("before modification");
            long timeBefore = System.Environment.TickCount;
            p.Rsafinishcomplete();
            long timeAfter = System.Environment.TickCount;

            long timeequal = timeAfter - timeBefore;
            timeequal /= 6000;
            Console.WriteLine(timeequal);
        }
    }
}
