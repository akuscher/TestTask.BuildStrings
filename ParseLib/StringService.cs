using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ParseLib
{
    public class StringService :IStringService
    {

        /// <summary>
        /// печать N открывающих скобок
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        string printBracketsA(int c)
        {
            if (c > 0)
                return new StringBuilder().Append('(', c).ToString();
            return "";
        }

        /// <summary>
        /// печать N закрывающих скобок
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        string printBracketsB(int c)
        {
            if (Math.Abs(c) > 0)
                return new StringBuilder().Append(')', Math.Abs(c)).ToString();

            return "";
        }

        string printBracketsC(int c)
        {
            if (c > 0)
                return new StringBuilder().Append('(', c).ToString();

            if (c < 0)
                return new StringBuilder().Append(')', Math.Abs(c)).ToString();

            return "";
        }

        int pervL = 1;
        bool needPlus = false;
        /// <summary>
        /// получить отсортированныый вывод из дерева
        /// </summary>
        /// <param name="list"></param>
        /// <param name="blkc"></param>
        /// <param name="reduce"></param>
        void buildBlockList(ref List<Block> list, ref StringBuilder res, Block blkc)
        {
            res.Append(printBracketsC(blkc.Level - pervL));

            if (blkc.Level == pervL && needPlus)
                res.Append("+");

            needPlus = true;

            string s = blkc.ToString();

            if (blkc.hasC)
            {
                if ((blkc.Level - pervL) < 0)
                    res.Append("+");

                res.Append(s);
                //res.Append(s + " " + blkc.Level);
                list.Add(blkc);
            }

            pervL = blkc.Level;

            list.Sort();
            blkc.children.Sort();
            foreach (Block bl in blkc.children)
            {
                buildBlockList(ref list, ref res, bl);
            }

        }

        static void Main(string[] args)
        {
            string s11 = "(I+W+N+O+C+O+(W+M+C+K+B+(X+Y+L+N)+(R+F+N+D+R+(U+(W+H+G+J+C+K+(U+A+E+W+M+B+(G+J+O+R+P+O+(Z+(A+M+N)))+(Z+Y+X+R+D+L+(Z+(V+W)+(R+O+W))+(P+R+K+V+B+F)+(Y+N+K+V+V))+(T+Y+E+R+B))+(Q+O+I))+(K+V+Z+M+C)+(R+B+W+J+A)+(J+L+Q))))+(D))";

            //string s11 = "(U+D+(C+B+E+Q+(D))+A)";
            Console.WriteLine(s11);
            Console.WriteLine();
            StringService eng = new StringService();

            Console.WriteLine(eng.getString(s11));
            Console.ReadLine();
        }

        /// <summary>
        ///  собрать искомую строку
        /// </summary>
        /// <param name="s11"></param>
        /// <returns></returns>
        public string getString(string s11)
        {
            pervL = 1;
            needPlus = false;

            Console.WriteLine(s11);

            StringBuilder res = new StringBuilder();
            Block curBlk = null;

            buildTree(ref curBlk, s11);

            List<Block> list = new List<Block>();
            buildBlockList(ref list, ref res, curBlk);
            res.Append(")");

            return res.ToString();
        }

        /// <summary>
        /// строит дерево из входной строки
        /// </summary>
        /// <param name="curBlk"></param>
        /// <param name="s1"></param>
        void buildTree(ref Block curBlk, string s1)
        {
            Stack<Block> stcBlks = new Stack<Block>();

            int level = 0;

            foreach (char c in s1)
            {
                if (c == '(')
                {
                    level++;
                    //Console.WriteLine("( " + level);
                    curBlk = new Block();
                    curBlk.Level = level;

                    if (stcBlks.Count > 0)
                        stcBlks.Peek().children.Add(curBlk);

                    stcBlks.Push(curBlk);
                }

                if (c == ')')
                {
                    level--;

                    stcBlks.Pop();

                    if (stcBlks.Count > 0)
                        curBlk = stcBlks.Peek();
                    curBlk.children.Sort();
                }

                if (char.IsLetter(c))
                {
                    //Console.WriteLine("ADD  " +c.ToString() + " " + curBlk.Level + " TO  "  + curBlk.ToString() + " " + (curBlk.Level + 1));
                    curBlk.children.Add(new Block(c.ToString(), curBlk.Level + 1));
                }
            }
        }
    }
}




/*
void buildBlockList1(ref List<Block> list, Block blkc, bool reduce)
{
   if (reduce)
       blkc.tryReduceMe();

   string s = blkc.ToString();

   Console.WriteLine(s + " " + blkc.Level);


   if (!string.IsNullOrEmpty(s))
   {
       list.Add(blkc);
   }

   foreach (Block bl in blkc.children)
       buildBlockList1(ref list, bl, reduce);
}
*/



     /*
      * 
      * main
        // list.Sort();
             //List<Block> sorted = list.OrderBy(x => x.Level).ThenBy(x => x.cchR).ToList();
             // int i = 0;
             //int baseB = 1;

             /*
              *  int diff_bracketes = 0;
             for (i = 0; i < list.Count; i++)
             {
                 diff_bracketes = list[i].Level;
             }

             res.Append(printBracketsA(baseB));
             for (i = 0; i < sorted.Count; i++)
             {

                 if (i > 0)
                 {
                     res.Append(printBracketsB((sorted[i].Level - sorted[i - 1].Level)));

                     res.Append("+");

                     res.Append(printBracketsA((sorted[i].Level - sorted[i - 1].Level)));
                 }

                 if (sorted[i].complex)
                     res.Append(printBracketsA(1));

                 res.Append(sorted[i] + "[" + sorted[i].Level +"] ");
                 if (sorted[i].complex)
                     res.Append(printBracketsB(-1));

                 diff_bracketes = sorted[i].Level;
             }
     //res.Append(printBracketsB(baseB));

     */