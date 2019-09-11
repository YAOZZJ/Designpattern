using System;

namespace _04_代理模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        static void Run()
        {
            SchoolGirl jiaojiao = new SchoolGirl();
            jiaojiao.Name = "李娇娇";
            Proxy proxy = new Proxy(jiaojiao);
            proxy.GiveDolls();
            proxy.GiveFlowers();
            proxy.GiveChocolate();
        }
    }
    /// <summary>
    /// 代理接口
    /// </summary>
    interface GiveGift
    {
        void GiveDolls();
        void GiveFlowers();
        void GiveChocolate();
    }
    /// <summary>
    /// 追求者类
    /// </summary>
    class Pursuit : GiveGift
    {
        SchoolGirl mm;
        public Pursuit(SchoolGirl mm)
        {
            this.mm = mm;
        }
        public void GiveDolls()
        {
            Console.WriteLine(mm.Name + "送你洋娃娃");
        }
        public void GiveFlowers()
        {
            Console.WriteLine(mm.Name + "送你鲜花");
        }
        public void GiveChocolate()
        {
            Console.WriteLine(mm.Name + "送你巧克力");
        }
    }
    /// <summary>
    /// 代理类
    /// 通过代理类实现追求者类
    /// 并调用用追求者类方法
    /// </summary>
    class Proxy : GiveGift
    {
        Pursuit gg;
        public Proxy(SchoolGirl mm)
        {
            this.gg = new Pursuit(mm);
        }
        public void GiveDolls()
        {
            gg.GiveDolls();
        }
        public void GiveFlowers()
        {
            gg.GiveFlowers();
        }
        public void GiveChocolate()
        {
            gg.GiveChocolate();
        }
    }
    /// <summary>
    /// 被追求者类
    /// </summary>
    class SchoolGirl
    {
        private string _name;

        public string Name { get => _name; set => _name = value; }
    }
}
