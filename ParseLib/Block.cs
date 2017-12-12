using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseLib
{
    class Block : IComparable
    {
        public Guid id { get; }

        public int Level { get; set; }
        public bool complex { get; set; }
        public List<Block> children = new List<Block>();


        bool _hasC;
        public bool
            hasC
        {

            get
            {
                if (string.IsNullOrEmpty(_cchR))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        


        string _cchR;
        public string 
            cchR {

            get
            {
                if (string.IsNullOrEmpty(_cchR))
                {
                    if (children.Count > 0)
                    {
                        return children[0].cchR;
                    }
                    else
                    {
                        return "";
                    }
                }
                return _cchR;
            }

            set
            {
                _cchR = value; 
            }

        }
        public bool isTerminal = false;

        public Block()
        {
            id = Guid.NewGuid();
            complex = false;
        }

        public Block(string cchR, int Level) : this()
        {
            this.cchR = cchR;
            this.Level = Level;
        }

        /// <summary>
        /// скленить дочерние узлы,
        /// если они терминальные
        /// </summary>
        public void tryReduceMe()
        {
            //if (this.isTerminal == true)
            //    return;
            int addedet = 0;
            if (this.children.Count == this.getCC())
            {
                this.children.Sort();
                foreach (Block bl in this.children)
                {
                    if (bl.children.Count() == 0)
                    {
                        if (cchR != "")
                            cchR += "+";
                        cchR += bl.cchR;
                        addedet++;
                    }
                }

                if (addedet > 1)
                    this.complex = true;

                this.children.Clear();

            }
        }

        /// <summary>
        /// подсчитать потомков у потомка
        /// </summary>
        /// <returns></returns>
        public int getCC()
        {
            int res = 0;
            foreach (Block bl in this.children)
            {
                if (bl.children.Count() == 0)
                    res++;
            }
            return res;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty( cchR ))
                return cchR.ToString();

            return "<null>";
        }

        public int CompareTo(object obj)
        {
           

            if (this.cchR == null)
                return 0;

            Block p = obj as Block;
            if (p != null)
            {
                //Console.WriteLine(string.Format( "CompareTo {0}[{1}] and  {2}[{3}]" , this.cchR , this.Level, p.cchR, p.Level));
                return this.cchR.CompareTo(p.cchR);
            }
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

    }

}
