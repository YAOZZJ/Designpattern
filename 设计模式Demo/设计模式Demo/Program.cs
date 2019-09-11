using System;

namespace 设计模式Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        static void Run()
        {
            Opration opration = new Opration();
            while (true)
            {
                try
                {
                    //获取输入
                    Console.WriteLine("请输入数字A: ");
                    string strNumberA = Console.ReadLine();
                    Console.WriteLine("请输入运算符号(+,-,*,/): ");
                    string strOprate = Console.ReadLine();
                    Console.WriteLine("请输入数字B: ");
                    string strNumberB = Console.ReadLine();

                    //工厂根据输入生产出实例
                    opration = OprationFactory.CreateOperate(strOprate);
                    opration.NumberA = Convert.ToDouble(strNumberA);
                    opration.NumberB = Convert.ToDouble(strNumberB);
                    Console.WriteLine("结果:" + opration.GetResult());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("输入错误:" + ex.Message);
                }
            }
        }
    }
    /// <summary>
    /// 简单工厂类
    /// 通过输入条件返回合适的单一对象
    /// </summary>
    class OprationFactory
    {
        public static Opration CreateOperate(string operate)
        {
            Opration operation = null;
            switch(operate)
            {
                case "+": operation = new OprationAdd(); break;
                case "-": operation = new OprationSub(); break;
                case "*": operation = new OprationMul(); break;
                case "/": operation = new OprationDiv(); break;
                default:throw new Exception("运算符号未注册!");
            }
            return operation;
        }
    }
    /// <summary>
    /// 运算类
    /// </summary>
    class Opration
    {
        private double _numberA = 0;
        private double _numberB = 0;

        public double NumberA { get => _numberA; set => _numberA = value; }
        public double NumberB { get => _numberB; set => _numberB = value; }
        public virtual double GetResult()
        {
            return (NumberA + NumberB);
        }
    }
    #region "加减乘除类"
    class OprationAdd : Opration
    {
        //基类是加法,可不重构
        public override double GetResult()
        {
            return base.GetResult();
        }
    }
    class OprationSub : Opration
    {
        public override double GetResult()
        {
            return (NumberA - NumberB);
        }
    }
    class OprationMul : Opration
    {
        public override double GetResult()
        {
            return (NumberA * NumberB);
        }
    }
    class OprationDiv : Opration
    {
        public override double GetResult()
        {
            if (NumberB == 0)
                throw new Exception("除数不能为0.");
            return (NumberA / NumberB);
        }
    }
    #endregion
}
