using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1_3
{
    public class DZ13Norm
    {
        static char[] alph;
        static char[] obj;
        //static List<char> obj;
        static bool[] used;
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

        //public static void generate(int num, StreamWriter sw)
        //{
        //    if (num == k)
        //    {
        //        for (int i = 0; i < k; i++)
        //        {
        //            sw.Write(obj[i] + " ");
        //        }
        //        sw.WriteLine();
        //    }
        //    for (int i = 0; i < n; i++)
        //        if (!used[i])
        //        {
        //            used[i] = true;
        //            obj.Add(alph[i]);
        //            generate(num + 1, sw);
        //            used[i] = false;
        //            obj.RemoveAt(obj.Count - 1);
        //        }
        //}

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

        static bool generate()
        {
            int j = k;
            for (int i = n - 1; i >= 0; i--)
            {
                if (!used[i])
                {
                    obj[j] = Convert.ToChar(96 + i + 1);
                    j++;
                }
            }
            if (NextPermutation())
            {
                for (int i = k; i < n; i++) used[Convert.ToInt32(obj[i] - 96 - 1)] = false;
                for (int i = 0; i < k; i++) used[Convert.ToInt32(obj[i] - 96 - 1)] = true;
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите длину слова ");
            k = Convert.ToInt32(Console.ReadLine());
            alph = new char[n];
            setAlph(n);
            used = new bool[n];
            for (int i = 0; i < n; i++)
                used[i] = false;
            obj = new char[n];
            string path = "C:/Users/User/Desktop/testik.txt";
            FileStream file = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(file);
            sw.Write("Размещений из " + n + " элементов = " + (factorial(n) / factorial(n - k)) + " Алфавит = {");
            for (int i = 0; i < alph.Length; i++)
            {
                sw.Write(alph[i] + " ");
            }
            sw.WriteLine("}");
            sw.WriteLine();
            for (int i = 0; i < k; i++)
                used[i] = true;
            for (int i = 0; i < k; i++)
            {
                obj[i] = alph[i];
                sw.Write(obj[i] + " ");
            }
            sw.WriteLine();
            while (generate())
            {
                for (int j = 0; j < k; j++) sw.Write(obj[j] + " ");
                sw.WriteLine();
            }
            //generate(0, sw);
            sw.Close();
        }
    }
}
