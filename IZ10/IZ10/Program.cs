using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ2
{
        public class ProgDZ1_1
        {
            static int[] obj;
            static char[] alph;
            static int n;
            static int k;

            static void SetAlf()
            {
                Console.WriteLine("Символы aлфавита:");
                string tmp = Console.ReadLine();
                string[] str = tmp.Split(' ');
                for (int i = 0; i < n; i++)
                {
                    alph[i] = Convert.ToChar(str[i]);
                }
            }

            static void nextCombObj()
            {
                for (int i = k - 1; i > -1; i--)
                {
                    if (obj[i] == n - 1)
                    {
                        obj[i] = 0; continue;
                    }
                    obj[i]++;
                    break;
                }
            }

            static bool lastCombObj()
            {
                bool b = true;
                for (int i = 0; i < k; i++)
                {
                    if (obj[i] != n - 1)
                    {
                        b = false; break;
                    }
                }
                return b;
            }

            //public static void nextCombObj(int[] obj, int k, int n)
            //{
            //    for (int i = k - 1; i > -1; i--)
            //    {
            //        if (obj[i] == n - 1)
            //        {
            //            obj[i] = 0; continue;
            //        }
            //        obj[i]++;
            //        break;
            //    }
            //}

            //public static bool lastCombObj(int[] obj, int k, int n)
            //{
            //    bool b = true;
            //    for (int i = 0; i < k; i++)
            //    {
            //        if (obj[i] != n - 1)
            //        {
            //            b = false; break;
            //        }
            //    }
            //    return b;
            //}

            static void Main(string[] args)
            {
                Console.WriteLine("Размер алфавита");
                n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Длина слова:");
                k = Convert.ToInt32(Console.ReadLine());
                alph = new char[n];
                SetAlf();
                obj = new int[k];
                string path = "C:/Users/User/Desktop/testik.txt";
                FileStream file = new FileStream(path, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(file);
                sw.Write(" Алфавит = {");
                for (int i = 0; i < alph.Length; i++)
                {
                    sw.Write(alph[i] + " ");
                }
                sw.WriteLine("}");
                while (!lastCombObj())
                {
                    for (int i = 0; i < k; i++)
                    {
                        sw.Write(alph[obj[i]]);
                    }
                    sw.WriteLine();
                    nextCombObj();
                }

                for (int i = 0; i < k; i++)
                {
                    sw.Write(alph[obj[i]]);
                }

                sw.Close();
            }
        }
    }
