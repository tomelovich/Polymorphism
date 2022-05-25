using System;

namespace _1_Z
{
   class Furniture
    {
        public string name;
        public Furniture()
        {
            this.name = null;
        }
        public virtual void Input()
        {
            Console.Write("Введите название мебели- ");
            name = Console.ReadLine();
        }
        public virtual void GetInfo()
        {
            Console.WriteLine("Название:{0} ", name);
        }
   }
    class Closet : Furniture
    {
        public int volume;
        public string port;
        public double cost;
        public Closet()
        {
            this.volume = 0;
            this.port = null;
            Input();
        }
        public override void Input()
        {
            base.Input();
            Console.Write("Введите объем в см- ");
            volume = Convert.ToInt32(Console.ReadLine());
        }
        public virtual void CostCloset()
        {
            cost = Math.Abs(volume) * 0.75;
        }
        public override void GetInfo()
        {
            CostCloset();
            Console.WriteLine("Название:{0} \nОбъём:{1} \nСтоимость:{2}",name, volume,cost);
        }
    }
    class Sofa : Furniture
    {
        public int s;
        public double cost;
        public Sofa()
        {
            this.s = 0;
            Input();
        }
        public override void Input()
        {
            base.Input();
            Console.Write("Введите площадь- ");
            s = Convert.ToInt32(Console.ReadLine());
        }
        public virtual void CostSofa()
        {
            cost = (Math.Pow(s, 2) / 3) + 5000;
        }
        public override void GetInfo()
        {
            CostSofa();
            Console.WriteLine("Название:{0} \nПлощадь:{1} \nСтоимость:{2}", name, s, cost);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int mascount = 2;
            Furniture[] transmas = new Furniture[mascount];
            Console.WriteLine("Выберите создаваемый объект:");
            Console.WriteLine("1. Furniture \n2. Сloset \n3. Sofa");
            int change = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            double costc = 0;
            double costs = 0;
            double Srcostc = 0;
            double Srcosts = 0;
            while (i< mascount)
            {
                switch (change)
                {
                    case 1: transmas[i] = new Furniture(); ++i;break;
                    case 2:
                        Sofa sofa = new Sofa();
                        sofa.CostSofa();
                        costc = costc + sofa.cost;
                        transmas[i] = sofa as Furniture;++i;break;
                    case 3:
                        Closet closet = new Closet();
                        closet.CostCloset();
                        costs = costs + closet.cost;
                        transmas[i] = closet as Furniture; ++i; break;
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
            Srcostc = costc / mascount;
            Srcosts = costs / mascount;
            if (Srcostc == 0)
                Console.WriteLine("Средняя стоимость:{0}",Srcosts);
            else Console.WriteLine("Средняя стоимость:{0}", Srcostc);
        }
    }
}
