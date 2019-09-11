using System;

namespace _05_工厂方法模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        static void Run()
        {
            //用一个具体工厂实例化工厂接口
            IFactory factory = new AddFactory();
            Opration opration = factory.CreateOperation();
            opration.NumberA = 2;
            opration.NumberB = 3;
            Console.WriteLine(opration.GetResult());
        }
    }
    /// <summary>
    /// 工厂接口
    /// </summary>
    interface IFactory
    {
        Opration CreateOperation();
    }
    #region "具体工厂"
    class AddFactory : IFactory
    {
        public Opration CreateOperation()
        {
            return new OprationAdd();
        }
    }
    class SubFactory : IFactory
    {
        public Opration CreateOperation()
        {
            return new OprationSub();
        }
    }
    class MulFactory : IFactory
    {
        public Opration CreateOperation()
        {
            return new OprationMul();
        }
    }
    class DivFactory : IFactory
    {
        public Opration CreateOperation()
        {
            return new OprationDiv();
        }
    }
    #endregion
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
