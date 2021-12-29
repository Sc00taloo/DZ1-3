using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1._2
{
    class Program
    {
        static char[] alph;
        static char[] obj;
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

        static void swap(ref char c1, ref char c2)
        {
            char tmp = c1;
            c1 = c2;
            c2 = tmp;
        }

        static long factorial(long n)
        {
            if (n == 0 || n == 1) return 1;
            return n * factorial(n - 1);
        }
        static void sort(int beginIndex, int endIndex)
        {
            for (int i = beginIndex; i < endIndex; i++)
            {
                for (int j = i; j < endIndex; j++)
                {
                    if (obj[i] > obj[j]) swap(ref obj[i], ref obj[j]);
                }
            }
        }

        static bool NextPermutation()
        {
            int beginIndex = 0;
            for (int i = obj.Length - 2; i >= 0; i--)
            {
                if (obj[i] < obj[i + 1])
                {
                    int min_val = obj[i + 1], min_id = i + 1;
                    for (int j = i + 2; j < obj.Length; j++)
                        if (obj[j] > obj[i] && obj[j] < min_val)
                        {
                            min_val = obj[j];
                            min_id = j;
                        }
                    swap(ref obj[i], ref obj[min_id]);
                    sort(beginIndex + i + 1, obj.Length);
                    return true;
                }
            }
            return false;
        }

        static void generate(int t, StreamWriter sw)
        {
            if (t == alph.Length - 1)
            {
                for (int i = 0; i < alph.Length; i++)
                {
                    sw.Write(obj[i] + " ");
                }
                sw.WriteLine();
            }
            else for (int j = t; j < alph.Length; j++)
                {
                    swap(ref obj[t], ref obj[j]);
                    t++;
                    generate(t, sw);
                    t--;
                    swap(ref obj[t], ref obj[j]);
                }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов ");
            int n = Convert.ToInt32(Console.ReadLine());
            alph = new char[n];
            setAlph(n);
            obj = new char[n];
            for (int i = 0; i < alph.Length; i++)
            {
                obj[i] = alph[i];
            }
            string path = "C:/Users/User/Desktop/testik.txt";
            FileStream file = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(file);
            sw.Write("Перестановок из " + n + " элементов = " + factorial(n) + " Алфавит = {");
            for (int i = 0; i < alph.Length; i++)
            {
                sw.Write(alph[i] + " ");
            }
            sw.Write("}");
            sw.WriteLine();
            for (int i = 0; i < obj.Length; i++) sw.Write(obj[i] + " ");
            while (NextPermutation())
            {
                for (int i = 0; i < obj.Length; i++) sw.Write(obj[i] + " ");
                sw.WriteLine();
            }
            sw.Close();
        }
    }
}
