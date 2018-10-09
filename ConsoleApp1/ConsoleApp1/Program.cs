using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Vector
    {
        private int[] massive;
        private int count;
        private static int status;
        private readonly int ID;
        public Vector() : this(new[] { 1, 2, 3, 4, 5 }, 5, 0) { }
        public Vector(int[] massive1) : this(massive1,massive1.Length) { }
        static Vector() { status = 0;Add(); }
        private Vector(int[] massive1, int count1, int status1 = 0) { massive = massive1; count = count1; status = status1;ID = count.GetHashCode();Add(); }
        internal const int random = 15;
        public int[] Massive
        {
            get
            {
                return massive;
            }
            set
            {
                massive = value;
            }
        }
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                if(value>2)
                {
                    Console.WriteLine("Недопустимое значение кода ошибки");
                    status = 1;
                }
                else
                {
                    status = value;
                }
            }
        }
        public int Id
        {
            get
            {
                return ID;
            }
        }
        private static int size = 0;
        private static void Add()
        {
            size++;
        }
        public static void OutputInfo()
        {
            Console.WriteLine($"Количество экземпляров класса {size}");
        }
        public int this[int i]
        {
            get
            {
                return massive[i];
            }
            set
            {
                massive[i] = value;
            }
        }
    }
    partial class Vector
    {
        public static void part()
        {
            Console.WriteLine("Использовал partial в классе");
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Vector vect = (Vector)obj;
            return vect.ID == this.ID;
        }
        public override int GetHashCode()
        {
            int hash=0;
           for(int i=0;i<massive.Length;i++)
            {
                hash += massive[i];
            }
            hash = hash / count;
            return hash;
        }
        public override string ToString()
        {
            return "Type " + base.ToString() + count + " " + ID;
        }
        public int sum()
        {
            int summ=0;
            foreach(int k in massive)
            {
                summ += k;
            }
            return summ;
        }
        public int sum(ref int num)//сумма с числом и с ref параметром
        {
            int summ = sum() + num;
            return summ;
        }

        public int increase()
        {
            int Increase = 0;
            foreach (int k in massive)
            {
                Increase *= k;
            }
            return Increase;
        }
       public void watchfirstind(ref int index)
        {
            for(int i=0;i<index;i++)
            {
                Console.Write(massive[i] + " ");
            }
        }
        public bool nullinvector()
        {
            for(int i=0;i<massive.Length;i++)
            {
                if(massive[i]==0)
                {
                    return true;
                }
               
                
            }
            return false;
        }
        public double module()
        {
            double mod=0;
            for (int i = 0; i < massive.Length; i++)
            {
                mod = massive[i] * massive[i];
            }
            mod = Math.Sqrt(mod);
            return mod;
        }
    }
    class Program
    { 
        static void Main(string[] args)
        {
            Vector[] vectors= new Vector[5];
            vectors[0] = new Vector();
            vectors[1]=new Vector(new int []{ 1,2,3,4,5,0});
            vectors[2] = new Vector(new int[] { 1, 2, 3, 4, 5, 0,7,4,2,5,6 });
            vectors[3] = new Vector();
            vectors[4] = new Vector(new int[] { 1, 2, 3, 4, 5, 0,12,43252,123,123435 });
            double[] mod = new double[5];
            for (int i = 0; i < 5; i++)
            {
                if (vectors[i].nullinvector())
                {
                    Console.WriteLine($"Объект {i} содержит 0");
                }
                mod[i] = vectors[i].module();
            }
            Array.Sort(mod);
            Console.WriteLine("Минимальный модуль "+mod[1]);//из-за статического конструктора так
            Vector vector1 = new Vector(new int[] { 124, 234, 41, 32, 132, 1233, 2 });
            Console.WriteLine("Сумма вектора " + vector1.sum());
            Console.WriteLine("Модуль вектора " + vector1.module());
            Vector vector2 = new Vector(new int[] { 124, 234, 41, 32, 132, 1233, 2 });
            Console.WriteLine(vector1.Equals(vector1));
            Console.WriteLine(vector1.ToString());
            var hello = new { Name = "Hello", site = "tut.by" };
            Console.WriteLine(hello.GetType());
        }

    }
   
}
