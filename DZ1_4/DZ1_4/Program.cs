using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1_4
{
    class Program
    {
        public struct chi
        {
            public char ch;
            public bool fl;
        }

        static char[] alph;
        static List<char> obj;
        static chi[] chi1;
        static int k;
        static int n;

        static void setAlph(int n)
        {
            Console.WriteLine("Введите сами элементы");
            string tmp = Console.ReadLine();
            string[] str = tmp.Split(' ');
            for (int i = 0; i < n; i++)
            {
                alph[i] = Convert.ToChar(str[i]);
            }
        }
        static bool next()
        {
            int m = k;
            for (int i = m - 1; i >= 0; --i)
                if (obj[i] < alph[n - m + i])
                {
                    ++obj[i];
                    for (int j = i + 1; j < m; ++j)
                        obj[j] = Convert.ToChar(Convert.ToInt32(obj[j - 1]) + 1);
                    return true;
                }
            return false;
        }

        static void rec1(int h, int j, StreamWriter sw)
        {
            if (j == k)
            {
                for (int i = 0; i < n; i++)
                    if (chi1[i].fl)
                        sw.Write(alph[i]);
                sw.WriteLine();
                return;
            }
            for (int i = h + 1; i < n; i++)
            {
                if (!chi1[i].fl)
                {
                    chi1[i].fl = true;
                    obj.Insert(j, chi1[i].ch);
                    rec1(i, j + 1, sw);
                    chi1[i].fl = false;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов ");
            n = Convert.ToInt32(Console.ReadLine());
            alph = new char[n];
            setAlph(n);
            string path = "C:/Users/User/Desktop/testik.txt";
            FileStream file = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(file);
            sw.Write(" Алфавит = {");
            for (int i = 0; i < alph.Length; i++)
            {
                sw.Write(alph[i] + " ");
            }
            sw.Write("}");
            sw.WriteLine();
            sw.Write("Пустое множество");
            sw.WriteLine();
            for (k = 1; k <= n; k++)
            {
                obj = new List<char>(k);
                for (int i = 0; i < k; i++)
                {
                    obj.Add(alph[i]);
                }
                for (int i = 0; i < k; i++)
                    sw.Write(obj[i] + " ");
                sw.WriteLine();
                while (next())
                {
                    for (int i = 0; i < k; i++)
                        sw.Write(obj[i] + " ");
                    sw.WriteLine();
                }
            }
            sw.Close();
        }
    }
}
