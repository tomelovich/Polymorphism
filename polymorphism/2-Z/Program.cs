using System;

namespace _2_Z
{
    abstract class Vector
    {
        public string name;
        public Vector()
        {
            this.name = null;
        }
        public virtual void Input()
        {
            Console.Write("Введите название вектора- ");
            name = Console.ReadLine();
        }
        public virtual void GetInfo()
        {
            Console.WriteLine("Название:{0} ", name);
        }
    }
    class Vector1 : Vector
    {
        public int x;
        public int y;
        public int z;
        public double cost;
        public Vector1()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
            Input();
        }
        public override void Input()
        {
            base.Input();
            Console.Write("Введите x- ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите y- ");
            y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите z- ");
            z = Convert.ToInt32(Console.ReadLine());
        }
        public virtual void Cost1()
        {
            cost = Math.Sqrt(x * x + y * y + z*z);
        }
        public override void GetInfo()
        {
            Cost1();
            Console.WriteLine("Название:{0} \nДлина вектора :{1}", name, cost);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int mascount = 2;
            Vector[] transmas = new Vector[mascount];
            Console.WriteLine("Выберите создаваемый объект:");
            Console.WriteLine("1. Vector \n2. Vector1");
            int change = Convert.ToInt32(Console.ReadLine());
            int i = 0;    
            double costs = 0;
            while (i < mascount)
            {
                switch (change)
                {
                    case 1: break;
                    
                    case 2:
                        Vector1 vector = new Vector1();
                        vector.Cost1();
                        costs = costs + vector.cost;
                        transmas[i] = vector as Vector; ++i; break;
                    default: Console.WriteLine("Нет такого пункта!"); break;
                }
            }
            for (int t = 0; t < transmas.Length; t++)
            {
                if (transmas[t] != null)
                {
                    transmas[t].GetInfo();                   
                }
            }
            Console.WriteLine("Суммарная длина векторов = {0}",costs);          
        }
    }
}
