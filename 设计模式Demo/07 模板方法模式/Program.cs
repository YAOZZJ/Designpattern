using System;

namespace _07_模板方法模式
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractClass abstractClass;
            abstractClass = new ConcreteClassA();
            abstractClass.TemplateMethod();
            abstractClass = new ConcreteClassB();
            abstractClass.TemplateMethod();

        }
    }
    /// <summary>
    /// 抽象模板
    /// </summary>
    abstract class AbstractClass
    {
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();
        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
        }
    }
    /// <summary>
    /// 具体方法
    /// </summary>
    class ConcreteClassA : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("具体类A方法1实现");
        }
        public override void PrimitiveOperation2()
        {
            Console.WriteLine("具体类A方法2实现");
        }
    }
    class ConcreteClassB : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("具体类B方法1实现");
        }
        public override void PrimitiveOperation2()
        {
            Console.WriteLine("具体类B方法2实现");
        }
    }
}
