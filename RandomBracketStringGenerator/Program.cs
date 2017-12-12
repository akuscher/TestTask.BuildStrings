using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomBracket_tring
{

    class Node
    {
        public List<Node> ns = new List<Node>();
        public int level = 0;
        public string data = "";

        /// <summary>
        /// символ склейки
        /// </summary>
        public string glue { get; }

        public Node(int level, string glue, string data)
        {
            this.data = data;
            this.level = level + 1;
            this.glue = glue;
        }
    }

    class Generator
    {
        public Random rnd = new Random();

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                if (i > 0)
                    sb.Append('+');

                sb.Append(chars[rnd.Next(chars.Length)]);
            }
            return sb.ToString();
        }

        int g_size = 0;
        int g_count = 0;
        int l_prev = 0;

        public void SetAndReset(int g_size)
        {
            this.g_size = g_size;
            this.g_count = 0;
            this.l_prev = 0;
        }

        public void WriteNodes(Node n)
        {
            if (g_count >= g_size)
                return;

            for (int i = 0; i < rnd.Next(5); i++)
            {
                g_count++;
                n.ns.Add(new Node(n.level, "+", RandomString(rnd.Next(6) + 1)));
            }

            foreach (Node n1 in n.ns)
            {
                WriteNodes(n1);
            }
        }

        StringBuilder sb = new StringBuilder();

        public string PrintAndClean()
        {

            if (sb == null)
                return "";

            string res = sb.ToString();

            sb.Clear();

            return res;


        }

        public string BuildNodes(Node n)
        {
            bool isTail = (rnd.Next(1) % 2 == 0) ? true : false;

            sb.Append(n.glue);
            sb.Append("(");
            l_prev = n.level;
            sb.Append(n.data);

            foreach (Node n1 in n.ns)
            {
                BuildNodes(n1);
            }


            sb.Append(")");

            return sb.ToString();
        }
    }



    class Program
    {

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            ClearCurrentConsoleLine(currentLineCursor);
        }

        public static void ClearCurrentConsoleLine(int currentLineCursor)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', 50));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        static void Main(string[] args)
        {
            int count = 100;
            const string defaultFile = "output.txt";
            string path = defaultFile;

            
            Console.WriteLine("Передайте два параметра:");
            Console.WriteLine("\t1: кол-во строк");
            Console.WriteLine("\t2: путь для входного файла");
            Console.WriteLine("\t   если файл имеется, он будет перезаписан");
            Console.WriteLine("");
            Console.WriteLine("");

            if (args.Length != 2)
            {
                Console.WriteLine("Передайте два параметра!");
                Console.ReadLine();
                return;
            }

            
            if (!int.TryParse(args[0], out count))
            {
                Console.WriteLine("Первый параметр должен быть целым числом!");
                Console.ReadLine();
                return;
            }

          
            try
            {
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(args[1])))
                {
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(args[1]));
                }

                Console.WriteLine("Путь вывода: " + System.IO.Path.GetDirectoryName(args[1]));
                if (System.IO.Path.GetFileName(args[1]) != "")
                {
                    path = args[1];
                    Console.WriteLine("Файл вывода: " + System.IO.Path.GetFileName(args[1]));
                }
                else
                {
                    path = Path.Combine(args[1], defaultFile);
                    Console.WriteLine("Файл вывода: " + defaultFile + " (назначен)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            
            Generator gen = new Generator();

            Task task = new Task(() =>
            {
                using (StreamWriter outputFile = new StreamWriter(path, true))
                {
                    for (int i = 0; i < count; i++)
                    {
                        gen.SetAndReset(20);
                        int r = gen.rnd.Next(6) + 1;

                        Node root = new Node(0, "", gen.RandomString(r));
                        gen.WriteNodes(root);
                        gen.BuildNodes(root);

                        outputFile.WriteLine(gen.PrintAndClean());

                        ClearCurrentConsoleLine();
                        Console.Write(string.Format("Запись {0} \\ {1}", i, count));
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("Записано");
            });
            task.Start();

           
            Console.ReadLine();
        }
    }
}
