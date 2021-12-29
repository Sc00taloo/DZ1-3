using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1_6
{
    class Program
    {
        static char[] obj;
        static char[] alph;
        static int n;
        static int k;

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
            int j = k - 1;
            while (obj[j] == alph[n - 1] && j >= 0)
            {
                j--;
                if (j < 0) return false;
            }
            if (obj[j] >= alph[n - 1])
                j--;
            obj[j]++;
            if (j == k - 1) return true;
            for (int m = j + 1; m < k; m++)
                obj[m] = obj[j];
            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Размер алфавита");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Длина слова:");
            k = Convert.ToInt32(Console.ReadLine());
            alph = new char[n];
            setAlph(n);
            obj = new char[n];
            string path = "C:/Users/User/Desktop/testik.txt";
            FileStream file = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(file);
            sw.Write(" Алфавит = {");
            for (int i = 0; i < alph.Length; i++)
            {
                sw.Write(alph[i] + " ");
            }
            sw.WriteLine("}");
            for (int i = 0; i < n; i++)
                obj[i] = 'a';
            for (int i = 0; i < k; i++)
            {
                sw.Write(obj[i] + " ");
            }
            sw.WriteLine();
            while (next())
            {
                for (int i = 0; i < k; i++)
                    sw.Write(obj[i] + " ");
                sw.WriteLine();
            }
            sw.Close();
        }
    }
}
